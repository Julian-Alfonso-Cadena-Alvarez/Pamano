using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pamano.Web.Controllers
{
    
        [Authorize]
        public class AdministrationController : Controller
        {
            private readonly RoleManager<IdentityRole> rolemanger;

            public AdministrationController(RoleManager<IdentityRole> rolemanger)
            {
                this.rolemanger = rolemanger;
            }
            [HttpGet]
            public IActionResult CreateRol()
            {
                return View();
            }

        }
    
}
