using Business.Models;
using Business.Services;

namespace Business.Tests.Services;

public class FileService_Tests
{
    [Fact]
    public void GetContacts_ShouldReturnListOfContacts()
    {
        // arrange
        var fileService = new FileService();

        // act
        var result = fileService.GetContacts();

        // assert
        Assert.IsType<List<Contact>>(result);
    }

    [Fact]
    public void GetContacts_ShouldReturnListWithOneContactItem()
    {
        // arrange
        var fileService = new FileService(fileName: "fslist.json");
        var contactList = new List<Contact>();
        var newContact = new Contact()
        {
            Id = Guid.NewGuid(),
            FirstName = "TestNamn",
            LastName = "TestEfternamn",
        };
        contactList.Add(newContact);
        fileService.SaveToFile(contactList);

        // act
        var result = fileService.GetContacts();

        // assert
        Assert.True(result.Count() == 1);
    }
}
