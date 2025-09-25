using DevSquare.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace DevSquare.UI.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "User name is required.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
