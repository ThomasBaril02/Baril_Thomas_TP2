using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using JuliePro.Services;
using JuliePro.Models;

namespace JuliePro.Controllers
{
    public class CertificationController : Controller
    {
        private readonly CertificationService _service;
        private readonly IStringLocalizer<CertificationController> _localizer;

        public CertificationController(CertificationService service, IStringLocalizer<CertificationController> localizer)
        {
            _service = service;
            _localizer = localizer;
        }

        // GET: Certification
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
                        
        }

        public async Task<IActionResult> TrainerIndex(int trainerId) {

            return View(await _service.GetAllByTrainerAsync(trainerId));
        
        }

        // GET: Certification/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var certification = await _service.GetByIdAsync(id.Value);

            if (certification == null)
            {
                return NotFound();
            }

            return View(certification);
        }

        // GET: Certification/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Certification/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Certification certification)
        {
            ModelState.Remove(nameof(certification.TrainerCertifications));

            if (ModelState.IsValid)
            {
                await _service.CreateAsync(certification);
                return RedirectToAction(nameof(Index));
            }
            return View(certification);
        }

        // GET: Certification/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certification = await _service.GetByIdAsync(id.Value);
            if (certification == null)
            {
                return NotFound();
            }
            return View(certification);
        }

        // POST: Certification/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Certification certification)
        {

            ModelState.Remove(nameof(certification.TrainerCertifications));

            if (id != certification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  await _service.EditAsync(certification);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _service.ExistsAsync(id)))
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
            return View(certification);
        }

        // GET: Certification/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var certification = await _service.GetByIdAsync(id.Value);
            if (certification == null)
            {
                return NotFound();
            }

            return View(certification);
        }

        // POST: Certification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
          
            await _service.DeleteAsync(id);
            
           
            return RedirectToAction(nameof(Index));
        }

        
    }
}
