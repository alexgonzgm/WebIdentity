using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebIdentity.Data;
using WebIdentity.Models;
using WebIdentity.ViewModels;

namespace WebIdentity.Areas.Admin.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
       



        ApplicationDbContext _db;
        public UsersController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            this._db = db;
            _userManager = userManager;
         
           
        }
        public async Task<IActionResult> AllUsers()
        {
            List<string> list = new List<string>();
            
          
            var users = await _userManager.Users.ToListAsync();
            foreach (var user in users)
            {

                var rol = await _userManager.GetRolesAsync(user);
                list.Add(rol[0].ToString());
                
                
            }
            

            return View(list);
        }
    }
}