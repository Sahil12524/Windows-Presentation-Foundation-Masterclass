using System.Windows;
using DesktopContactsApp.Classes;
using SQLite;

namespace DesktopContactsApp;
/// <summary>
/// Interaction logic for NewContactWindow.xaml
/// </summary>
public partial class NewContactWindow : Window
{
    public NewContactWindow()
    {
        InitializeComponent();

        Owner = Application.Current.MainWindow;
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
    }
    
    private void saveBtn_Click(object sender, RoutedEventArgs e)
    {
        // TODO: Save The Contact
        Contact contact = new Contact()
        {
            Name = nameTextBox.Text,
            Email = emailTextBox.Text,
            Phone = phoneTextBox.Text
        };

        using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
        {
            connection.CreateTable<Contact>();
            connection.Insert(contact);
        }

        Close();
    }
}
