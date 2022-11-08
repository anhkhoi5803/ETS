using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS
{
    class Sponsors:CollectionBase
    {
        public void Add(Sponsor SP)
        {
            List.Add(SP);
        }
        public Sponsor this[int index]
        {
            get { return (Sponsor)this[index]; }
            set { this[index] = value; }
        }
    }
}
