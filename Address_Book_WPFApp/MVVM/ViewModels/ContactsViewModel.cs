using Address_Book_WPFApp.Helpers;
using Address_Book_WPFApp.MVVM.Models;
using Address_Book_WPFApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Address_Book_WPFApp.MVVM.ViewModels;

internal class ContactsViewModel : ObservableObject
{
    private readonly NavigationStore _navigationStore;
    private readonly ContactService _contactService = new ContactService();
    private ObservableCollection<Contact> _contacts;
    private Contact _selectedContact;

    public ContactsViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        _contacts = _contactService.Contacts();
        _selectedContact = default(Contact)!;

        NavigateToEditContactCommand = new NavigateCommand<EditContactViewModel>(navigationStore, () => new EditContactViewModel(_navigationStore, _selectedContact));

        DeleteSelectedContactCommand = new NavigateCommand<ContactsViewModel>(_navigationStore, () =>
        {
            _contactService.DeleteContact(SelectedContact);
            return new ContactsViewModel(_navigationStore);
        });
    }
    public ObservableCollection<Contact> Contacts
    {
        get => _contacts;
        set
        {
            _contacts = value;
        }
    }

    public Contact SelectedContact
    {
        get => _selectedContact;
        set
        {
            _selectedContact = value;
        }
    }

    public ICommand NavigateToEditContactCommand { get; }
    public ICommand DeleteSelectedContactCommand { get; }
}
