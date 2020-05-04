using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagement.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Teacher Name is Required")]
        [Display(Name = "Name")]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [Display(Name = "Email")]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Remote("IsEmailExists", "Teacher", ErrorMessage = "Email already exists!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact No is Required")]
        [Display(Name = "Contact No.")]
        [Phone]
        [StringLength(14, MinimumLength = 7, ErrorMessage = "Invalid Phone Number")]
        public string ContactNo { get; set; }

        //Foreign Key
        [Required(ErrorMessage = "Designation is Required")]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        //Foreign Key
        [Required(ErrorMessage = "Department is Required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Required(ErrorMessage = "Credit Taken is Required")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Credit Must be Non Negative Number")]
        [Display(Name = "Credit to be Taken")]
        public double CreditTaken { get; set; }

        public double CreditLeft { get; set; }
    }
}