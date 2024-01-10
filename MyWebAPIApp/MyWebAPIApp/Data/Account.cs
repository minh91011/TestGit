using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPIApp.Data
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string usename { get; set; }
        [Required]
        [MaxLength(250)]
        public string password { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
    }
}
