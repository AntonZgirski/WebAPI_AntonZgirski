using Lab16_WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace Lab16_WebAPI.Data
{
  public class ApiTestContext : DbContext
  {
    public ApiTestContext(DbContextOptions option) : base(option)
    { 
    }

    public DbSet<Contact> Contacts { get; set; } 
  }
}
