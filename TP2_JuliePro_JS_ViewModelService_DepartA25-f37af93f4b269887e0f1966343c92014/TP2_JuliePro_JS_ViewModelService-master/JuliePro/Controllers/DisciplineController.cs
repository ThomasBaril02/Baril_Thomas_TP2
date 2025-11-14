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
    public class DisciplineController : Controller
    {
        private readonly IServiceBaseAsync<Discipline> _service;

        public DisciplineController(IServiceBaseAsync<Discipline> service)
        {
            _service = service;
        }

        // GET: Discipline
        public async Task<IActionResult> Index()
        {
            return View(await  _service.GetAllAsync());
        }

        // GET: Discipline/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discipline = await _service.GetByIdAsync(id.Value);
            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        // GET: Discipline/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Discipline/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Discipline discipline)
        {
            if (ModelState.IsValid)
            {
               await _service.CreateAsync(discipline);
                return RedirectToAction(nameof(Index));
            }
            return View(discipline);
        }

        // GET: Discipline/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discipline = await _service.GetByIdAsync(id.Value);
            if (discipline == null)
            {
                return NotFound();
            }
            return View(discipline);
        }

        // POST: Discipline/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Discipline discipline)
        {
            if (id != discipline.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.EditAsync(discipline);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _service.ExistsAsync(discipline.Id)))
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
            return View(discipline);
        }

        // GET: Discipline/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discipline = await _service.GetByIdAsync(id.Value);

            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        // POST: Discipline/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
           await _service.DeleteAsync(id);
            
           return RedirectToAction(nameof(Index));
        }

      
    }
}
