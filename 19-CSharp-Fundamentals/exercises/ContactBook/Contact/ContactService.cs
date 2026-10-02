using System.Runtime.InteropServices;
using System.Text.Json;
using ContactBookApp.Models;

namespace ContactBookApp.Services;

public class ContactService
{
    private readonly string _filePath;

    public ContactService(string filePath)
    {
        _filePath = filePath;
    }

    public void AddContact(Contact contact)
    {
        var contacts = LoadContacts();
        contacts.Add(contact);
        SaveContacts(contacts);
        Console.WriteLine("Contact added.");
    }

    public void ListContacts()
    {
        var contacts = LoadContacts();
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts found.");
            return;
        }

        foreach (var c in contacts)
        {
            Console.WriteLine($"{c.Name} - {c.Email} - {c.Phone}");
        }
    }

    public void GetByName(string name)
    {
        var contacts = LoadContacts();
        var found = contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (found is null)
        {
            Console.WriteLine("Contact not found.");
        }
        else
        {
            Console.WriteLine($"{found.Name} – {found.Email} – {found.Phone}");
        }
    }

    public void RemoveByName(string name)
    {
        var contacts = LoadContacts();
        var removed = contacts.RemoveAll(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        SaveContacts(contacts);

        if (removed > 0)
            Console.WriteLine("Contact removed.");
        else
            Console.WriteLine("No contact found with that name.");
    }

    private List<Contact> LoadContacts()
    {
        // wrap in try catch block (IOException || JsonException)
        {
            // if file does not exist reutrn empty List<Contact>
            //
            // read json from file


            // Deserialize content into List<Contact> and return or return empty List<Contact>
            return new List<Contact>();
        }
    }

    private void SaveContacts(List<Contact> contacts)
    {
        // wrap in try catch block (IOException || UnauthorizedAccessException)
        //
        // Serialize contact into json
        // write to file
    }
}