using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ironwood.UI.Models;
using Ironwood.UI.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Ironwood.Enums;
using Ironwood.Application.Matches.Queries;

namespace Ironwood.UI.Controllers
{
    public class HomeController : BaseController
    {
          
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole(AccessRole.Admin.ToString()))
                {
                    return RedirectToAction("Index","Admin");
                }
               
            }
            
            var _incomingMatches = await Mediator.Send(new GetAllIncomingMatchesQuery{});
            var _incomingDotaMatches = await Mediator.Send(new GetAllIncomingDotaMatchQuery{});
                               
                    var _viewMod = new HomePageVM
                    {
                        IncomingMatch = _incomingMatches,
                        IncomingDotaMatches = _incomingDotaMatches                        
                    };

            return View(_viewMod);
        }
     
    }
}
