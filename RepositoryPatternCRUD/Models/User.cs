using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternCRUD.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage ="Please Enter your Name")]
        public string Name { get; set; } = default!;
        [Required]
        public string Gender { get; set; } = default!;
        [Required]
        public string Email { get; set; } = default!;
        [Display(Name ="Pin Code")]
        [Required]
        public int PinCode { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}
