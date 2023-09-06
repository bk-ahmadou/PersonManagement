using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Models
{
  public class Person
  {
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [Display(Name = "Address")]
    public string? Address { get; set; }

    [Display(Name = "Äge")]
    public int Age { get; set; }
  }
}
