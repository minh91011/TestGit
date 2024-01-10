using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Excercise2_PRN231_MinhNNHE161638.Model
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(100)]
        public string StudentName { get; set; }
    }
}
