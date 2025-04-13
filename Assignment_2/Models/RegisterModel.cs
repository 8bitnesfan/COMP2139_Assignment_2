using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models;

public class RegisterModel
{
    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; }

    [Display(Name = "Contact Information (optional)")]
    public string ContactInfo { get; set; }

    [Display(Name = "Preferred Categories (optional)")]
    public string PreferredCategories { get; set; }
}