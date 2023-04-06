using Lab16_WebAPI.Data;
using Lab16_WebAPI.Model;

namespace Lab16_WebAPI.Service
{
  public class ContactService : IContactService
  {
    private readonly ApiTestContext _context; 

    public ContactService(ApiTestContext context)
    {
      _context = context;
    }

    public ContactService()
    {
            
    }

    public void AddContact(Contact contact)
    {
      throw new NotImplementedException();
    }

    public void DeleteContact(Guid id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Contact> GetAllContacts()
    {
      throw new NotImplementedException();
    }

    public Contact GetContact(Guid id)
    {
      throw new NotImplementedException();
    }
  }
}
