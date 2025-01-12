using Business.Models;

namespace Business.Services;
public class ContactService
{
    private readonly FileService _fileService;
    private List<Contact> _contacts = [];

    public ContactService(FileService fileService)
    {
        _fileService = fileService;
    }

    public Guid GenerateId()
    {
        return Guid.NewGuid();
    }

    public bool Add(Contact contact)
    {
        try
        {
            contact.Id = GenerateId();
            _contacts.Add(contact);
            _fileService.SaveToFile(_contacts);
            return true;
        }
        catch { return false; }

    }

    public IEnumerable<Contact> GetAllContacts()
    {
        _contacts = _fileService.GetContacts();
        return _contacts;
    }
}
