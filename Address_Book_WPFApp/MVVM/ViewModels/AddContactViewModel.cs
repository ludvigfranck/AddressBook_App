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

internal class AddContactViewModel : ObservableObject
{
    private readonly NavigationStore _navigationStore;
    private readonly ContactService _contactService;

    public Contact Contact { get; set; } = new Contact();

    public AddContactViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        _contactService = new ContactService();
        AddContactCommand = new NavigateCommand<ContactsViewModel>(_navigationStore, () =>
        {
            _contactService.AddToList(Contact);
            return new ContactsViewModel(_navigationStore);
        });
    }
    public ICommand AddContactCommand { get; }
}
