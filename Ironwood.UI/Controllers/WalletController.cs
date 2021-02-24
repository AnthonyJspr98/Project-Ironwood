using System;
using System.Threading.Tasks;
using Ironwood.Application.Vouchers.Commands;
using Ironwood.Application.Wallets.Queries;
using Ironwood.UI.Controllers.Base;
using Ironwood.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ironwood.UI.Controllers
{
    public class WalletController : BaseController
    {
       [Route("/Wallet")]
        public async Task<IActionResult> Index()
        {
            var _walletAddress = CurrentUser.UserDetails.Wallet.Address;
            var _walletBalance = await Mediator.Send(new GetWalletBalanceQuery{WalletAddress = _walletAddress});
            var _walletHis = await Mediator.Send(new GetWalletHistoryQuery {WalletAddress = _walletAddress});

            var _walletDetails = new WalletVM
            {
                UID = CurrentUser.UID,
                UserEmail = CurrentUser.UserDetails.EmailAddress,
                Balance = _walletBalance,
                WalletHistory = _walletHis

            };
           
           return View(_walletDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RedeemVoucher(RedeemVoucherCommand command)
        {
            await Mediator.Send(command);

            await WriteOnlyDbContext.SaveChangesAsync();

            return Json(true);    
                  
        }

        

        
    }
}