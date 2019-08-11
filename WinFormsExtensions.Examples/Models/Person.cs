using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsExtensions.Examples.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public int Age
        {
            get
            {
                var dateTime = DateTime.Now - BirthDate;
                return (int) dateTime.TotalDays / 365;
            }
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} | Birth Date: {BirthDate.ToShortDateString()} | Age: {Age}";
        }

        public string Info => ToString();
    }
}
