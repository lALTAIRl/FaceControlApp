namespace FaceControlApp.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using FaceControlApp.Domain.Entities;
    using FaceControlApp.Persistence;

    public class BiometricalIdentifiersController : AppController
    {
        private readonly FaceControlAppDbContext _context;

        public BiometricalIdentifiersController(FaceControlAppDbContext context)
        {
            _context = context;
        }

        // GET: BiometricalIdentifiers
        public async Task<IActionResult> Index()
        {
            return View(await _context.BiometricalIdentifiers.ToListAsync());
        }

        // GET: BiometricalIdentifiers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biometricalIdentifier = await _context.BiometricalIdentifiers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biometricalIdentifier == null)
            {
                return NotFound();
            }

            return View(biometricalIdentifier);
        }

        // GET: BiometricalIdentifiers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BiometricalIdentifiers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonName,FaceImage")] BiometricalIdentifier biometricalIdentifier)
        {
            if (ModelState.IsValid)
            {
                biometricalIdentifier.Id = Guid.NewGuid();
                _context.Add(biometricalIdentifier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(biometricalIdentifier);
        }

        // GET: BiometricalIdentifiers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biometricalIdentifier = await _context.BiometricalIdentifiers.FindAsync(id);
            if (biometricalIdentifier == null)
            {
                return NotFound();
            }
            return View(biometricalIdentifier);
        }

        // POST: BiometricalIdentifiers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PersonName,FaceImage")] BiometricalIdentifier biometricalIdentifier)
        {
            if (id != biometricalIdentifier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biometricalIdentifier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiometricalIdentifierExists(biometricalIdentifier.Id))
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
            return View(biometricalIdentifier);
        }

        // GET: BiometricalIdentifiers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biometricalIdentifier = await _context.BiometricalIdentifiers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biometricalIdentifier == null)
            {
                return NotFound();
            }

            return View(biometricalIdentifier);
        }

        // POST: BiometricalIdentifiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var biometricalIdentifier = await _context.BiometricalIdentifiers.FindAsync(id);
            _context.BiometricalIdentifiers.Remove(biometricalIdentifier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiometricalIdentifierExists(Guid id)
        {
            return _context.BiometricalIdentifiers.Any(e => e.Id == id);
        }
    }
}
