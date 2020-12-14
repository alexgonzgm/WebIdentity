using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebIdentity.Data;
using WebIdentity.Models;

namespace WebIdentity.Areas.Student.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Student")]
    public class StudentController : Controller
    {
        ApplicationDbContext db;
        public StudentController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> AllStudent()
        {
            var student = await db.Students.ToListAsync();
            return View(student);
        }
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(WebIdentity.Models.Student student)
        {
            db.Add(student);
            await db.SaveChangesAsync();
            return RedirectToAction("AllStudent");
        }
      
    }
}