using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Model
{
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", 
         ErrorMessage = "Characters are not allowed.")]
        [Required]
        public string Name { get; set; }
        [Display(Name= "Display Order")]
        [Range(1,1000, ErrorMessage ="Display order must be in range 1-1000")]
        public int DisplayOrder { get; set; }

    }
}
