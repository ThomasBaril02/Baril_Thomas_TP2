using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JuliePro.Services;
using JuliePro.Models;
using JuliePro.Utility;

namespace JuliePro.Controllers
{
    public class TrainerController : Controller
    {
      
        private readonly TrainerService _service;
        private readonly IServiceBaseAsync<Discipline> _disciplineService;

        public TrainerController(TrainerService service, IServiceBaseAsync<Discipline> disciplineService)
        {
      
            _service = service;
            _disciplineService = disciplineService;
        }

        // GET: Trainer
        public async Task<IActionResult> Index()
        {

            var trainers = await this._service.GetAllAsync(new TrainerSearchViewModelFilter() { SelectedPageIndex = 0, SelectedPageSize=9 }); 

            return View(trainers);
        }


        public async Task<IActionResult> Filter(TrainerSearchViewModelFilter filter)
        {
            //TODO implantez cette méthode (vous pouvez retourner la vue Index, avec le modèle filtré)!

            return RedirectToAction(nameof(Index));
        }


        // GET: Trainer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = await _service.GetByIdAsync(id.Value);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        // GET: Trainer/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Discipline_Id"] = new SelectList(await _disciplineService.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: Trainer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromServices] IImageFileManager fileManager, Trainer trainer)
        {

            ModelState.Remove(nameof(trainer.TrainerCertifications));
            ModelState.Remove(nameof(trainer.Discipline));
            ModelState.Remove(nameof(trainer.Records));

            if (ModelState.IsValid)
            {
               

                await _service.CreateAsync(trainer, HttpContext.Request.Form);

                return RedirectToAction(nameof(Index));
            }
            ViewData["Discipline_Id"] = new SelectList(await _disciplineService.GetAllAsync(), "Id", "Name");
            return View(trainer);
        }

        // GET: Trainer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var trainer = await _service.GetByIdAsync(id.Value);
            if (trainer == null)
            {
                return NotFound();
            }
            ViewData["Discipline_Id"] = new SelectList(await _disciplineService.GetAllAsync(), "Id", "Name");
            return View(trainer);
        }

        // POST: Trainer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromServices] IImageFileManager fileManager, int id, Trainer trainer)
        {
            if (id != trainer.Id)
            {
                return NotFound();
            }
            ModelState.Remove(nameof(trainer.TrainerCertifications));
            ModelState.Remove(nameof(trainer.Discipline));
            ModelState.Remove(nameof(trainer.Records));

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.EditAsync(trainer, HttpContext.Request.Form);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.ExistsAsync(trainer.Id))
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
            ViewData["Discipline_Id"] = new SelectList(await _disciplineService.GetAllAsync(), "Id", "Name");
            return View(trainer);
        }

        // GET: Trainer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = await _service.GetByIdAsync(id.Value);
            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }

        // POST: Trainer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
