using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS
{
    public  class Donor : Person
    {
        private string donorId;
        private string address;
        private string phone;
        private char cardType;
        private string cardNumber;
        private string cardExpiry;

        public Donor(string firstname, string lastname, string donorId, string address, string phone, char cardtype, string cardnumber, string cardexpiry) : base(firstname, lastname)
        {
            this.donorId = donorId;
            this.address = address;
            this.phone = phone;
            this.cardType = cardtype;
            this.cardNumber = cardnumber;
            this.cardExpiry = cardexpiry;
        }

        public string DonorId { get => donorId; set => donorId = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public char CardType { get => cardType; set => cardType = value; }
        public string CardNumber { get => cardNumber; set => cardNumber = value; }
        public string CardExpiry { get => cardExpiry; set => cardExpiry = value; }

        public override string ToString()
        {
            return base.ToString() + " DonorID:" + donorId + " Address:" + address + " Phone:" + phone + " Card Type:" + cardType + " Card Number:" + cardNumber + " Card Expiry:" + cardExpiry;
        }
        public string Format()
        {
            return Firstname + "," + Lastname + "," + donorId + "," + address + "," + phone + "," + cardType + "," + cardNumber + "," + cardExpiry;
        }
    }
}
