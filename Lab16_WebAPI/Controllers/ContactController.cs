using Lab16_WebAPI.Data;
using Lab16_WebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace Lab16_WebAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ContactController : Controller
  {
    private readonly ApiTestContext _context;

    public ContactController(ApiTestContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IEnumerable<Contact> Get()
    {
      return _context.Contacts.ToList();
    }

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult GetContact([FromRoute] Guid id)
    {
      var contact = _context.Contacts.Find(id);
      if (contact != null)
      {
        return Ok(contact);
      }

      return NotFound();
    }


    [HttpPost]
    public IEnumerable<Contact> Post(AddContactViewModel viewModel)
    {
      var contact = new Contact()
      {
        Id = Guid.NewGuid(),
        FName = viewModel.FName,
        SName = viewModel.SName,
        Age = viewModel.Age,
        WorkPlace = viewModel.WorkPlace,
        Email = viewModel.Email,
        Phone = viewModel.Phone,
        Address = viewModel.Address
      };

      _context.Contacts.Add(contact);
      _context.SaveChanges();

      return _context.Contacts.ToList();
    }

    [HttpPut]
    [Route("{id:guid}")]
    public IActionResult Put([FromRoute] Guid id , AddContactViewModel viewModel)
    {
      var contact = _context.Contacts.Find(id);

      if(contact != null) 
      {
        contact.FName = viewModel.FName;
        contact.SName = viewModel.SName;
        contact.Age = viewModel.Age;
        contact.WorkPlace = viewModel.WorkPlace;
        contact.Email = viewModel.Email;  
        contact.Phone = viewModel.Phone;
        contact.Address = viewModel.Address;
        _context.SaveChanges();
        return Ok(_context.Contacts.ToList());
      }

      return NotFound();
    }


    [HttpDelete]
    [Route("{id:guid}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
      var contact = _context.Contacts.Find(id);
      if (contact != null)
      {
        _context.Contacts.Remove(contact);
        _context.SaveChanges();

        return Ok(_context.Contacts.ToList());
      }
      return NotFound();
    }
  }
}