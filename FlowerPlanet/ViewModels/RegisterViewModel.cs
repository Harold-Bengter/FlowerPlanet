using System.ComponentModel.DataAnnotations;

namespace FlowerPlanet.ViewModels;

public class RegisterViewModel
{
    [Display(Name = "Email Address")]
    [Required(ErrorMessage ="Email address is required")]
    public string EmailAddress { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Display(Name = "Please Confirm password")]
    [Required(ErrorMessage ="Password cannot be blank. Please enter password")]
    public string ConfirmPassword { get; set; }
}
