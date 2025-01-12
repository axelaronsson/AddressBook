using Business.Models;
using Business.Services;

namespace Business.Tests.Services;
public class ContactService_Tests
{
    [Fact]
    public void GenerateId_ShouldReturnAGuid()
    {
        // arrange
        var fileService = new FileService();
        var contactService = new ContactService(fileService);

        // act
        var result = contactService.GenerateId();

        // assert
        Assert.IsType<Guid>(result);
    }
    [Fact]
    public void GetAllContacts_ShouldReturnList()
    {
        // arrange
        var fileService = new FileService();
        var contactService = new ContactService(fileService);

        // act
        var result = contactService.GetAllContacts();

        // assert
        Assert.NotNull(result);
        Assert.IsType<List<Contact>>(result);

    }

    [Fact]
    public void AddContact_ShouldReturnTrue()
    {
        // arrange
        var fileService = new FileService();
        var contactService = new ContactService(fileService);
        var contact = new Contact()
        {
            Id = Guid.NewGuid(),
            FirstName = "Namn",
            LastName = "Efternamn"
        };

        // act
        var result = contactService.Add(contact);

        // assert
        Assert.True(result);
    }

}
