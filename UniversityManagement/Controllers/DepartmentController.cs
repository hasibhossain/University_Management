using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityManagement.DataContext;
using UniversityManagement.Models;
using Vereyon.Web;

namespace UniversityManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();
        Department aDepartment = new Department();

        public ActionResult SaveDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveDepartment(Department department)
        {
            

            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                FlashMessage.Confirmation("Department saved successfully");
                return RedirectToAction("SaveDepartment");

            }
            return View();
        }


        public ActionResult ViewDetails()
        {
            List<Department> departmentList = db.Departments.ToList();
            return View(departmentList);
        }

        public JsonResult IsDeptCodeExist(string Code)
        {
            aDepartment.Code = Code.Trim();
            var dept = db.Departments.ToList();
            if (!dept.Any(department => department.Code.ToLower() == aDepartment.Code.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsDeptNameExist(string Name)
        {
            aDepartment.Name = Name.Trim();
            var dept = db.Departments.ToList();
            if (!dept.Any(department => department.Name.ToLower() == aDepartment.Name.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }


    }
}