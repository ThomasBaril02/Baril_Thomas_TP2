using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JuliePro.Services;
using JuliePro.Models;

namespace JuliePro.Controllers
{
    public class TrainerCertificationController : Controller
    {
        private readonly IServiceBaseAsync<TrainerCertification> _service;
        private readonly IServiceBaseAsync<Certification> _certificationService;
        private TrainerService _trainerService;

        public TrainerCertificationController(IServiceBaseAsync<TrainerCertification> service, IServiceBaseAsync<Certification> certificationService, TrainerService trainerService)
        {
            _service = service;
            _certificationService = certificationService;
            _trainerService = trainerService;

        
        }

        // GET: TrainerCertification
        public async Task<IActionResult> Index()
        {
            List<TrainerCertification> trainerCertifications = await _service.GetAllAsync();
            trainerCertifications = trainerCertifications.OrderBy(tc => tc.Trainer.FullName).ThenBy(tc => tc.Certification.FullTitle).ToList();
            return View(trainerCertifications);
        }

        // GET: TrainerCertification/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainerCertification = await _service.GetByIdAsync(id.Value);
            if (trainerCertification == null)
            {
                return NotFound();
            }

            return View(trainerCertification);
        }

        // GET: TrainerCertification/Create
        public async Task<IActionResult> Create(int? certificationId, int? trainerId)
        {

            var model = new TrainerCertification() { Certification_Id = certificationId ?? 0, Trainer_Id = trainerId ?? 0}; 


            ViewData["Certification_Id"] = new SelectList(await _certificationService.GetAllAsync(), "Id", "FullTitle");
            ViewData["Trainer_Id"] = new SelectList(await _trainerService.GetAllAsync() , "Id", "FullName");
            return View(model);
        }

        // POST: TrainerCertification/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( TrainerCertification trainerCertification)
        {
            ModelState.Remove(nameof(trainerCertification.Trainer));
            ModelState.Remove(nameof(trainerCertification.Certification));
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(trainerCertification);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Certification_Id"] = new SelectList(await _certificationService.GetAllAsync(), "Id", "FullTitle");
            ViewData["Trainer_Id"] = new SelectList(await _trainerService.GetAllAsync(), "Id", "FullName");
            return View(trainerCertification);
        }

        // GET: TrainerCertification/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainerCertification = await _service.GetByIdAsync(id.Value);
            if (trainerCertification == null)
            {
                return NotFound();
            }
            ViewData["Certification_Id"] = new SelectList(await _certificationService.GetAllAsync(), "Id", "FullTitle");
            ViewData["Trainer_Id"] = new SelectList(await _trainerService.GetAllAsync(), "Id", "FullName");
            return View(trainerCertification);
        }

        // POST: TrainerCertification/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TrainerCertification trainerCertification)
        {

            ModelState.Remove(nameof(trainerCertification.Trainer));
            ModelState.Remove(nameof(trainerCertification.Certification));

            if (id != trainerCertification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.EditAsync(trainerCertification);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.ExistsAsync(trainerCertification.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Certification_Id"] = new SelectList(await _certificationService.GetAllAsync(), "Id", "FullTitle");
            ViewData["Trainer_Id"] = new SelectList(await _trainerService.GetAllAsync(), "Id", "FullName");
            return View(trainerCertification);
        }

        // GET: TrainerCertification/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var trainerCertification = await _service.GetByIdAsync(id.Value);
            if (trainerCertification == null)
            {
                return NotFound();
            }

            return View(trainerCertification);
        }

        // POST: TrainerCertification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
