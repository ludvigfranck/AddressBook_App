using Address_Book_WPFApp.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_WPFApp.Services;

internal class NavigationStore
{
    public event Action? CurrentViewModelChanged;

    private ObservableObject? _currentViewModel;

    public ObservableObject CurrentViewModel
    {
        get => _currentViewModel!;
        set
        {
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
}
