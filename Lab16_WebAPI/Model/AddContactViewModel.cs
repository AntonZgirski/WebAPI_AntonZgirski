using System.ComponentModel.DataAnnotations;

namespace Lab16_WebAPI.Model
{
  public class AddContactViewModel
  {
    [Required(ErrorMessage ="First Name cannot be empty!")]
    [StringLength(100)]
    [Display(Name = "First Name")]
    public string FName { get; set; }

    [Required(ErrorMessage = "Second Name cannot be empty!")]
    [StringLength(100)]
    [Display(Name ="Second Name")]
    public string SName { get; set; }

    [Required(ErrorMessage = "Age cannot be empty!")]
    [Range(0,100)]
    [Display(Name = "Age")]
    public int Age { get; set; }

    [StringLength(100)]
    public string WorkPlace { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    [Phone]
    public string Phone { get; set; }

    [StringLength (100)]
    public string Address { get; set; }
  }
}
