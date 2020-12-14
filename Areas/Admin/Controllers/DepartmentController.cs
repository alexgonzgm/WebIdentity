using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebIdentity.Data;
using WebIdentity.Data.Migrations;
using WebIdentity.Models;

namespace WebIdentity.Areas.Admin.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Admin")]
    public class DepartmentController : Controller
    {   
        ApplicationDbContext db;
        public DepartmentController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> AllDepartment()
        {
            var departament = await db.Departments.ToListAsync();
            return View(departament);
        }
        public IActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            db.Add(department);
            await db.SaveChangesAsync();
            
            return RedirectToAction("AllDepartment");
        }
        public async Task<ActionResult> DepartmentDetails(int? id)
        {
            Department department =
                await db.Departments.SingleOrDefaultAsync(d => d.DepartmentId == id);
            return View(department);
        }

        
    }
}