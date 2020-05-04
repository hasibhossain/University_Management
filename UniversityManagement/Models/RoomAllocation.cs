using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagement.Models
{
    public class RoomAllocation
    {
        [Key]
        public int RoomAllocationId { get; set; }

        //Foreign Key
        [Required(ErrorMessage = "Course is Required")]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        //Foreign Key
        [Required(ErrorMessage = "The Field Room is Required")]
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

        //Foreign Key
        [Required(ErrorMessage = "The Field Day is Required")]
        public int DayId { get; set; }
        [ForeignKey("DayId")]
        public virtual Day Day { get; set; }

        [Required(ErrorMessage = "The Field Start Time is Required")]
        public double StartTime { get; set; }

        [Required(ErrorMessage = "The Field End Time is Required")]
        public double EndTime { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string RoomStatus { get; set; }
    }
}