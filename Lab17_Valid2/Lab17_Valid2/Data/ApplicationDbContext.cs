using Lab17_Valid2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab17_Valid2.Data
{
  public class ApplicationDbContext : IdentityDbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; } 
  }
}