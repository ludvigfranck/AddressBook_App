using Address_Book_ConsoleApp.Models;
using Address_Book_ConsoleApp.Services;

namespace Address_Book_ConsoleApp.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Should_Add_Contact_To_List()
        {
            ContactService contactService = new ContactService();
            var contacts = contactService.contacts;

            Contact contact = new Contact() { FirstName = "Ludde", LastName = "Franck" };
            contacts.Add(contact);

            Assert.IsTrue(contacts.Contains(contact));
        }
    }
}