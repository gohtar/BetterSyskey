using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BetterSyskey
{
    public partial class StartupKeyForm : Form
    {
        public StartupKeyForm()
        {
            InitializeComponent();
        }  

        private void okBtn_Click(object sender, EventArgs e)
        {         
            if(passwordInput.Text == "")
            {
                clearPasswordInputs();
                showPasswordMismatchMessage();
                return;
            }

            if(passwordInput.Text != confirmInput.Text)
            {
                clearPasswordInputs();
                showPasswordMismatchMessage();
                return;
            }

            KittyForm f = new KittyForm();
            f.setPassword(passwordInput.Text);
            f.ShowDialog();
        }

        private void startupRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            startupGroupBox.Enabled = startupRadioBtn.Checked;
            generatedGroupBox.Enabled = !startupRadioBtn.Checked;
        }

        /// <summary>
        /// Clear the password input text areas
        /// </summary>
        private void clearPasswordInputs()
        {
            passwordInput.Text = "";
            confirmInput.Text = "";
        }

        
        /// <summary>
        /// Show the passwords entered do not match message.
        /// </summary>
        private void showPasswordMismatchMessage()
        {
            MessageBox.Show("The password entered does not match the confirmation password.\nPlease re-enter the passwords.", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
