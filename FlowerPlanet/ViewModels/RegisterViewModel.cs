using System.ComponentModel.DataAnnotations;

namespace FlowerPlanet.ViewModels;

public class RegisterViewModel
{
    [Display(Name = "Email Address")]
    [Required(ErrorMessage ="Email address is required")]
    public string EmailAddress { get; set; }
    [Required]
    //Chcek for datatype/passwordDatatypee
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Display(Name = "Please Confirm password")]
    [Required(ErrorMessage ="Must confirm password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage ="Password does not match")]
    public string ConfirmPassword { get; set; }
}
