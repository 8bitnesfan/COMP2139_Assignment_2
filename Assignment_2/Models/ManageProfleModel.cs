using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models;

public class ManageProfileViewModel
{
    [Required]
    [Display(Name = "Full Name")]
    public string FullName { get; set; }

    [Display(Name = "Contact Information")]
    public string ContactInfo { get; set; }

    [Display(Name = "Preferred Categories")]
    public string PreferredCategories { get; set; }
}