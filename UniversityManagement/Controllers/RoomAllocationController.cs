using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UniversityManagement.DataContext;
using UniversityManagement.Models;
using Vereyon.Web;

namespace UniversityManagement.Controllers
{
    public class RoomAllocationController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();
        RoomAllocation roomAllocation = new RoomAllocation();

        public ActionResult Allocate()
        {
            ViewBag.Departments = new SelectList(db.Departments, "DepartmentId", "Name");
            ViewBag.Courses = new SelectList(db.Courses, "CourseId", "Name");
            ViewBag.Days = new SelectList(db.Days, "DayId", "Name");
            ViewBag.Rooms = new SelectList(db.Rooms, "RoomId", "Name");
            return View();
        }


        public JsonResult GetCoursesByDeptId(int deptId)
        {
            var courses = db.Courses.Where(m => m.DepartmentId == deptId).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }


        public JsonResult SaveRoomSchedule(int departmentId, int courseId, int roomId, int dayId, double startTime, double endTime)
        {
            var scheduleList = db.RoomAllocations.Where(m => m.RoomId == roomId && m.DayId == dayId && m.RoomStatus == "Allocated").ToList();
            if (scheduleList.Count == 0)
            {
                roomAllocation.RoomStatus = "Allocated";
                roomAllocation.CourseId = courseId;
                roomAllocation.RoomId = roomId;
                roomAllocation.DayId = dayId;
                roomAllocation.StartTime = startTime;
                roomAllocation.EndTime = endTime;
                db.RoomAllocations.Add(roomAllocation);
                db.SaveChanges();
                return Json(true);
            }
            else
            {
                bool status = false;
                foreach (var allocation in scheduleList)
                {
                    if ((startTime >= allocation.StartTime && startTime < allocation.EndTime)
                         || (endTime > allocation.StartTime && endTime <= allocation.EndTime) && roomAllocation.RoomStatus == "Allocated")
                    {
                        status = true;
                    }
                }
                if (status == false)
                {
                    roomAllocation.RoomStatus = "Allocated";
                    db.RoomAllocations.Add(roomAllocation);
                    db.SaveChanges();
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }

        }


        public ActionResult UnAllocatedClassRoom()
        {
            return View();
        }

        public JsonResult UnAllocateAllRooms(bool decision)
        {
            var roomStatus = db.RoomAllocations.Where(m => m.RoomStatus == "Allocated").ToList();
            if (roomStatus.Count == 0)
            {
                return Json(false);
            }
            else
            {
                foreach (var room in roomStatus)
                {
                    room.RoomStatus = "";
                    db.RoomAllocations.AddOrUpdate(room);
                    db.SaveChanges();

                }
                return Json(true);
            }

        }

    }
}
