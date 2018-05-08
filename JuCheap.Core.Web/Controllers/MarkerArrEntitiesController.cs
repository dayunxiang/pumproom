using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JuCheap.Core.Data;
using JuCheap.Core.Data.Entity;

namespace JuCheap.Core.Web.Controllers
{
    public class MarkerArrEntitiesController : Controller
    {
        private readonly JuCheapContext _context;

        public MarkerArrEntitiesController(JuCheapContext context)
        {
            _context = context;
        }

        // GET: MarkerArrEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.MarkerArrs.ToListAsync());
        }

        // GET: MarkerArrEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markerArrEntity = await _context.MarkerArrs
                .SingleOrDefaultAsync(m => m.id == id);
            if (markerArrEntity == null)
            {
                return NotFound();
            }

            return View(markerArrEntity);
        }

        // GET: MarkerArrEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MarkerArrEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title,elecname,electricity,watername,water,airname,air,alarmname,alarm,point,isOnline")] MarkerArrEntity markerArrEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(markerArrEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(markerArrEntity);
        }

        // GET: MarkerArrEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markerArrEntity = await _context.MarkerArrs.SingleOrDefaultAsync(m => m.id == id);
            if (markerArrEntity == null)
            {
                return NotFound();
            }
            return View(markerArrEntity);
        }

        // POST: MarkerArrEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,title,elecname,electricity,watername,water,airname,air,alarmname,alarm,point,isOnline")] MarkerArrEntity markerArrEntity)
        {
            if (id != markerArrEntity.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(markerArrEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkerArrEntityExists(markerArrEntity.id))
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
            return View(markerArrEntity);
        }

        // GET: MarkerArrEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markerArrEntity = await _context.MarkerArrs
                .SingleOrDefaultAsync(m => m.id == id);
            if (markerArrEntity == null)
            {
                return NotFound();
            }

            return View(markerArrEntity);
        }

        // POST: MarkerArrEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var markerArrEntity = await _context.MarkerArrs.SingleOrDefaultAsync(m => m.id == id);
            _context.MarkerArrs.Remove(markerArrEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkerArrEntityExists(int id)
        {
            return _context.MarkerArrs.Any(e => e.id == id);
        }
    }
}
