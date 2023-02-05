using Address_Book_WPFApp.Helpers;
using Address_Book_WPFApp.MVVM.Models;
using Address_Book_WPFApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Address_Book_WPFApp.MVVM.ViewModels;

internal class EditContactViewModel : ObservableObject
{
    private readonly NavigationStore _navigationStore;
    private readonly ContactService _contactService = new ContactService();

    private Contact _selectedContact = default(Contact)!;
    public Contact SelectedContact
    {
        get { return _selectedContact; }
        set
        {
            _selectedContact = value;
        }
    }

    public EditContactViewModel(NavigationStore navigationStore, Contact contact)
    {
        _navigationStore = navigationStore;
        SelectedContact = contact;

        ApplyContactEditCommand = new NavigateCommand<ContactsViewModel>(_navigationStore, () =>
        {
            _contactService.EditContact(SelectedContact);
            return new ContactsViewModel(_navigationStore);
        });

        CancelContactEditCommand = new NavigateCommand<ContactsViewModel>(navigationStore, () => new ContactsViewModel(_navigationStore));
    }

    public ICommand ApplyContactEditCommand { get; }
    public ICommand CancelContactEditCommand { get; }
}
