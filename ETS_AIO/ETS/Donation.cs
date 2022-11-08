using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS
{
    public class Donation
    {
        private string donationID;
        private string donationDate;
        private string donorID;
        private double donationAmount;
        private string prizeID;

        public Donation(string donationID, string donorID, double donationAmount, string prizeID)
        {
            this.donationID = donationID;
            this.donationDate = DateTime.Now.ToString("d/MM/yyyy");
            this.donorID = donorID;
            this.donationAmount = donationAmount;
            this.prizeID = prizeID;
        }

        public Donation(string donationID, string donationDate, string donorID, double donationAmount, string prizeID)
        {
            this.donationID = donationID;
            this.donationDate = donationDate;
            this.donorID = donorID;
            this.donationAmount = donationAmount;
            this.prizeID = prizeID;
        }

        public string DonationID { get => donationID; set => donationID = value; }
        public string DonationDate { get => donationDate; set => donationDate = value; }
        public string DonorID { get => donorID; set => donorID = value; }
        public double DonationAmount { get => donationAmount; set => donationAmount = value; }
        public string PrizeID { get => prizeID; set => prizeID = value; }

        public string ToString()
        {
            return "Donation Id: "+donationID + " Donation Date: " + donationDate + " Donor ID: " + donorID + " Donation Amount: " + donationAmount + " Prize ID:" + prizeID;
        }
        public string Format()
        {
            return donationID + "," + donationDate + "," + donorID + "," + donationAmount + "," + prizeID;
        }
    }
}
