using System.Windows;
using DesktopContactsApp.Classes;
using SQLite;

namespace DesktopContactsApp;

/// <summary>
/// Interaction logic for ContactDetailsWindow.xaml
/// </summary>
public partial class ContactDetailsWindow : Window
{
    private readonly Contact contact;
    public ContactDetailsWindow(Contact contact)
    {
        InitializeComponent();

        Owner = Application.Current.MainWindow;
        WindowStartupLocation = WindowStartupLocation.CenterOwner;

        this.contact = contact;
        nameTextBox.Text = contact.Name;
        phoneTextBox.Text = contact.Phone;
        emailTextBox.Text = contact.Email;
    }

    private void updateBtn_Click(object sender, RoutedEventArgs e)
    {
        contact.Name = nameTextBox.Text;
        contact.Phone = phoneTextBox.Text;
        contact.Email = emailTextBox.Text;
        using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
        {
            connection.CreateTable<Contact>();
            connection.Update(contact);
        }

        Close();
    }

    private void deleteBtn_Click(object sender, RoutedEventArgs e)
    {
        using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
        {
            connection.CreateTable<Contact>();
            connection.Delete(contact);
        }

        Close();
    }
}
