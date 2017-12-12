using System.ComponentModel.DataAnnotations;

namespace LoginReg.Models
{
    public class LogUser : BaseEntity
    {
        [Required(ErrorMessage = "Email field must not be empty.")]
        [EmailAddress]
        [Display(Name="Email: ")]
        public string LogEmail { get; set; }

        [Required(ErrorMessage = "Password field must not be empty.")]
        [DataType(DataType.Password)]
        [Display(Name="Password: ")]
        public string LogPassword { get; set; }
    }
}