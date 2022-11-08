using ETS;
using System;
using System.Windows.Forms;

namespace TelethonSystemWin
{
    public partial class ETSTelethon : Form
    {
        ETSManager man = new ETSManager();
        public ETSTelethon()
        {
            InitializeComponent();
            man.loadDonation();
            man.loadDonor();
            man.loadPrize();
            man.loadSponsor();
        }

        #region sponsor page 
        private void btn_addSponsor_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string a = man.AddSponsor(txt_sponsor_fn.Text, txt_sponsor_ln.Text, txt_sponsorid.Text, 0.0);

            richTextBox1.AppendText(a);
        }

        private void btn_addPrize_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            double value;
            if (!double.TryParse(txt_value.Text, out value))
            {
                richTextBox1.AppendText("Add the amount of value per prize");
                return;
            }

            int quan;
            if (!int.TryParse(txt_prizequanity.Text, out quan))
            {
                richTextBox1.AppendText("Add the quanity of prize");
                return;
            }
            double min;
            if (!double.TryParse(txt_mindonation.Text, out min))
            {
                richTextBox1.AppendText("Add the quanity of prize");
                return;
            }
            string a = man.AddPrize(txt_prizeid.Text, txt_prizedesc.Text, value, min, quan, txt_sponsorid.Text);
            richTextBox1.AppendText(a);
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
        private void btn_showprizes_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            double amount;
            if (!double.TryParse(txt_donationAmount.Text, out amount))
            {
                richTextBox1.AppendText("Enter the donation amount");
                return;
            }
            richTextBox1.AppendText(man.ListQualifiedPrizes(txt_prizeid_search.Text, amount));
        }

        private void btn_addDonation_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            double amount;
            if (!double.TryParse(txt_donationAmount.Text, out amount))
            {
                richTextBox1.AppendText("Enter the donation amount");
                return;
            }
            int quan;
            if (!int.TryParse(txt_prizequan_search.Text, out quan))
            {
                richTextBox1.AppendText("Enter the number of prizes");
                return;
            }

            richTextBox1.AppendText(man.AddDonation(txt_donationid.Text, txt_donorid.Text, amount, txt_prizeid_search.Text, quan));
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
                richTextBox1.AppendText("Check a type of card");
                return;
            }

            richTextBox1.AppendText(man.AddDonor(txt_donorfn.Text, txt_donorln.Text, txt_donorid.Text, txt_donor_address.Text, txt_donor_phone.Text, card, txt_cardnum.Text, txt_cardexp.Text) );

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
        #endregion
        #region redundancy

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion
        private void ETSTelethon_FormClosing(object sender, FormClosingEventArgs e)
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
        }
    }
}
