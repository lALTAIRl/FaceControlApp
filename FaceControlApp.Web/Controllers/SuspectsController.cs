namespace FaceControlApp.Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using FaceControlApp.Application.Aggregates.Suspects.Commands.VerifySuspect;
    using FaceControlApp.Application.Aggregates.Suspects.Queries.GetSuspectDetails;
    using FaceControlApp.Application.Aggregates.Suspects.Queries.GetSuspects;
    using Microsoft.AspNetCore.Mvc;

    public class SuspectsController : AppController
    {
        public async Task<IActionResult> Index()
        {
            var result = await this.Mediator.Send(new GetSuspectsQuery());

            return this.View(result);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            try
            {
                var result = await this.Mediator.Send(new GetSuspectDetailsQuery
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

        public async Task<IActionResult> Verify(Guid? id)
        {
            try
            {
                var result = await this.Mediator.Send(new GetSuspectDetailsQuery
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

        [HttpPost]
        public async Task<IActionResult> Verify(VerifySuspectCommand command)
        {
            var result = await this.Mediator.Send(command);

            return this.RedirectToAction("Details", "BiometricaIdentifiers", new { id = result });
        }
    }
}
