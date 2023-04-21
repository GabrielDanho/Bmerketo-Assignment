using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Du måste ange ett förnamn")]
    [RegularExpression(@"^[a-öA-A]+(?:[ é'-][a-öA-Ö]+)$", ErrorMessage = "Du måste ange ett giltigt förnamn")]
    [Display(Name = "Förnamn")]
    public string FirstName { get; set; } = null!;



    [Required(ErrorMessage = "Du måste ange ett efternamn")]
    [RegularExpression(@"^[a-öA-A]+(?:[ é'-][a-öA-Ö]+)$", ErrorMessage = "Du måste ange ett giltigt efternamn")]
    [Display(Name = "Efternamn")]
    public string LastName { get; set; } = null!;



    [Required(ErrorMessage = "Du måste ange en e-postadress")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-aZ-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Du måste ange en giltig e-postadress")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "E-postadress")]   
    public string Email { get; set; } = null!;



    [Required(ErrorMessage = "Du måste ange ett lösenord")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "Du måste ange ett giltigt lösenord")]
    [DataType(DataType.Password)]
    [Display(Name = "Lösenord")]
    public string Password { get; set; } = null!;



    [Required(ErrorMessage = "Du måste bekräfta lösenordet")]
    [Compare(nameof(Password), ErrorMessage = "Lösenorden matchar inte")]
    [DataType(DataType.Password)]
    [Display(Name = "Bekräfta lösenord")]
    public string ConfirmPassword { get; set; } = null!;



    [Display(Name = "Gatunamn")]
    public string? StreetName { get; set; }


    [Display(Name = "Postnummer")]
    public string? PostalCode { get; set; }


    [Display(Name = "Stad")]
    public string? City { get; set; }



    public static implicit operator UserEntity(RegisterViewModel registerViewModel)
    {
        var userEntity = new UserEntity { Email = registerViewModel.Email };
        userEntity.GenerereateSecurePassword(registerViewModel.Password);
        return userEntity;
    }

    public static implicit operator ProfileEntity(RegisterViewModel registerViewModel)
    {
        return new ProfileEntity
        {
            FirstName = registerViewModel.FirstName,
            LastName = registerViewModel.LastName,
            StreetName = registerViewModel.StreetName,
            PostalCode = registerViewModel.PostalCode,
            City = registerViewModel.City,
        };
    }
}
