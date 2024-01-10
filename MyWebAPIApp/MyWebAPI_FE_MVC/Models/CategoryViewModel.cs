using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyWebAPI_FE_MVC.Models
{
    public class CategoryViewModel
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }     
    }
}
