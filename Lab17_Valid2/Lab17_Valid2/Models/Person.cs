using System.ComponentModel.DataAnnotations;

namespace Lab17_Valid2.Models
{
  public class Person
  {
    [Key]
    public int PersonId { get; set; }
    [Required(ErrorMessage = "First Name cannot be empty!")]
    [StringLength(100)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Second Name cannot be empty!")]
    [StringLength(100)]
    [Display(Name = "Second Name")]
    public string SecondName { get; set; }

    [Required(ErrorMessage = "Age cannot be empty!")]
    public string Age { get; set; }

    [StringLength(100)]
    public string? Address { get; set; }

    [StringLength(100)]
    public string? Work { get; set; }

    [StringLength(100)]
    public string? Education { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Phone]
    public string? PhoneNumber { get; set; }

    [StringLength(100)]
    public string? Pasport { get; set; } 
  }
}
