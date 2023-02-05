using Address_Book_WPFApp.MVVM.Models;
using DevExpress.Utils.CommonDialogs.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Address_Book_WPFApp.Services;

public class ContactService
{
    private List<Contact> contacts = new();
    private readonly FileService file = new();
    private readonly NavigationStore _navigationStore = new();
    public ContactService()
    {
        PopulateList();
    }
    private List<Contact> PopulateList()
    {
        try
        {
            var items = JsonConvert.DeserializeObject<List<Contact>>(file.LoadFile());
            if (items != null)
                contacts = items;

            return contacts;
        }
        catch { return null!; }
    }

    public void AddToList(Contact _contact)
    {
        var _contacts = new List<Contact>();
        _contacts.Add(_contact);

        PopulateList();

        contacts.AddRange(_contacts);

        file.SaveFile(JsonConvert.SerializeObject(contacts));
    }

    public ObservableCollection<Contact> Contacts()
    {
        PopulateList();

        var _contacts = new ObservableCollection<Contact>();
        foreach (var contact in contacts)
            _contacts.Add(contact);

        return _contacts;
    }

    public void EditContact(Contact _selectedContact)
    {
        int index = contacts.FindIndex(x => x.Id == _selectedContact.Id);
        if (index != -1)
        {
            contacts[index] = new Contact()
            {
                Id = _selectedContact.Id,
                FirstName = _selectedContact.FirstName,
                LastName = _selectedContact.LastName,
                Email = _selectedContact.Email,
                HomeAddress = _selectedContact.HomeAddress,
                PostalCode = _selectedContact.PostalCode,
            };
        }

        file.SaveFile(JsonConvert.SerializeObject(contacts));
    }

    public void DeleteContact(Contact _selectedContact)
    {
        MessageBoxResult result = MessageBox.Show($"Do you want to Delete {_selectedContact.DisplayName}?", "DELETE", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
        if (result == MessageBoxResult.Yes)
        {
            if (contacts.Contains(_selectedContact))
            {
                contacts.Remove(_selectedContact);
            }

            file.SaveFile(JsonConvert.SerializeObject(contacts));
        }
        else
            file.SaveFile(JsonConvert.SerializeObject(contacts));
    }
}
