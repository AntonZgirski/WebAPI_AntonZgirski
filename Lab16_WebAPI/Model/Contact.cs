using System.ComponentModel.DataAnnotations;

namespace Lab16_WebAPI.Model
{
  public class Contact
  {
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
  }
}
