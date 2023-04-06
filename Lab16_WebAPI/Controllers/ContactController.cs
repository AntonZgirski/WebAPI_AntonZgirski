using Lab16_WebAPI.Data;
using Lab16_WebAPI.Model;
using Lab16_WebAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace Lab16_WebAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ContactController : Controller
  {
    private readonly IContactService _context;

    public ContactController(IContactService context)
    {
      _context = context;
    }

    [HttpGet]
    public IEnumerable<Contact> Get()
    {
      return _context.GetAllContacts();
    }

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult GetContact([FromRoute] Guid id)
    {
      var contact = _context.GetContact(id);
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

      _context.AddContact(contact);

      return _context.GetAllContacts();
    }

    [HttpPut]
    [Route("{id:guid}")]
    public IActionResult Put([FromRoute] Guid id , AddContactViewModel viewModel)
    {
      var contact = _context.GetContact(id);

      if(contact != null) 
      {
        contact.FName = viewModel.FName;
        contact.SName = viewModel.SName;
        contact.Age = viewModel.Age;
        contact.WorkPlace = viewModel.WorkPlace;
        contact.Email = viewModel.Email;  
        contact.Phone = viewModel.Phone;
        contact.Address = viewModel.Address;
        
        return Ok(_context.GetAllContacts());
      }

      return NotFound();
    }


    [HttpDelete]
    [Route("{id:guid}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
      var contact = _context.GetContact(id);
      if (contact != null)
      {
        _context.DeleteContact(id);        

        return Ok(_context.GetAllContacts());
      }
      return NotFound();
    }
  }
}