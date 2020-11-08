using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class Roles : Controller
    {
        RoleManager<IdentityRole> _user;

        public Roles(RoleManager<IdentityRole> user )
        {
            _user = user;
        }
        public IActionResult Index()
        {
            var roles = _user.Roles.ToList();
            return View(roles);
        }
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole roles)
        {
            await _user.CreateAsync(roles);
            return RedirectToAction("Index");
        }
    }
}
