using Address_Book_WPFApp.MVVM.Models;
using Address_Book_WPFApp.Services;

namespace Address_Book_WPFApp.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Should_Remove_Contact_From_List()
        {
            ContactService contactService = new ContactService();
            var contacts = contactService.Contacts();

            Contact contact = new Contact() { FirstName = "Ludde", LastName = "Franck" };
            contactService.AddToList(contact);

            contactService.DeleteContact(contact);

            Assert.IsFalse(contacts.Contains(contact));
        }
    }
}