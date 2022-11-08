using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS
{
    class Donors:CollectionBase
    {
        public void Add(Donor donor)
        {
            List.Add(donor);
        }
        public Donor this[int index]
        {
            get { return (Donor)this[index]; }
            set { this[index] = value; }
        }
    }
}
