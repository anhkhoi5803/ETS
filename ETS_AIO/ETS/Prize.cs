using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS
{
    public class Prize
    {
        private string prizeID;
        private string description;
        private double value;
        private double donationLimit;
        private int originalAvailable;
        private int currentAvailable;
        private string sponsorID;

        public Prize(string prizeID, string description, double value, double donationLimit, int originalAvailable, string sponsorID)
        {
            this.prizeID = prizeID;
            this.description = description;
            this.value = value;
            this.donationLimit = donationLimit;
            this.originalAvailable = originalAvailable;
            this.currentAvailable = originalAvailable;
            this.sponsorID = sponsorID;
        }

        public Prize(string prizeID, string description, double value, double donationLimit, int originalAvailable, int currentAvailable, string sponsorID)
        {
            this.prizeID = prizeID;
            this.description = description;
            this.value = value;
            this.donationLimit = donationLimit;
            this.originalAvailable = originalAvailable;
            this.currentAvailable = currentAvailable;
            this.sponsorID = sponsorID;
        }

        public string PrizeID { get => prizeID; set => prizeID = value; }
        public string Description { get => description; set => description = value; }
        public double Value { get => value; set => this.value = value; }
        public double DonationLimit { get => donationLimit; set => donationLimit = value; }
        public int OriginalAvailable { get => originalAvailable; set => originalAvailable = value; }
        public int CurrentAvailable { get => currentAvailable; set => currentAvailable = value; }
        public string SponsorID { get => sponsorID; set => sponsorID = value; }

        override public string ToString()
        {
            return "Prize ID:" + prizeID + " Description:" + description + " Value:" + value + "Minimum Donation Limit:" + donationLimit + " Original Available:" + originalAvailable + " Current Available:" + currentAvailable + " SponsorID:" + sponsorID;
        }

        public string GetPrizeID() { return prizeID; }
        public void Decrease(int d) { currentAvailable -= d; }
        public void ClearPrize()
        {
            value = 0;
        }
        public string Format()
        {
            return prizeID + "," + description + "," + value + "," + donationLimit + "," + originalAvailable + "," + currentAvailable + "," + sponsorID;
        }
    }
}
