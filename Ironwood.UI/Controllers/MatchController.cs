using Ironwood.Application.Matches.Queries;
using Ironwood.UI.Controllers.Base;
using Ironwood.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ironwood.UI.Controllers
{
    [AllowAnonymous]
    public class MatchController : BaseController
    {
        [Route("/Match")]
        public async Task<IActionResult> Index()
        {
            var _dotaMatces = await Mediator.Send(new GetAllIncomingDotaMatchQuery{});

            var _matchVM = new MatchesVM
            {
                DotaMatches = _dotaMatces
            };

            return View(_matchVM);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid uid)
        {
            var _detail = await Mediator.Send(new GetMatchDetailsQuery{UID = uid});

            return View(_detail);
        }
    }
}
