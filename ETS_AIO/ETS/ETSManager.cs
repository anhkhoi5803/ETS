using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.CodeDom;

namespace ETS
{
    public class ETSManager
    {
        Donors donors = new Donors();
        Sponsors sponsors = new Sponsors();
        Prizes prizes = new Prizes();
        Donations donations = new Donations();


        #region support 
        public  bool checkID(string id)
        {
            if (string.IsNullOrEmpty(id)|| id.Length !=4)
            {
                return false;
            }
            return true;
        }
        public bool checkName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length>15)
            {
                return false;
            }
            return true;
        }
        public bool checkAddress(string address)
        {
            if (string.IsNullOrEmpty(address) || address.Length > 40)
            {
                return false;
            }
            return true;
        }
        public bool checkPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone)) { return false; }
            string ex = @"^(\d{3})\s(\d{3})\-(\d{4})$";

            return new Regex(ex).IsMatch(phone);
        }
        public bool checkCardNum(string cardnumber)
        {
            if (string.IsNullOrEmpty(cardnumber) || cardnumber.Length != 16  )
            {
                return false;
            }

            foreach(char c in cardnumber)
            {
                if ( !Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        public bool checkExpiry(string date)
        {
            string Ex = @"^((0[1-9])|(1[0-2]))\/(\d{4})$";

            return new Regex(Ex).IsMatch(date);
        }
        public bool donorIdExist(string id)
        {
            foreach(Donor d in donors)
            {
                if (d.DonorId == id)
                {
                    return true;
                }
            }
            return false;
        }
        public bool sponsorIdexist(string id)
        {
            foreach (Sponsor d in sponsors)
            {
                if (d.SponsorId == id)
                {
                    return true;
                }
            }
            return false;
        }
        public bool donationIdexist(string id)
        {
            foreach (Donation d in donations)
            {
                if (d.DonationID == id)
                {
                    return true;
                }
            }
            return false;
        }
        public bool prizeIdexist(string id)
        {
            foreach (Prize d in prizes)
            {
                if (d.PrizeID == id)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion  

        public ETSManager() { }
        #region Add 
        public string AddSponsor(string firstname, string lastname, string sponsorId, double totalPrizeValue) //? total prize value
        {
            if (!checkName(firstname) || !checkName(lastname)) { return "Last/First name not in 15 chars"; }
            if (!checkID(sponsorId) || sponsorIdexist(sponsorId)) { return "Sponsor ID existed/wrong format"; }
            Sponsor sponsor = new Sponsor(firstname, lastname, sponsorId, totalPrizeValue);
            sponsors.Add(sponsor);
            return "Sponsor Added";
        }
        public string AddPrize(string prizeID, string description, double value, double donationLimit, int originalAvailable, string sponsorID)
        {
            if (!checkID(prizeID) || prizeIdexist(prizeID)) { return "Prize ID existed/wrong format"; }
            if (!checkName(description)) { return "description exceed 15 char"; }
            if (value > 299.99) { return "Value cannot exceed 299.99"; }
            if (originalAvailable > 999 || originalAvailable <= 0) { return "cannot exceed 999"; }
            if (donationLimit < 5.00 || donationLimit > 999999.99) { return "Amount too small/large(min:5/max:999,999.99"; }
            if (!sponsorIdexist(sponsorID)) { return "Sponsor Id not exist"; }
            Prize prize = new Prize(prizeID, description, value, donationLimit, originalAvailable, sponsorID);
            changeTotal(sponsorID, value, originalAvailable);
            prizes.Add(prize);
            return "Prize added";
        }
        public string AddDonor(string firstname, string lastname, string donorId, string address, string phone, char cardtype, string cardnumber, string cardexpiry)
        {
            if (!checkName(firstname) || !checkName(lastname)) { return "Last/First name not in 15 chars"; }
            if (!checkID(donorId) || donorIdExist(donorId)) { return "Donor ID existed/wrong format"; }
            if (!checkAddress(address)) { return "Address wrong format"; }
            if (!checkPhone(phone)) { return "Wrong phone number format( ### ###-####)"; }
            if (!checkCardNum(cardnumber)) { return "wrong card number format, need to be 16 digits" + cardnumber; }
            if (!checkExpiry(cardexpiry)) { return "wrong card expiry"; }
            Donor donor = new Donor(firstname, lastname, donorId, address, phone, cardtype, cardnumber, cardexpiry);
            donors.Add(donor);
            return "Donor added";
        }
        public string AddDonation(string donationID, string donorID, double donationAmount, string prizeID, int quan)
        {
            if (!checkID(donationID) || donationIdexist(donationID)) { return "Donation ID existed/wrong format"; }
            if (!checkID(prizeID) || !prizeIdexist(prizeID)) { return "Prize ID not existed/wrong format"; }
            if (!checkID(donorID) || !donorIdExist(donorID)) { return "Donor ID not existed/wrong format" + donorID; }
            if (donationAmount < 5.00 || donationAmount > 999999.99) { return "Amount too small/large(min:5/max:999,999.99"; }
            foreach (Prize prize in prizes)
            {
                if (prize.PrizeID == prizeID)
                {
                    if (prize.DonationLimit > donationAmount)
                    {
                        return "Donation Amount not meet minimum limit" + "\n Qualified Prizes:\n" + ListQualifiedPrizes(prizeID, donationAmount);
                    }
                }
            }
            if (!RecordDonation(prizeID, quan)) { return "Not enough prize to award" + "\n Qualified Prizes:\n" + ListQualifiedPrizes(prizeID, donationAmount); }

            Donation donation = new Donation(donationID, donorID, donationAmount, prizeID);
            donations.Add(donation);
            return "Donation added";
        }
        public void changeTotal(string sponsorId ,double value,int quan)
        {
            foreach (Sponsor d in sponsors)
            {
                if (d.SponsorId == sponsorId)
                {
                    d.AddValue(value*quan);
                }
            }
        }
        public bool RecordDonation(string prizeid, int numofprize)
        {
            foreach (Prize prize in prizes)
            {
                if (prize.PrizeID == prizeid && prize.CurrentAvailable >= numofprize)
                {
                    prize.CurrentAvailable -= numofprize;
                    return true;
                }
            }
            return false;
        }
        #endregion


        #region list

        public string ListDonors()
        {
            string ans = "";
            foreach(Donor donor in donors)
            {
                ans += donor.ToString() + Environment.NewLine;
            }
            return ans;
        }
        public string ListSponsors()
        {
            string ans = "";
            foreach (Sponsor sponsor in sponsors)
            {
                ans += sponsor.ToString() + Environment.NewLine;
            }
            return ans;
        }
        public string ListPrizes()
        {
            string ans = "";
            foreach (Prize prize in prizes)
            {
                ans += prize.ToString() + Environment.NewLine;
            }
            return ans;
        }
        public string ListDonations()
        {
            string ans = "";
            foreach (Donation donation in donations)
            {
                ans += donation.ToString() + Environment.NewLine;
            }
            return ans;
        }
        public string ListQualifiedPrizes(string id, double amount)
        {
            if (!checkID(id) || !prizeIdexist(id)) { return "Prize ID not existed/wrong format"; }
            string ans = "";
            foreach(Prize prize in prizes)
            {
                if (prize.PrizeID == id && prize.DonationLimit <= amount)
                {
                    ans += prize.ToString() + Environment.NewLine;
                    break;
                }
            }
            return ans;
        }
        public string ListQualifiedPrizesID( double amount)
        {
            string ans = "" ;
            foreach (Prize prize in prizes)
            {
                if ( prize.DonationLimit <= amount)
                {
                    ans += prize.PrizeID +" ";
                   
                }
            }
            return ans.Trim();
        }
        public string ListSponsorID()
        {
            string ans = "";
            foreach (Sponsor sponsor in sponsors)
            {
                ans += sponsor.SponsorId + " ";
            }
            return ans.Trim();
        }
        public string ListDonorID()
        {
            string ans = "";
            foreach (Donor donor in donors)
            {
                ans += donor.DonorId + " ";
            }
            return ans.Trim();
        }
      
      
        public List<string[]> ListViewSponsor()
        {
            List<string[]> list = new List<string[]>();
            foreach (Sponsor sponsor in sponsors)
            {
                string[] a = sponsor.Format().Split(',');
                list.Add(a);
            }
            return list;
        }
        public List<string[]> ListViewPrize()
        {
            List<string[]> list = new List<string[]>();
            foreach (Prize prize in prizes)
            {
                string[] a = prize.Format().Split(',');
                list.Add(a);
            }
            return list;
        }
        public List<string[]> ListViewDonor()
        {
            List<string[]> list = new List<string[]>();
            foreach (Donor donor in donors)
            {
                string[] a = donor.Format().Split(',');
                list.Add(a);
            }
            return list;
        }
        public List<string[]> ListViewDonation()
        {
            List<string[]> list = new List<string[]>();
            foreach (Donation donation in donations)
            {
                string[] a = donation.Format().Split(',');
                list.Add(a);
            }
            return list;
        }
        #endregion

        #region search edit delete
        public string sponsorSearch(string id)
        {
            if (checkID(id) && sponsorIdexist(id))
            {
                foreach (Sponsor sponsor in sponsors)
                {
                    if (sponsor.GetID() == id) { return sponsor.ToString(); }
                }
            }

            return "Sponsor ID existed/wrong format";
        }
        public string sponsorEdit(string id, string fn, string ln)
        {
            if (!checkName(fn) || !checkName(ln)) { return "Last/First name not in 15 chars"; }
            foreach (Sponsor sponsor in sponsors)
            {
                if (sponsor.GetID() == id)
                {
                    sponsor.Firstname = fn;
                    sponsor.Lastname = ln;
                    return "Sponsor is editted";
                }
            }
            return "ID is faulty"; 
        }
        public string donorSearch(string id)
        {
            if (checkID(id) && donorIdExist(id))
            {
                foreach (Donor donor in donors)
                {
                    if (donor.DonorId == id) { return donor.ToString(); }
                }
            }

            return "Donor ID not existed/wrong format";
        }
        public string donorEdit(string firstname, string lastname, string donorId, string address, string phone, char cardtype, string cardnumber, string cardexpiry)
        {
            if (!checkName(firstname) || !checkName(lastname)) { return "Last/First name not in 15 chars"; }
            if (!checkAddress(address)) { return "Address wrong format"; }
            if (!checkPhone(phone)) { return "Wrong phone number format( ### ###-####)"; }
            if (!checkCardNum(cardnumber)) { return "wrong card number format, need to be 16 digits" + cardnumber; }
            if (!checkExpiry(cardexpiry)) { return "wrong card expiry"; }

            foreach(Donor donor in donors)
            {
                if(donor.DonorId == donorId)
                {
                    donor.Firstname = firstname;
                    donor.Lastname = lastname;
                    donor.Address = address;
                    donor.Phone = phone;    
                    donor.CardType = cardtype;
                    donor.CardNumber = cardnumber;
                    donor.CardExpiry = cardexpiry;
                    return "Donor Editted";
                }
            }
            
            return "Donor ID is faulty";
        }
        public string donorDel(string id)
        {
            if (!donorIdExist(id)) { return "Delete unsuccessful"; }
            int idx = 0;
            string id1="";
            foreach(Donor donor in donors)
            {
                if (donor.DonorId == id)
                {
                    id1 = donor.DonorId;
                    donors.RemoveAt(idx);
                    break;
                }
                idx++;
            }

            List<int> del_idx = new List<int>();
            foreach(Donation donation in donations)
            {
                int idx1 = 0;
                if (donation.DonorID == id1)
                {
                    del_idx.Add(idx1);

                    foreach (Prize prize in prizes)
                    {
                        if (prize.PrizeID == donation.PrizeID)
                        {
                            prize.Decrease(-1);
                        }
                    }
                }
                idx1++;
            }
            foreach (var i in del_idx)
            {
                donations.RemoveAt(i);
            }

            return "Donor remove successfully";
        }
        public string prizeSearch(string id)
        {
            if(checkID(id) && prizeIdexist(id))
            {
                foreach(Prize prize in prizes)
                {
                    if(prize.PrizeID == id) { return prize.ToString(); }
                }
            }
            return "Prize Id not exist/wrong formot";
        }
        public string donationSearch(string id)
        {
            if (checkID(id) && donationIdexist(id))
            {
                foreach (Donation donation in donations)
                {
                    if (donation.DonationID == id) { return donation.ToString(); }
                }
            }
            return "Donation Id not exist/wrong formot";
        }
        #endregion

        #region save_load
        public void saveDonation()
        {
            using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Donations.txt"))
            {
                foreach (Donation donation in donations)
                {
                    sw.WriteLine(donation.Format());
                }
            }
        }
        public void saveSponsor()
        {
            using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Sponsors.txt"))
            {
                foreach (Sponsor sponsor in sponsors)
                {
                    sw.WriteLine(sponsor.Format());
                }
            }
        }
        public void saveDonor()
        {
            using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Donors.txt"))
            {
                foreach (Donor donor in donors)
                {
                    sw.WriteLine(donor.Format());
                }
            }
        }
        public void savePrize()
        {
            using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Prizes.txt"))
            {
                foreach (Prize prize in prizes)
                {
                    sw.WriteLine(prize.Format());
                }
            }
        }

        public void loadDonation()
        {
            using( StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\Donations.txt"))
            {
                while(sr.Peek() >= 0)
                {
                    string[] strArr = sr.ReadLine().Split(',');
                    Donation current = new Donation(strArr[0],strArr[1],strArr[2],Convert.ToDouble(strArr[3]),strArr[4]);
                    donations.Add(current);
                }
            }
        }
        public void loadSponsor()
        {
            using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\Sponsors.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string[] strArr = sr.ReadLine().Split(',');

                    Sponsor sponsor = new Sponsor(strArr[0],strArr[1],strArr[2],Convert.ToDouble(strArr[3])) ;
                    sponsors.Add(sponsor);
                }
            }
        }
        public void loadDonor()
        {
            using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\Donors.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string[] strArr = sr.ReadLine().Split(',');

                    Donor donor = new Donor(strArr[0], strArr[1], strArr[2],strArr[3],strArr[4], char.Parse(strArr[5]),strArr[6],strArr[7]);
                    donors.Add(donor);
                }
            }
        }
        public void loadPrize()
        {
            using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\Prizes.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string[] strArr = sr.ReadLine().Split(',');

                    Prize prize = new Prize(strArr[0], strArr[1], Convert.ToDouble(strArr[2]), Convert.ToDouble(strArr[3]), Convert.ToInt32(strArr[4]), Convert.ToInt32(strArr[5]),strArr[6]);
                    prizes.Add(prize);
                }
            }
        }

        public string saveAsText(string filename)
        {
            if (string.IsNullOrEmpty(filename)) { return "file name cant be empty"; }

            char[] invalidChars = Path.GetInvalidFileNameChars();
            
            /*if( filename.IndexOfAny(invalidChars) >0)
            {
                return "Invalid file name\n Choose another file name";
            }*/
            foreach(char c in invalidChars)
            {
                if (filename.Contains(c.ToString()))
                {
                    return "Invalid file name\n Choose another file name";
                }
            }
           
            string date = DateTime.Now.ToString("dd/MMMM/yyyy hh:mm:ss");
            using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Saves\"+filename+".txt"))
            {
                sw.WriteLine("Created on " + date);
                sw.WriteLine("\n\n\n");
                sw.WriteLine("======Sponsor======\n\n\n");
                foreach (Sponsor sponsor in sponsors)
                {
                    sw.WriteLine(sponsor.ToString());
                }
                sw.WriteLine("\n\n\n");


                sw.WriteLine("======Donor======\n\n\n");
                foreach (Donor donor in donors)
                {
                    sw.WriteLine(donor.ToString());
                }
                sw.WriteLine("\n\n\n");

                sw.WriteLine("======Prize======\n\n\n");
                foreach (Prize prize in prizes)
                {
                    sw.WriteLine(prize.ToString());
                }
                sw.WriteLine("\n\n\n");

                sw.WriteLine("======Donation======\n\n\n");
                foreach (Donation donation in donations)
                {
                    sw.WriteLine(donation.ToString());
                }
                sw.WriteLine("\n\n\n");

            }
            Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\Saves\" /*+ filename + ".txt"*/);
            //Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\Saves\" + filename + ".txt");

            return filename + " is saved";
        }
        #endregion
    }
}
