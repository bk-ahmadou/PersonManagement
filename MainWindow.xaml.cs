using PersonManagement.Models;
using PersonManagement.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PersonManagement
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindowService Service { get; set; }
    public MainWindow()
    {
      InitializeComponent();

      Service = new MainWindowService();

      this.DataContext = Service;
    }

    private void AddPerson(object sender, RoutedEventArgs e)
    {
      string firstName = this.firstName.Text; 
      string lastName = this.lastName.Text;
      string address = this.address.Text;

      if (string.IsNullOrEmpty(firstName) ||
        string.IsNullOrEmpty(lastName) ||
        string.IsNullOrEmpty(address) ||
        string.IsNullOrEmpty(this.age.Text))
      {
        MessageBox.Show("Veuillez remplir tous les champs.");
        return;
      }

      if (int.TryParse(this.age.Text, out int age))
      {
        Person newPerson = new Person { FirstName = firstName, LastName = lastName, Address = address, Age = age };
        Service.People.Add(newPerson);
      }
      else
      {
        MessageBox.Show("Invalid age input. Please enter a valid number.");
      }
    }

    private void DeletePerson(object sender, RoutedEventArgs e)
    {
      if (sender is Button button && button.DataContext is Person person)
      {
        Service.People.Remove(person);
      }
    }

  }
}
