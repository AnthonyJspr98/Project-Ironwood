﻿using Ironwood.UI.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ironwood.UI.Controllers
{
    [AllowAnonymous]
    public class EsportsController : BaseController
    {
        [Route("/Esports")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
