using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_WPFApp.MVVM.Models;

public class Contact
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string HomeAddress { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string DisplayName => $"{FirstName} {LastName}";
}
