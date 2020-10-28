using Ironwood.Application.Accounts.Commands;
using Ironwood.Application.Users.Commands;
using Ironwood.Application.Users.Queries;
using Ironwood.Enums;
using Ironwood.UI.Controllers.Base;
using Ironwood.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ironwood.UI.Controllers
{

    public class AccountController : BaseController
    {
        [Route("/Profile")]
        public async Task<IActionResult> Profile()
        {
            var _userData = await Mediator.Send(new GetUserQuery {UID = CurrentUser.UID });

            var _userModel = new UpdateProfileCommand {
            
                Firstname = _userData.FirstName,
                Middlename = _userData.MiddleName,
                Lastname = _userData.LastName,
                BirthDate = _userData.BirthDate,
                Gender = _userData.Gender,
                Email = _userData.EmailAddress,
                MobileNumber = _userData.MobileNumber,
                HouseNumAndStreet = _userData.Address,
                City = _userData.City,
                Country = _userData.Country            
            };

            List<SelectListItem> GenderList = new List<SelectListItem>
            { 
                new SelectListItem { Text = Gender.Male.ToString(), Value = Gender.Male.ToString()},
                new SelectListItem { Text = Gender.Female.ToString(), Value = Gender.Female.ToString()}
            };

            ViewBag.Gender = new SelectList(GenderList, "Value", "Text", _userData.Gender);

            return View(_userModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveChanges(UpdateProfileCommand command)
        {
            await Mediator.Send(command);

            await WriteOnlyDbContext.SaveChangesAsync();

            return Json(true);
        }

        [Route("/AccountSettings")]
        public async Task<IActionResult> AccountSettings()
        {
            return View();
        }

        public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
        {
            await Mediator.Send(command);

            await WriteOnlyDbContext.SaveChangesAsync();

            return Json(true);
        }
    }
}   
