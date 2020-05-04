using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.DataContext;
using UniversityManagement.Models;
using Vereyon.Web;

namespace UniversityManagement.Controllers
{
    public class EnrollCoursesController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();
        EnrollCourse enrollCourse = new EnrollCourse();
        EnrollCourse bEnrollCourse = new EnrollCourse();
        Grade aGrade = new Grade();


        public ActionResult Enroll()
        {
            ViewBag.Registrations = new SelectList(db.Students, "StudentId", "RegNo");
            return View();
        }


        public JsonResult GetStudentById(int studentId)
        {
            var students = db.Students.Where(m => m.StudentId == studentId).First();
            return Json(students, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCoursesByDeptId(int deptId)
        {
            var courses = db.Courses.Where(m => m.Department.DepartmentId == deptId).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsAlreadyEnrolled(int studentId, int courseId)
        {
            var enrollCourses = db.EnrollCourses.Where(m => m.StudentId == studentId && m.Course.CourseId == courseId);

            if (enrollCourses.Count() == 0)
            {
                return Json(false);
            }
            return Json(true);
        }


        
        public JsonResult EnrollStudentToCourse(int studentId, int CourseId, DateTime EnrollDate)
        {

            var enrollCourseList = db.EnrollCourses.Where(m => m.StudentId == studentId && m.CourseId == CourseId).ToList();

            

            if (enrollCourseList.Count() == 1)
            {
                var id = enrollCourseList[0].EnrollCourseId;
                var date = enrollCourseList[0].EnrollDate;
                enrollCourse.StudentId = studentId;
                enrollCourse.CourseId = CourseId;
                enrollCourse.EnrollCourseId = id;
                enrollCourse.EnrollDate = date;
                db.EnrollCourses.AddOrUpdate(enrollCourse);

            }
            else
            {
                enrollCourse.StudentId = studentId;
                enrollCourse.CourseId = CourseId;
                enrollCourse.EnrollDate = EnrollDate;

                db.EnrollCourses.Add(enrollCourse);
            }

            db.SaveChanges();
            return Json(true);
        }



        public ActionResult SaveResult()
        {
            ViewBag.Registrations = new SelectList(db.Students, "StudentId", "RegNo");
            ViewBag.GradeList = new SelectList(db.Grades, "GradeId", "Name");

            return View();
        }

        public JsonResult SaveStudentResult(int studentId, int courseId, string courseGradeId)
        {

            var grades = db.EnrollCourses.Where(m => m.StudentId == studentId && m.CourseId == courseId).ToList();

                if (grades.Count() == 1)
                {
                    var id = grades[0].EnrollCourseId;

                    bEnrollCourse = db.EnrollCourses.FirstOrDefault(m => m.EnrollCourseId == id);

                    int gradeId = Convert.ToInt32(courseGradeId);
                    aGrade = db.Grades.Find(gradeId);

                    bEnrollCourse.CourseGrade = aGrade.Name;
                    db.EnrollCourses.AddOrUpdate(bEnrollCourse);
                }
            else
            {
                var id = grades[0].EnrollCourseId;

                bEnrollCourse = db.EnrollCourses.FirstOrDefault(m => m.EnrollCourseId == id);

                int gradeId = Convert.ToInt32(courseGradeId);
                aGrade = db.Grades.Find(gradeId);

                bEnrollCourse.CourseGrade = aGrade.Name;
                db.EnrollCourses.AddOrUpdate(bEnrollCourse);
            }
                db.SaveChanges();
                return Json(true);
        }

        public JsonResult GetCoursesByStudentId(int studentId)
        {
            var courses = db.EnrollCourses.Where(m => m.StudentId == studentId).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ViewResult()
        {
            ViewBag.Registrations = new SelectList(db.Students, "StudentId", "RegNo");

            ViewBag.EnrollCourses = db.EnrollCourses.ToList();
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");
            //ViewBag.StudentList = db.Students.ToList();
            return View();
        }


    }
}
