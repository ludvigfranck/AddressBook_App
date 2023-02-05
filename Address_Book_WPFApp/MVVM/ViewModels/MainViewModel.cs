using Address_Book_WPFApp.Helpers;
using Address_Book_WPFApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Address_Book_WPFApp.MVVM.ViewModels;

internal class MainViewModel : ObservableObject
{
    private readonly NavigationStore _navigationStore;
    private readonly ContactService _contactService;

    public ICommand NavigateToAddContactCommand { get; }

    public ICommand NavigateToContactsCommand { get; }

    public MainViewModel(NavigationStore navigationStore, ContactService contactService)
    {
        _navigationStore = navigationStore;
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        _contactService = contactService;

        NavigateToAddContactCommand = new NavigateCommand<AddContactViewModel>(navigationStore, () => new AddContactViewModel(_navigationStore));
        NavigateToContactsCommand = new NavigateCommand<ContactsViewModel>(navigationStore, () => new ContactsViewModel(_navigationStore));
    }

    public ObservableObject CurrentViewModel => _navigationStore.CurrentViewModel;

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}
