using Ironwood.Application.Teams.Commands;
using Ironwood.Application.Tournaments.Commands;
using Ironwood.Application.Vouchers.Commands;
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
    [Authorize(Roles ="Admin")]
    public class AdminController : BaseController
    {
        [Route("/AdminDashboard")]
        public async Task<IActionResult> Index()
        {
            var _adminEmail = CurrentUser.UserDetails.EmailAddress;
            var _UID = CurrentUser.UID;
            var _role = CurrentUser.UserDetails.AccessRole;

            var _adminDetails = new AdminVM
            {
                AdminEmail = _adminEmail,
                UID = _UID,
                AccessRole = _role
            };
            return View(_adminDetails);
        }

        [HttpPost]       
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GenerateVoucher(CreateVoucherCodeCommand command)
        {
            var result = await Mediator.Send(command);

            await WriteOnlyDbContext.SaveChangesAsync();

            return Json(result.Code);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterTeam(RegisterTeamCommand cmd)
        {
            await Mediator.Send(cmd);

            await WriteOnlyDbContext.SaveChangesAsync();

            return Json(true);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTournament(RegisterTournamentCommand cmd)
        {
            await Mediator.Send(cmd);

            await WriteOnlyDbContext.SaveChangesAsync();
            
            return Json(true);
        }
    }
}
