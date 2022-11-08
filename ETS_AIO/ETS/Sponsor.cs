using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS
{
    public class Sponsor : Person
    {
        private string sponsorId;
        private double totalPrizeValue;

        public Sponsor(string firstname, string lastname, string sponsorId, double totalPrizeValue) : base(firstname, lastname)
        {
            this.sponsorId = sponsorId;
            this.totalPrizeValue = totalPrizeValue;
        }

        public string SponsorId { get => sponsorId; set => sponsorId = value; }
        public double TotalPrizeValue { get => totalPrizeValue; set => totalPrizeValue = value; }

        public override string ToString()
        {
            return base.ToString() + " Sponsor Id: " + sponsorId + " Total Prize Value: " + totalPrizeValue;
        }

        public string GetID()
        {
            return sponsorId;
        }

        public double AddValue(double value)
        {
            totalPrizeValue += value;
            return totalPrizeValue;
        }
        public string Format()
        {
            return Firstname + "," + Lastname + "," + sponsorId + "," + totalPrizeValue;
        }
    }
}
