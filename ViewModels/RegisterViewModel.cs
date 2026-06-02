namespace apbd_10.ViewModels;
using System.ComponentModel.DataAnnotations;

public class RegisterViewModel

{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

}