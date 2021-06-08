namespace FaceControlApp.Web.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    public class AppController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => this._mediator ??= this.HttpContext.RequestServices.GetService<IMediator>();
    }
}
