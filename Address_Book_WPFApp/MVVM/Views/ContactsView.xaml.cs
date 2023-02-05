using Address_Book_WPFApp.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Address_Book_WPFApp.MVVM.Views
{
    public partial class ContactsView : UserControl
    {
        public ContactsView()
        {
            InitializeComponent();
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is ContactsViewModel viewModel)
            {
                var _selectedContact = viewModel.SelectedContact;
                if (_selectedContact != null)
                {
                    tb_firstName.Text = _selectedContact.FirstName;
                    tb_lastName.Text = _selectedContact.LastName;
                    tb_email.Text = _selectedContact.Email;
                    tb_homeAddress.Text = _selectedContact.HomeAddress;
                    tb_postalCode.Text = _selectedContact.PostalCode;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tb_firstName.Text = string.Empty;
            tb_lastName.Text = string.Empty;
            tb_email.Text = string.Empty;
            tb_homeAddress.Text = string.Empty;
            tb_postalCode.Text = string.Empty;
        }

    }
}
