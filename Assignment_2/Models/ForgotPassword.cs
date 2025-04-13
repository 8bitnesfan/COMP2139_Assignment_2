using System.ComponentModel.DataAnnotations;
namespace Assignment_1.Models;

public class ForgotPasswordModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
}