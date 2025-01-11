using Business.Models;

namespace Business.Services;
public class ContactService
{
    private List<Contact> _contacts = [];

    public void Add(Contact contact)
    {
        _contacts.Add(contact);
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        return _contacts;
    }
}
