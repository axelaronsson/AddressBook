using Business.Models;

namespace Business.Services;
public class ContactService
{
    private readonly FileService _fileService = new FileService();
    private List<Contact> _contacts = [];

    public void Add(Contact contact)
    {
        contact.Id = Guid.NewGuid();
        _contacts.Add(contact);
        _fileService.SaveToFile(_contacts);
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        _contacts = _fileService.GetContacts();
        return _contacts;
    }
}
