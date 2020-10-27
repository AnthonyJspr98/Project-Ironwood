using Ironwood.Application.Common.Interfaces.Security;
using Ironwood.Application.Users.Commands;
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
    public class SecurityController : BaseController
    {
        private readonly ISignInManager signInManager;

        public SecurityController(ISignInManager signInManager)
        {
            this.signInManager = signInManager;
        }

        [Route("/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authenticate(LoginVM loginData)
        {
            await signInManager.PasswordSignInAsync(loginData.Username, loginData.Password);

            return Json(true);
        }

        [Route("/Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAccount(RegisterCommand command)
        {
            var _result = await Mediator.Send(command);

            await WriteOnlyDbContext.SaveChangesAsync();

            await signInManager.PasswordSignInAsync(_result.EmailAddress, command.Password);

            return Json(true);

           
        }
        [Route("/Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return Redirect("/Login");
        }

    }
}
