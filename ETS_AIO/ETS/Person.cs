using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS
{
    public abstract class Person
    {
        private string firstname;
        private string lastname;

        public Person(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }

        public virtual string ToString()
        {
            return firstname + " " + lastname;
        }
    }
}
