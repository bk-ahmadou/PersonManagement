using PersonManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PersonManagement.Services
{
  public class MainWindowService
  {
    public ObservableCollection<Person> People { get; set; }
    public string TitleOfMainWindow { get; set; }

    public ICommand AddPersonCommand { get; }
    //public ICommand DeletePersonCommand { get; }

    public MainWindowService() {

      TitleOfMainWindow = "Person management";

      People = new ObservableCollection<Person>()
      {
        new Person() {FirstName = "Ahmadou", LastName="Kassoum", Address = "12 Mail Guay Lussac", Age = 26},
        new Person() {FirstName = "Ibrahim", LastName="Ali", Address = "4 Rue de la parabolle", Age = 25},
        new Person() {FirstName = "Habibou", LastName="Alio", Address = "27 Avenue de la Marre aux Daims", Age = 17},
        new Person() {FirstName = "Jean-Marc", LastName="Chima", Address = "423 Rue montmartre", Age = 29},
        new Person() {FirstName = "Christensen", LastName="Renato", Address = "47 rue de la Boétie", Age = 36},
        new Person() {FirstName = "Issa", LastName="Williford", Address = "75 rue Marie de Médicis", Age = 38},
        new Person() {FirstName = "Reid", LastName="Schwartz", Address = "58 Boulevard de Normandie", Age = 37},
        new Person() {FirstName = "Christoper ", LastName="Hendrix", Address = "45 rue Petite Fusterie", Age = 28},
        new Person() {FirstName = "Joesph ", LastName="Hampton", Address = " 52 Faubourg Saint Honoré", Age = 26},
        new Person() {FirstName = "Watson", LastName="Adkins", Address = "Languedoc-Roussillon", Age = 26}
      };

      AddPersonCommand = new RelayCommand(AddPerson);
      //DeletePersonCommand = new RelayCommand<Person>(DeletePerson);
    }

    private void AddPerson(object parameter)
    {
      if (parameter is Tuple<string, string, string, string> values)
      {
        string firstName = values.Item1;
        string lastName = values.Item2;
        string address = values.Item3;

        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(address))
        {
          // Handle invalid input
          return;
        }

        if (int.TryParse(values.Item4, out int age))
        {
          Person newPerson = new Person { FirstName = firstName, LastName = lastName, Address = address, Age = age };
          People.Add(newPerson);
        }
        else
        {
          // Handle invalid age input
        }
      }
    }

    private void DeletePerson(Person person)
    {
      // ...
    }

  }
}
