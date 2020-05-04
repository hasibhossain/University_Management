using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class EnrollCourse
    {
        [Key]
        public int EnrollCourseId { get; set; }

        //Foreign Key
        [Required(ErrorMessage = "This field is Required")]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        //Foreign Key
        [Required(ErrorMessage = "This field is Required")]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        //[Required(ErrorMessage ="Please Select a Date")]
        public DateTime EnrollDate { get; set; }

        public string CourseGrade { get; set; }
    }
}