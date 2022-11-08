using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS
{
    class Donations:CollectionBase
    {
        public void Add(Donation d)
        {
            List.Add(d);
        }
        public Donation this[int index]
        {
            get { return (Donation)this[index]; }
            set { this[index] = value; }
        }
    }
}
