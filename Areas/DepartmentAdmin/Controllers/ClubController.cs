using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebIdentity.Data;
using WebIdentity.Models;
using WebIdentity.ViewModels;

namespace WebIdentity.Areas.DepartmentAdmin.Controllers
{
    [Authorize]
    [Area("DepartmentAdmin")]
    public class ClubController : Controller
    {
      
        ApplicationDbContext db;
        public ClubController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> AllClub()
        {
            var club = await db.Clubes.Include(c => c.Department).ToListAsync();
            return View(club);
        }
        public async Task<IActionResult> AddClub()
        {
            var departmentDisplay = await db.Departments.Select(x => new
            {
                Id = x.DepartmentId,
                Value = x.DepartmentName
            }).ToListAsync();
            ClubAddClubViewModel vm = new ClubAddClubViewModel();
            vm.DepartmentList = new SelectList(departmentDisplay, "Id", "Value");
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> AddClub(ClubAddClubViewModel vm)
        {
            var department = await db.
                Departments.SingleOrDefaultAsync(d => d.DepartmentId == vm.Department.DepartmentId);
            vm.Club.Department = department;
            db.Add(vm.Club);
            await db.SaveChangesAsync();
            return RedirectToAction("AllClub");
        }

        public async Task<ActionResult> RegisterClub(int? id)
        {
            //controlar si el id es nulo 
            var club = await db.Clubes.SingleOrDefaultAsync(c => c.ClubId == id);
            ViewBag.Club = club;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> RegisterClub(Registration registration)
        {
            db.Add(registration);
            var club = await db.Clubes.FindAsync(registration.ClubId);
            club.NumberOfStudents++;
            await db.SaveChangesAsync();
            //return View();
            //return ("AllClub", "Club", "DepartmentAdmin");
            return RedirectToAction("AllClub");
        }
        public async Task<IActionResult> AllRegistrationClub(int? id)
        {
            var registrationClub = await db.Registrations.Where(r => r.ClubId == id).ToArrayAsync();
            List<WebIdentity.Models.Student> classregis = new List<WebIdentity.Models.Student>();

            foreach (var e in registrationClub)
            {
                var student = await db.Students.SingleOrDefaultAsync(s => s.StudentId == e.StudentId);
                classregis.Add(student);
            }
            ViewData["club"] = db.Clubes.Find(id).ClubName;
            return View(classregis);
        }

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