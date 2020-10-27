using Ironwood.Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ironwood.UI.Controllers.Base
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        private IMediator mediator;
        private ICurrentUser currentUser;
        private DbContext writeOnlyDbContext;

        internal IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        internal ICurrentUser CurrentUser => currentUser ??= HttpContext.RequestServices.GetService<ICurrentUser>();
        internal DbContext WriteOnlyDbContext => writeOnlyDbContext ??= HttpContext.RequestServices.GetService<DbContext>();
    }
}
