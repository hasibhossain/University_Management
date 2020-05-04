using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagement.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course Code is Required")]
        [Display(Name = "Course Code")]
        [Column(TypeName = "varchar")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Course Code Must be 5 characters long")]
        [Remote("IsCodeUnique", "Course", ErrorMessage = "Code already exists!")]
        [RegularExpression(@"^[a-zA-Z0-9 @'!&(){}:;,\[\].+?/-]+", ErrorMessage = "Code is not valid")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Course Name is Reqired")]
        [Display(Name = "Course Name")]
        [Column(TypeName = "varchar")]
        [Remote("IsNameUnique", "Course", ErrorMessage = "Name already exists!")]
        [RegularExpression(@"^[a-zA-Z0-9 @'!&(){}:;,\[\].+?/-]+", ErrorMessage = "Name is not valid")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Display(Name = "Course Credit")]
        [Range(0.5, 5.0, ErrorMessage = "Credit must be within 0.5 to 5.0")]
        public double Credit { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Display(Name = "Description")]
        [Column(TypeName = "varchar")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string AssignTo { get; set; }

        public bool Status { get; set; }

        //Foreign Key
        [Required(ErrorMessage = "This field is Required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        //Foreign Key
        [Required(ErrorMessage = "This field is Required")]
        [Display(Name = "Semester")]
        public int SemesterId { get; set; }
        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }


    }
}