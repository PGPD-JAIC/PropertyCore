using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PropertyCore.Common;

namespace PropertyCore.WebUI.Controllers
{
    public abstract class BaseController : Controller
    {
        private IMediator _mediator;
        private IDateTime _dateTime;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected IDateTime DateTime => _dateTime ??= HttpContext.RequestServices.GetService<IDateTime>();
    }
}
