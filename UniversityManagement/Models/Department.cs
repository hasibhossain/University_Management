using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace UniversityManagement.Models
{
	//Department Class
    public class Department
    {
        [Key]
        //[Required(ErrorMessage = "Please Select a Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department Code is Required")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Code")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Departmrnt Code Must be 2 to 7 characters long")]
        [Remote("IsDeptCodeExist", "Department", ErrorMessage = "Code already exists!")]
        [RegularExpression(@"^[a-zA-Z0-9 @'!&(){}:;,\[\].+?/-]+", ErrorMessage = "Code is not valid")]
        public string Code { get; set; }


        [Required(ErrorMessage = "Department Name is Required")]
        [Display(Name = "Name")]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Remote("IsDeptNameExist", "Department", ErrorMessage = "Name already exists!")]
        [RegularExpression(@"^[a-zA-Z0-9 @'!&(){}:;,\[\].+?/-]+", ErrorMessage = "Name is not valid")]
        public string Name { get; set; }
    }
}