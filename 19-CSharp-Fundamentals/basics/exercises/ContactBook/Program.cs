using ContactBookApp.Models;
using ContactBookApp.Services;

var service = new ContactService("contacts.json");
bool running = true;

while (running)
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Add contact");
    Console.WriteLine("2. List contacts");
    Console.WriteLine("3. Get by name");
    Console.WriteLine("4. Remove by name");
    Console.WriteLine("5. Exit");
    Console.Write("Selection: ");

    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.Write("Enter name: ");
            string? name = Console.ReadLine();
            Console.Write("Enter email: ");
            string? email = Console.ReadLine();
            Console.Write("Enter phone: ");
            string? phone = Console.ReadLine();
            service.AddContact(new Contact { Name = name ?? "", Email = email ?? "", Phone = phone ?? "" });
            break;

        case "2":
            service.ListContacts();
            break;

        case "3":
            Console.Write("Enter name: ");
            string? getName = Console.ReadLine();
            service.GetByName(getName ?? "");
            break;

        case "4":
            Console.Write("Enter name: ");
            string? removeName = Console.ReadLine();
            service.RemoveByName(removeName ?? "");
            break;

        case "5":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid selection");
            break;
    }

    Console.WriteLine();
}