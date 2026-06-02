namespace apbd_10.ViewModels;
using System.ComponentModel.DataAnnotations;

public class CreateNoteViewModel

{
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Content { get; set; } = string.Empty;

}