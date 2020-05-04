using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using UniversityManagement.DataContext;
using UniversityManagement.Models;
using Vereyon.Web;

namespace UniversityManagement.Controllers
{
    public class CourseAssignController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();
        CourseAssign aCourseAssign = new CourseAssign();

        public ActionResult Save()
        {
            ViewBag.Departments = new SelectList(db.Departments, "DepartmentId", "Name");
            return View();
        }

        public JsonResult GetTeacherByDeptId(int deptId)
        {
            var teachers = db.Teachers.Where(m => m.DepartmentId == deptId).ToList();
            return Json(teachers);
        }

        public JsonResult GetCourseByDeptId(int deptId)
        {
            var courses = db.Courses.Where(m => m.DepartmentId == deptId).ToList();
            return Json(courses);
        }

        public JsonResult GetTeacherById(int TeacherId)
        {
            var teacher = db.Teachers.FirstOrDefault(m => m.TeacherId == TeacherId);
            return Json(teacher);
        }

        public JsonResult GetCourseById(int courseId)
        {
            Course aCourse = db.Courses.FirstOrDefault(m => m.CourseId == courseId);
            return Json(aCourse);
        }

        //Course Statistics
        public ActionResult ViewCourseStatistics()
        {
            ViewBag.Departments = db.Departments.ToList();
            //ViewBag.Departments = new SelectList(db.Departments, "DepartmentId", "Name");
            return View();
        }

        public JsonResult ShowCourseStatistics(int deptId)
        {
            var courses = db.Courses.Where(m => m.DepartmentId == deptId).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }


        public JsonResult SaveCourseAssign(int teacherId, int courseId, double creditTaken, double creditLeft)
        {
            var checkAssignedCourses =
                db.CourseAssigns.Where(m => m.CourseId == courseId && m.Course.Status == true)
                    .ToList();

            if (checkAssignedCourses.Count > 0)
                return Json(false);

            else
            {
                aCourseAssign.TeacherId = teacherId;
                aCourseAssign.CourseId = courseId;
                db.CourseAssigns.Add(aCourseAssign);
                db.SaveChanges();


                var teacher = db.Teachers.FirstOrDefault(m => m.TeacherId == teacherId);

                if (teacher != null)
                {
                    teacher.CreditLeft = creditLeft;  //Need to check (courseAssign.Teacher.CreditLeft)
                    db.Teachers.AddOrUpdate(teacher);
                    db.SaveChanges();

                    var course = db.Courses.FirstOrDefault(m => m.CourseId == courseId);

                    if (course != null)
                    {
                        course.Status = true;
                        course.AssignTo = teacher.Name;
                        db.Courses.AddOrUpdate(course);
                        db.SaveChanges();

                        return Json(true);
                    }
                    else
                    {
                        return Json(false);
                    }
                }
                else
                {
                    return Json(false);
                }
            }
        }

        
    }
}