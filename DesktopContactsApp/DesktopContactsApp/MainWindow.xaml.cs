﻿using System.Windows;
using System.Windows.Controls;
using DesktopContactsApp.Classes;

namespace DesktopContactsApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    List<Contact> contacts;

    public MainWindow()
    {
        InitializeComponent();

        contacts = new List<Contact>();

        ReadDatabase();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        NewContactWindow newContactWindow = new NewContactWindow();
        newContactWindow.ShowDialog();

        ReadDatabase();
    }

    void ReadDatabase()
    {
        using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
        {
            conn.CreateTable<Contact>();
            contacts = (conn.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList();
        }

        if (contacts != null)
        {
            contactsListView.ItemsSource = contacts;
        }

    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox? searchTextBox = sender as TextBox;

        var filteredList = contacts.Where(c => c.Name!.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

        var filteredList2 = (from c2 in contacts
                            where c2.Name.ToLower().Contains(searchTextBox.Text.ToLower())
                            orderby c2.Email
                            select c2).ToList();

        contactsListView.ItemsSource = filteredList;
    }

    private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Contact selectedContact = (Contact)contactsListView.SelectedItem;
        if (selectedContact != null)
        {
            ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(selectedContact);
            contactDetailsWindow.ShowDialog();

            ReadDatabase();
        }    
    }
}