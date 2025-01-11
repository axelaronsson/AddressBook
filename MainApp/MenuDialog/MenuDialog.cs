using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using Business.Models;

namespace MainApp.MenuDialog;

internal class MenuDialog
{
    public void ShowMenu()
    {
        bool isRunning = true;
        do
        {
            Console.Clear();
            Console.WriteLine("1. Visa alla kontakter");
            Console.WriteLine("2. Lägg till kontakter");
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
        Console.ReadKey();
    }

    public void ShowContacts()
    {
        Console.WriteLine("Showing all contacts..");
        Console.ReadKey();
    }
}
