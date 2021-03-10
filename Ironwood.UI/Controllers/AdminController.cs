using Ironwood.Application.Matches.Commands;
using Ironwood.Application.Matches.Queries;
using Ironwood.Application.Teams.Commands;
using Ironwood.Application.Teams.Queries;
using Ironwood.Application.Tournaments.Commands;
using Ironwood.Application.Tournaments.Queries;
using Ironwood.Application.Vouchers.Commands;
using Ironwood.Enums;
using Ironwood.UI.Controllers.Base;
using Ironwood.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            //Prepare Dropdownlists
            var _teams = await Mediator.Send(new GetAllTeamsQuery{});
            var _tournaments = await Mediator.Send(new GetAllTournamentsQuery{});
            
            List<SelectListItem> TeamList = new List<SelectListItem>();

            foreach (var item in _teams)
            {
                var selectListItem = new SelectListItem { Text = item.Name.ToString(), Value = item.UID.ToString()};
                TeamList.Add(selectListItem);
            }       
           
            List<SelectListItem> TournamentList = new List<SelectListItem>();

            foreach (var item in _tournaments)
            {
                var selectListItem = new SelectListItem { Text = item.Name.ToString(), Value = item.UID.ToString()};
                TournamentList.Add(selectListItem);
            }  

          

            List<SelectListItem> CategoryList = new List<SelectListItem>
            {
                new SelectListItem { Text = MatchCategory.Dota2.ToString(), Value = MatchCategory.Dota2.ToString()},
                new SelectListItem { Text = MatchCategory.LoL.ToString(), Value = MatchCategory.LoL.ToString()},
                new SelectListItem { Text = MatchCategory.Basketball.ToString(), Value = MatchCategory.Basketball.ToString()},
                new SelectListItem { Text = MatchCategory.Football.ToString(), Value = MatchCategory.Football.ToString()}
            };


            ViewBag.TeamOne = TeamList;
            ViewBag.TeamTwo = TeamList;
            ViewBag.Tournaments = TournamentList;
            ViewBag.Categories = CategoryList;
           

            var _adminEmail = CurrentUser.UserDetails.EmailAddress;
            var _UID = CurrentUser.UID;
            var _role = CurrentUser.UserDetails.AccessRole;

            
         
            var _adminDetails = new AdminVM
            {
                AdminEmail = _adminEmail,
                UID = _UID,
                AccessRole = _role,
                Teams = _teams,
                Tournaments = _tournaments,              
                
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

              
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMatch(CreateMatchCommand cmd)
        {
            await Mediator.Send(cmd);

            await WriteOnlyDbContext.SaveChangesAsync();
            
            return Json(true);
        }
    }
}
