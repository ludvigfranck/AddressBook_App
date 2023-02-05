using Address_Book_ConsoleApp.Services;

ContactService contactService = new ContactService();

Console.WriteLine("Welcome to the Program!");

do
{
    Console.WriteLine("1. Create Contact\n2. Read Contacts\n3. Find Contact\n4. Delete Contact\n5. Exit Program");
    Console.Write("Pick from the alteratives above: ");

    contactService.MenuOptions = Console.ReadLine() ?? null!;
    contactService.MainMenu();

    Console.Clear();
}
while (contactService.MenuOptions != "5");