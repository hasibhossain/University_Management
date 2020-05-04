using System.Linq;
using System.Web.Mvc;
using UniversityManagement.DataContext;
using UniversityManagement.Models;
using Vereyon.Web;

namespace UniversityManagement.Controllers
{
    public class StudentController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        public ActionResult Register()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code");
            return View();
        }

        [HttpPost]
        public ActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                student.RegNo = GetStudentRegNo(student);
                db.Students.Add(student);
                db.SaveChanges();
                FlashMessage.Confirmation("Registration Successfull. Your Registration number is: " + student.RegNo);
                return RedirectToAction("Register");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code");
            return RedirectToAction("Register");
        }


        public string GetStudentRegNo(Student aStudent)
        {
            var studentCount =
                db.Students.Count(m => (m.DepartmentId == aStudent.DepartmentId) && (m.Date.Year == aStudent.Date.Year)) +
                1;

            var aDepartment = db.Departments.FirstOrDefault(m => m.DepartmentId == aStudent.DepartmentId);

            string leadingZero = "";
            int length = 3 - studentCount.ToString().Length;
            for (int i = 0; i < length; i++)
            {
                leadingZero += "0";
            }

            string studentRegNo = aDepartment.Code + "-" + aStudent.Date.Year + "-" + leadingZero + studentCount;
            return studentRegNo;
        }

        public JsonResult IsEmailExists(string Email)
        {
            Email.Trim();
            if(!db.Students.ToList().Any(m => m.Email.ToLower() == Email.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}
