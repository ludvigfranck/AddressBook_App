using Address_Book_ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_ConsoleApp.Services;

public class ContactService
{
    public List<Contact> contacts = new List<Contact>();
    private readonly FileService file = new();
    public string MenuOptions { get; set; } = null!;

    public ContactService()
    {
        file.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Contacts\content.json";
    }

    private List<Contact> PopulateList()
    {
        try
        {
            var items = JsonConvert.DeserializeObject<List<Contact>>(file.Read());
            if (items != null)
                contacts = items;

            return contacts;
        }
        catch { return null!; }
    }

    public void MainMenu()
    {
        if (MenuOptions == "1" || MenuOptions == "2" || MenuOptions == "3" || MenuOptions == "4" || MenuOptions == "5")
        {
            switch (MenuOptions)
            {
                case "1": AddContact(CreateContact()); break;
                case "2": ReadContacts(PopulateList()); break;
                case "3": FindContact(); break;
                case "4": RemoveContact(); break;

                case "5": Console.Clear(); Console.WriteLine("Goodbye! :)"); System.Environment.Exit(0); break;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Please try again...\n");
            MainMenu();
        }
    }
    private Contact CreateContact()
    {
        Console.Clear();
        Console.WriteLine("Create Contact:");

        var contact = new Contact();

        Console.Write("First Name: ");
        contact.FirstName = Console.ReadLine() ?? null!;

        Console.Write("Last Name: ");
        contact.LastName = Console.ReadLine() ?? null!;

        Console.Write("Email Address: ");
        contact.Email = Console.ReadLine() ?? null!;

        Console.Write("Phone Number: ");
        contact.PhoneNumber = Console.ReadLine() ?? null!;

        Console.Write("Home Address: ");
        contact.Address = Console.ReadLine() ?? null!;

        return contact;
    }

    private void AddContact(Contact contact)
    {
        List<Contact> _contacts = new List<Contact>();
        _contacts.Add(contact);

        PopulateList();

        contacts.AddRange(_contacts);

        Console.WriteLine($"\nContact: {contact.DisplayName} was created succesfully!");

        file.Save(JsonConvert.SerializeObject(contacts));

        Console.WriteLine("\nPress any button to continue...");
        Console.ReadKey();
    }

    private void ReadContacts(List<Contact> contacts)
    {
        Console.Clear();
        if (contacts != null)
        {
            Console.WriteLine("Contacts:");
            foreach (Contact contact in contacts) { Console.WriteLine($"{contact.DisplayName}"); }
        }
        else { Console.WriteLine("Could not find any Contacts..."); }

        Console.WriteLine("\nPress any button to continue...");
        Console.ReadKey();
    }

    private void FindContact()
    {
        Console.Clear();

        Console.Write("Type Firstname of the Contact: ");
        string firstName = Console.ReadLine() ?? "";

        PopulateList();

        Contact contact = contacts.FirstOrDefault(x => x.FirstName == firstName) ?? null!;

        if (contact == null)
        {
            Console.Clear();

            Console.WriteLine($"Contact {firstName} does not exist");
            Console.WriteLine("\nPress any button to continue...");
            Console.ReadKey();
        }
        else
        {
            Console.Clear();

            Console.WriteLine($"{contact.DisplayName}");
            Console.WriteLine($"\nFirstname: {contact.FirstName}");
            Console.WriteLine($"Lastname: {contact.LastName}");
            Console.WriteLine($"Email Address: {contact.Email}");
            Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
            Console.WriteLine($"Home Address: {contact.Address}");

            Console.WriteLine("\nPress any button to continue...");
            Console.ReadKey();
        }
    }

    private void RemoveContact()
    {
        Console.Clear();

        Console.Write("Type Firstname of the Contact: ");
        string firstName = Console.ReadLine() ?? "";

        PopulateList();

        Contact contact = contacts.FirstOrDefault(x => x.FirstName == firstName) ?? null!;

        if (contact == null)
        {
            Console.Clear();

            Console.WriteLine($"Contact {firstName} does not exist");
            Console.WriteLine("\nPress any button to continue...");
            Console.ReadKey();
        }
        else
        {
            Console.Clear();

            Console.WriteLine($"Are you sure you want to remove Contact: {contact.DisplayName}?");
            Console.WriteLine("1. Yes\n2. No");

            string choise = Console.ReadLine() ?? "";

            if (choise == "1")
            {
                Console.Clear();

                contacts.Remove(contact);
                Console.WriteLine($"Contact: {contact.DisplayName} was Removed!");

                file.Save(JsonConvert.SerializeObject(contacts));

                Console.WriteLine("\nPress any button to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();

                Console.WriteLine("Press any button to continue...");
                Console.ReadKey();
            }
        }
    }
}
