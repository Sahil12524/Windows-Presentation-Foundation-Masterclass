using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace DesktopContactsApp;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    static readonly string databaseName = "Contacts.db";
    static readonly string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public static string databasePath = Path.Combine(folderPath, databaseName);
}

