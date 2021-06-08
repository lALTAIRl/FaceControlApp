namespace FaceControlApp.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using FaceControlApp.Domain.Entities;
    using FaceControlApp.Persistence;
    using FaceControlApp.Application.Aggregates.BiometricalIdentifiers.Commands.CreateBoimetricalIdentifier;
    using FaceControlApp.Application.Aggregates.BiometricalIdentifiers.Queries.GetBiometricalIdentifier;

    public class BiometricalIdentifiersController : AppController
    {
        private FaceControlAppDbContext Context
        {
            get;
        }

        public BiometricalIdentifiersController(FaceControlAppDbContext context)
        {
            this.Context = context;
        }

        // GET: BiometricalIdentifiers
        public async Task<IActionResult> Index()
        {
            return this.View(await this.Context.BiometricalIdentifiers.ToListAsync());
        }

        // GET: BiometricalIdentifiers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            try
            {
                var result = await this.Mediator.Send(new GetBiometricalIdentifierQuery
                {
                    Id = id.Value
                });

                return this.View(result);
            }
            catch
            {
                return this.NotFound();
            }
        }

        // GET: BiometricalIdentifiers/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: BiometricalIdentifiers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBiometricalIdentifierCommand command)
        {
            var result = await this.Mediator.Send(command);

            return this.RedirectToAction("Details", new { id = result});
        }

        // GET: BiometricalIdentifiers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var biometricalIdentifier = await this.Context.BiometricalIdentifiers.FindAsync(id);
            if (biometricalIdentifier == null)
            {
                return this.NotFound();
            }
            return this.View(biometricalIdentifier);
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
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.Context.Update(biometricalIdentifier);
                    await this.Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.BiometricalIdentifierExists(biometricalIdentifier.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectToAction(nameof(Index));
            }
            return this.View(biometricalIdentifier);
        }

        // GET: BiometricalIdentifiers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var biometricalIdentifier = await this.Context.BiometricalIdentifiers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biometricalIdentifier == null)
            {
                return this.NotFound();
            }

            return this.View(biometricalIdentifier);
        }

        // POST: BiometricalIdentifiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var biometricalIdentifier = await this.Context.BiometricalIdentifiers.FindAsync(id);
            this.Context.BiometricalIdentifiers.Remove(biometricalIdentifier);
            await this.Context.SaveChangesAsync();
            return this.RedirectToAction(nameof(Index));
        }

        private bool BiometricalIdentifierExists(Guid id)
        {
            return this.Context.BiometricalIdentifiers.Any(e => e.Id == id);
        }
    }
}
