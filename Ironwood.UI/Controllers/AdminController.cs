using Ironwood.Application.Vouchers.Commands;
using Ironwood.UI.Controllers.Base;
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
           
            return View();
        }

        [HttpPost]       
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GenerateVoucher(CreateVoucherCodeCommand command)
        {
            var result = await Mediator.Send(command);

            await WriteOnlyDbContext.SaveChangesAsync();

            return Json(result);
        }
    }
}
