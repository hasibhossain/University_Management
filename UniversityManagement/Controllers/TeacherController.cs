using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UniversityManagement.DataContext;
using UniversityManagement.Models;
using Vereyon.Web;

namespace UniversityManagement.Controllers
{
    public class TeacherController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();
        Teacher aTeacher = new Teacher();

        public ActionResult Save()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code");
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacher.CreditLeft = teacher.CreditTaken;
                db.Teachers.Add(teacher);
                db.SaveChanges();
                FlashMessage.Confirmation("Teacher's Information saved successfully");
                return RedirectToAction("Save");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code");
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "Name");
            return RedirectToAction("Save");
        }

        public JsonResult IsEmailExists(string Email)
        {
            aTeacher.Email = Email.Trim();
            if(!db.Teachers.ToList().Any(m=>m.Email.ToLower() == aTeacher.Email.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}
