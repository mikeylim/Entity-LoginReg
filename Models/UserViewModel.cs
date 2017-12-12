using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LoginReg.Models;

namespace LoginReg.Models
{
    public class UserViewModel : BaseEntity
    {   
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "First Name field must not be empty.")]
        [MinLength(2, ErrorMessage = "First Name must be more than 2 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [Display(Name="First Name: ")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Last Name field must not be empty.")]
        [MinLength(2, ErrorMessage = "Last Name must be more than 2 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [Display(Name="Last Name: ")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Email field must not be empty.")]
        [EmailAddress]
        [Display(Name="Email: ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field must not be empty.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password has to be more than 8 characters")]
        [Display(Name="Password: ")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm Password field must not be empty.")]
        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password: ")]
        public string CFPassword { get; set; }
    }
}