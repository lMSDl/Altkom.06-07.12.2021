using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Person
    {
        private string lastName;

        //public Person()
        //{
        //    CreatedDate = DateTime.Now;
        //}

        public string FirstName { get; set; }
        public string LastName
        {
            get
            { 
                return lastName;
            }
            set
            {
                lastName = value.ToUpper();
            }
        }

        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; } = DateTime.Now;

        //public string FullName { get { return FirstName + " " + LastName; } }
        //public string FullName { get { return string.Format("Nazwisko: {1}; Imię: {0}", FirstName, LastName); } }

        //string interpolowany
        public string FullName { get { return $"Nazwisko: {LastName}; Imię: {FirstName}"; } }

    }
}
