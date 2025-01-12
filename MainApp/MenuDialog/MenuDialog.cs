using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using Business.Models;
using Business.Services;

namespace MainApp.MenuDialog;

internal class MenuDialog
{
    private readonly ContactService _contactService;

    public MenuDialog(ContactService contactService)
    {
        _contactService = contactService;
    }
    public void ShowMenu()
    {
        bool isRunning = true;
        do
        {
            Console.Clear();
            Console.WriteLine("1. Visa alla kontakter");
            Console.WriteLine("2. Lägg till kontakt");
            Console.WriteLine("q. Avsluta");
            Console.Write("Välj ett alternativ: ");
            var menuOption = Console.ReadLine();

            switch (menuOption)
            {
                case "1":
                    ShowContacts();
                    break;
                case "2":
                    AddContact();
                    break;
                case "q":
                    isRunning = false;
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine($"Alternativet existerar inte. Tryck på valfri tanget för att komma till menyn.");
                    Console.ReadKey();
                    break;
            }
        }
        while (isRunning);
    }

    public void AddContact()
    {
        Console.Clear();
        var contact = new Contact();

        Console.Write("Ange förnamn: ");
        contact.FirstName = Console.ReadLine()!;
        Console.Write("Ange efternamn: ");
        contact.LastName = Console.ReadLine()!;
        Console.Write("Ange e-post: ");
        contact.Email = Console.ReadLine()!;
        Console.Write("Ange telefonnummer: ");
        contact.Phone = Console.ReadLine()!;
        Console.Write("Ange gatuadress: ");
        contact.Address = Console.ReadLine()!;
        Console.Write("Ange postnummer: ");
        contact.PostalCode = Console.ReadLine()!;
        Console.Write("Ange ort: ");
        contact.City = Console.ReadLine()!;



        Console.WriteLine($"Adding contact..");
        _contactService.Add(contact);
        Console.ReadKey();
    }

    public void ShowContacts()
    {
        Console.Clear();
        Console.WriteLine("Showing all contacts..");
        var allContacts = _contactService.GetAllContacts();
        foreach (var item in allContacts)
        {
            Console.WriteLine($"Id: {item.Id}");
            Console.WriteLine($"Förnamn: {item.FirstName}");
            Console.WriteLine($"Efternamn: {item.LastName}");
            Console.WriteLine($"E-post: {item.Email}");
            Console.WriteLine($"Telefonnummer: {item.Phone}");
            Console.WriteLine($"Gatuadress: {item.Address}");
            Console.WriteLine($"Postnummer: {item.PostalCode}");
            Console.WriteLine($"Ort: {item.City}");
            Console.WriteLine("");
        }
        Console.ReadKey();
    }
}
