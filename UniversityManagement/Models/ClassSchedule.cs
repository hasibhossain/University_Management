using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class ClassSchedule
    {
        [Key]
        public int ClassScheduleId { get; set; }

        [Display(Name = "Course Code")]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string CourseCode { get; set; }

        [Display(Name = "Course Name")]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string CourseName { get; set; }

        [Display(Name = "Schedule Info")]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Schedule { get; set; }
    }
}