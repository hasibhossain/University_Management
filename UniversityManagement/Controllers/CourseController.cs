using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using UniversityManagement.DataContext;
using UniversityManagement.Models;
using Vereyon.Web;

namespace UniversityManagement.Controllers
{
    public class CourseController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();
        Course aCourse = new Course();

        public ActionResult Save()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name");
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "Name");
            return View();
        }

        
        [HttpPost]
        public ActionResult Save(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                FlashMessage.Confirmation("Course Information saved successfully");
                return RedirectToAction("Save");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name");
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "Name");
            return RedirectToAction("Save");
        }

        
        public JsonResult IsCodeUnique(string Code)
        {
            Code.Trim();
            if (!db.Courses.ToList().Any(m => m.Code.ToLower() == Code.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsNameUnique(string Name)
        {
            Name.Trim();
            if (!db.Courses.ToList().Any(m => m.Name.ToLower() == Name.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UnassignCourses()
        {
            return View();
        }


        public JsonResult UnassignAllCourses(bool decision)
        {
            var courses = db.Courses.Where(m => m.Status == true).ToList();
            if (courses.Count == 0)
            {
                return Json(false);
            }
            else
            {
                foreach (var course in courses)
                {
                    course.Status = false;
                    course.AssignTo = "";
                    db.Courses.AddOrUpdate(course);
                    db.SaveChanges();
                }
                return Json(true);

            }
        }

    }
}
