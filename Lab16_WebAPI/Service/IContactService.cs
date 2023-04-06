using Lab16_WebAPI.Model;

namespace Lab16_WebAPI.Service
{
  public interface IContactService
  {
    IEnumerable<Contact> GetAllContacts();    
    Contact GetContact(Guid id);
    void AddContact(Contact contact);
    void DeleteContact(Guid id);
  }
}
