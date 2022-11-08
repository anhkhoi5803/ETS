using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ETS;

namespace TelethonSystemWin
{
    public partial class ETSTelethon_v2 : Form
    {
        ETSManager man = new ETSManager();
        public ETSTelethon_v2()
        {
            InitializeComponent();
            man.loadDonation();
            man.loadDonor();
            man.loadPrize();
            man.loadSponsor();


            Init();
        }

        #region support func

        private void listSponsor()
        {
            cb_sponsorID.Items.Clear();
            string s = man.ListSponsorID();
            string[] arr = s.Split(' ');
            foreach (var a in arr)
            {
                cb_sponsorID.Items.Add(a);
            }
        }
        private void listDonor()
        {
            cb_donorID.Items.Clear();
            string s = man.ListDonorID();
            string[] arr = s.Split(' ');
            foreach (var a in arr)
            {
                cb_donorID.Items.Add(a);
            }
        }
        private void lsvSponsor()
        {
            lstv_sponsors.Items.Clear();
            List<string[]> list = man.ListViewSponsor();

            foreach (var a in list)
            {

                ListViewItem listViewItem = new ListViewItem(a);
                lstv_sponsors.Items.Add(listViewItem);
            } 
        }
        private void lsvDonor()
        {
            lstv_donors.Items.Clear();
            List<string[]> list = man.ListViewDonor();

            foreach (var a in list)
            {

                ListViewItem listViewItem = new ListViewItem(a);
                lstv_donors.Items.Add(listViewItem);
            }
        }
        private void lsvPrize()
        {
            lstv_prizes.Items.Clear ();
            List<string[]> l = man.ListViewPrize();

            foreach (var a in l)
            {
                ListViewItem lViewItem = new ListViewItem(a);   
                lstv_prizes.Items.Add( lViewItem);
            }
        }
        private void lsvDonation()
        {
            lstv_donations.Items.Clear();
            List<string[]> l = man.ListViewDonation();

            foreach (var a in l)
            {
                ListViewItem lViewItem = new ListViewItem(a);
                lstv_donations.Items.Add(lViewItem);
            }
        }
        private void Init()
        {
            listSponsor();
            listDonor();
            lsvSponsor();
            lsvDonor();
            lsvPrize();
            lsvDonation();
            btn_spedit_cancel.Enabled = false;
            btn_edit_sponsor.Enabled = false;
            txt_sponsorid.Enabled = true;
            txt_sponsor_fn.Clear();
            txt_sponsor_ln.Clear();
            txt_sponsorid.Clear();

            txt_donorfn.Clear();
            txt_donorln.Clear();
            txt_donorid.Clear();
            txt_donor_address.Clear();
            txt_donor_phone.Clear();
            masked_expdate.Clear();
            masked_num.Clear();

            radio_amex.Checked = false;
            radio_mc.Checked = false;
            radio_visa.Checked = false;


            btn_addDonation.Enabled = true;
            btn_addDonor.Enabled = true;
            btn_addPrize.Enabled = true;
            btn_addSponsor.Enabled = true;

            txt_prizeid.Enabled = true;
            txt_prizeid.Clear();
            txt_value.Enabled = true;
            txt_value.Clear();
            txt_prizequanity.Enabled = true;
            txt_prizequanity.Clear();
            txt_mindonation.Enabled = true;
            txt_mindonation.Clear();
            txt_prizedesc.Clear();
            cb_sponsorID.Enabled = true;
            btn_prize_cancel.Enabled = false;
            btn_prize_edit.Enabled = false;
            btn_addPrize.Enabled = true;

            btn_donor_edit.Enabled = false;
            btn_donoredit_cancel.Enabled = false;
        }
        #endregion

        #region sponsor page 
        private void btn_addSponsor_Click(object sender, EventArgs e)
        {
            string a = man.AddSponsor(txt_sponsor_fn.Text, txt_sponsor_ln.Text, txt_sponsorid.Text, 0.0);

            MessageBox.Show( a, "ETS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Init();
        }

        private void btn_addPrize_Click(object sender, EventArgs e)
        {

            double value;
            if (!double.TryParse(txt_value.Text, out value))
            {
                MessageBox.Show("Add the amount of value per prize");
                return;
            }

            int quan;
            if (!int.TryParse(txt_prizequanity.Text, out quan))
            {
                MessageBox.Show("Add the quanity of prize");
                return;
            }
            double min;
            if (!double.TryParse(txt_mindonation.Text, out min))
            {
                MessageBox.Show("Add the quanity of prize");
                return;
            }
            if(cb_sponsorID.SelectedIndex == -1) {
                MessageBox.Show("Choose a sponsor id");
                return ;
            }
            string a = man.AddPrize(txt_prizeid.Text, txt_prizedesc.Text, value, min, quan, cb_sponsorID.Text);
            MessageBox.Show( a,"ETS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Init();
        }

        private void btn_viewSponsor_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.AppendText(man.ListSponsors());
        }

        private void btn_viewPrize_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            richTextBox1.AppendText(man.ListPrizes());
        }
        #endregion
         
        #region donor page

        private void btn_addDonation_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            double amount;
            if (!double.TryParse(txt_donationAmount.Text, out amount))
            {
                MessageBox.Show("Enter the donation amount");
                return;
            }
            if(cbPrizesList.SelectedIndex == -1)
            {
                MessageBox.Show("Enter the Prize");
                return;
            }
            if (cb_donorID.SelectedIndex == -1)
            {
                MessageBox.Show("Enter the Donor ID");
                return;
            }

            MessageBox.Show( man.AddDonation(txt_donationid.Text, cb_donorID.SelectedItem.ToString(), amount, cbPrizesList.Text , 1), "ETS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Init();
        }

        private void btn_addDonor_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            char card;
            if (radio_amex.Checked)
            {
                card = 'A';
            }
            else if (radio_mc.Checked)
            {
                card = 'M';
            }
            else if (radio_visa.Checked)
            {
                card = 'V';
            }
            else
            {
                MessageBox.Show("Check a type of card");
                return;
            }

            string num  = masked_num.Text.Replace( "-", string.Empty);

            MessageBox.Show(man.AddDonor(txt_donorfn.Text, txt_donorln.Text, txt_donorid.Text, txt_donor_address.Text, txt_donor_phone.Text, card, num, masked_expdate.Text), "ETS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Init();
        }

        private void btn_listDonations_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            richTextBox1.AppendText(man.ListDonations());
        }

        private void btn_lstDonor_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            richTextBox1.AppendText(man.ListDonors());
        }

        #endregion

        #region save_close
        private void btn_save_Click(object sender, EventArgs e)
        {
            man.saveDonation();
            man.saveDonor();
            man.savePrize();
            man.saveSponsor();

            MessageBox.Show("Process Saved");
        }

        private void btn_close_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void ETSTelethon_v2_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message;
            MessageBoxButtons buttons;
            MessageBoxIcon icon;

            message = "Any unsaved changed will be lost! Would you like to save and exit?";
            buttons = MessageBoxButtons.YesNoCancel;
            icon = MessageBoxIcon.Warning;

            var result = MessageBox.Show(message,
                                         "Confirm",
                                         buttons,
                                         icon);
            if (result == DialogResult.Yes)
            {
                man.saveDonation();
                man.saveDonor();
                man.savePrize();
                man.saveSponsor();

                MessageBox.Show("Process Saved");
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                
            }
        }

        private void btn_loadPrizes_Click(object sender, EventArgs e)
        {
            
            double amount;
            if (!double.TryParse(txt_donationAmount.Text, out amount))
            {
                MessageBox.Show("Enter the donation amount","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cbPrizesList.Enabled = true;
            string l = man.ListQualifiedPrizesID(amount);
            cbPrizesList.Items.Clear();
            string[] arr = l.Split(' ');
            foreach(var a in arr)
            {
                cbPrizesList.Items.Add(a);
            }
        }
        #endregion

        #region extra
        private void btn_sponsor_search_Click(object sender, EventArgs e)
        {
            MessageBox.Show(man.sponsorSearch(txt_sponsorid_search.Text),"Sponsor",MessageBoxButtons.OK,MessageBoxIcon.Information);
            txt_sponsorid_search.Clear();
        }

        private void btn_edit_sponsor_Click(object sender, EventArgs e)
        {

            MessageBox.Show(man.sponsorEdit(txt_sponsorid.Text,txt_sponsor_fn.Text,txt_sponsor_ln.Text), "Sponsor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btn_spedit_cancel.Enabled = false;
            btn_edit_sponsor.Enabled = false;
            txt_sponsorid.Enabled = true;
            txt_sponsor_fn.Clear();
            txt_sponsor_ln.Clear();
            txt_sponsorid.Clear();
            lsvSponsor();
            
        }

        private void btn_spedit_cancel_Click(object sender, EventArgs e)
        {
           Init();

        }

        private void lstv_sponsors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstv_sponsors.SelectedItems.Count == 0)
            {
                return;

            }

            btn_spedit_cancel.Enabled = true;
            btn_edit_sponsor.Enabled = true;
            txt_sponsorid.Enabled = false;
            btn_addSponsor.Enabled = false;
            ListViewItem item = lstv_sponsors.SelectedItems[0];

            txt_sponsor_fn.Text = item.SubItems[0].Text;
            txt_sponsor_ln.Text = item.SubItems[1].Text;

            txt_sponsorid.Text = item.SubItems[2].Text;
        }

        private void btn_donor_search_Click(object sender, EventArgs e)
        {
            MessageBox.Show(man.donorSearch(txt_donor_search.Text), "Donor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt_donor_search.Clear();
        }

        private void lstv_donors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstv_donors.SelectedItems.Count == 0)
            {
                return;

            }
            btn_addDonor.Enabled = true;
            btn_donor_edit.Enabled = true;
            btn_donoredit_cancel.Enabled = true;
            btn_delete_donor.Enabled = true;
            txt_donorid.Enabled = false;
            ListViewItem item = lstv_donors.SelectedItems[0];

            txt_donorfn.Text = item.SubItems[0].Text;
            txt_donorln.Text=  item.SubItems[1].Text;
            txt_donorid.Text = item.SubItems[2].Text;

             
            txt_donor_address.Text = item.SubItems[3].Text;
            txt_donor_phone.Text = item.SubItems[4].Text;
            if (char.Parse(item.SubItems[5].Text) == 'A')
            {
                radio_amex.Checked = true;
            }
            else if (char.Parse(item.SubItems[5].Text) == 'M')
            {
                radio_mc.Checked = true;
            }
            else if (char.Parse(item.SubItems[5].Text) == 'V')
            {
                radio_visa.Checked = true;
            }

            masked_num.Text = item.SubItems[6].Text;

            masked_expdate.Text = item.SubItems[7].Text;

        }

        private void btn_donor_edit_Click(object sender, EventArgs e)
        {
            char card;
            if (radio_amex.Checked)
            {
                card = 'A';
            }
            else if (radio_mc.Checked)
            {
                card = 'M';
            }
            else if (radio_visa.Checked)
            {
                card = 'V';
            }
            else
            {
                richTextBox1.AppendText("Check a type of card");
                return;
            }

            string num = masked_num.Text.Replace("-", string.Empty);
            MessageBox.Show(man.donorEdit(txt_donorfn.Text, txt_donorln.Text, txt_donorid.Text, txt_donor_address.Text, txt_donor_phone.Text, card, num, masked_expdate.Text), "ETS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Init();
        }

        private void btn_donoredit_cancel_Click(object sender, EventArgs e)
        {
            Init();

        }

        private void btn_delete_donor_Click(object sender, EventArgs e)
        {

            var ans = MessageBox.Show("Do you want to delete this donor?\n Warning:Can not revert action", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ans == DialogResult.No) { return; }
            //del donation and increase prize
            MessageBox.Show(man.donorDel(txt_donorid.Text));

            Init();

        }

        private void btn_prize_search_Click(object sender, EventArgs e)
        {
            MessageBox.Show(man.prizeSearch(txt_prize_search.Text), "Prize", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt_prize_search.Clear();

        }

        private void btn_donation_search_Click(object sender, EventArgs e)
        {
            MessageBox.Show(man.donationSearch(txt_donation_search.Text), "Donation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt_donation_search.Clear();
        }

        private void lstv_prizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstv_prizes.SelectedItems.Count == 0) { return; }
            txt_prizeid.Enabled = false;
            txt_value.Enabled = false;
            txt_prizequanity.Enabled = false;
            txt_mindonation.Enabled = false;
            cb_sponsorID.Enabled = false;
            btn_prize_cancel.Enabled = true;
            btn_prize_edit.Enabled = true;
            btn_addPrize.Enabled = false;

            ListViewItem item = lstv_prizes.SelectedItems[0];
            txt_prizeid.Text = item.SubItems[0].Text;
            txt_prizedesc.Text = item.SubItems[1].Text;
            txt_value.Text = item.SubItems[2].Text;
            txt_prizequanity.Text = item.SubItems[3].Text;
            txt_mindonation.Text = item.SubItems[4].Text;
            cb_sponsorID.SelectedItem = item.SubItems[6].Text;
        }

        private void lstv_donations_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_prize_cancel_Click(object sender, EventArgs e)
        {
            Init();
        }
        #endregion

        private void btn_saveAs_Click(object sender, EventArgs e)
        {

            string filename= txt_filename.Text.Trim();
            MessageBox.Show(man.saveAsText(filename));
        }

    }
}
