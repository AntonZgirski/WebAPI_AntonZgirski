using System.ComponentModel.DataAnnotations;

namespace Lab16_WebAPI.Model
{
  public class Contact
  {
    [Key]
    public Guid Id { get; set; }
    public string FName { get; set; }
    public string SName { get; set; }
    public int Age { get; set; }
    public string WorkPlace { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
  }
}
