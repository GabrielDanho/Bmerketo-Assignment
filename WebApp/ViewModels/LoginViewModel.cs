using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApp.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Du måste ange en e.postadress")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "E-postadress")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Du måste ange ett Lösenord")]
    [DataType(DataType.Password)]
    [Display(Name = "Lösenord")]
    public string Password { get; set; } = null!;
}
