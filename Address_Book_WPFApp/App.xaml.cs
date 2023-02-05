using Address_Book_WPFApp.MVVM.ViewModels;
using Address_Book_WPFApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Address_Book_WPFApp;

public partial class App : Application
{
    public static IHost app { get; private set; } = null!;

    public App()
    {
        app = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ContactService>();

        }).Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var contactService = app!.Services.GetRequiredService<ContactService>();
        var navigationStore = app!.Services.GetRequiredService<NavigationStore>();

        navigationStore.CurrentViewModel = new ContactsViewModel(navigationStore);

        app.Start();

        var MainWindow = app.Services.GetRequiredService<MainWindow>();
        MainWindow.DataContext = new MainViewModel(navigationStore, contactService);
        MainWindow.Show();

        base.OnStartup(e);
    }
}
