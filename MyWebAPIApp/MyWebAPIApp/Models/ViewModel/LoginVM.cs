using System.ComponentModel.DataAnnotations;

namespace MyWebAPIApp.Models.ViewModel
{
    public class LoginVM
    {
        [Required]
        [MaxLength(50)]
        public string usename { get; set; }
        [Required]
        [MaxLength(250)]
        public string password { get; set; }
    }
}
