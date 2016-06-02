/// @author: Miguel Bermudez
/// Extra settings for GameDeal app

using System;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace GameDeal_App
{
    public partial class ExtraSettings : Form
    {
        //Name of config file
        public readonly static string APP_FILE = "GameDealsChecker.exe.config";

        //Constructor
        public ExtraSettings()
        {
            InitializeComponent();
            GetData();
        }

        /// <summary>
        /// Get current data from config file
        /// </summary>
        private void GetData()
        {
            //If file already exists we can read
            if ( File.Exists(GameDealApp.SETTINGS_FOLDER + APP_FILE))
            {
                //Parse into lines
                string[] configFile = File.ReadAllLines(GameDealApp.SETTINGS_FOLDER + APP_FILE);

                //For each line in the parsed file
                foreach (string line in configFile )
                {
                    //If it contains sender then we look for email
                    if (line.Contains("sender\"")) {
                        emailInput.Text = GetValue(line);
                    }
                    //If it contains senderPass we search of password
                    if (line.Contains("senderPass"))
                    {
                        passInput.Text = GetValue(line);
                    }
                    //If it contains CC we search for CCs
                    if (line.Contains("CC"))
                    {
                        copyInputText.Text = GetValue(line);
                        //If it wasn't empty then we check the button
                        if (copyInputText.Text != "")
                        {
                            copyButton.Checked = true;
                        }
                    }
                    //If line contains thoroughSearch then we check it
                    if (line.Contains("thoroughSearch"))
                    {
                        try {
                            //Check if thorough search was checked or not
                            if (Convert.ToBoolean(GetValue(line)))
                            {
                                thoroughButton.Checked = true;
                            }
                        }
                        //User might have messed with formatting. Can be
                        //ignored as we still highly recommend false
                        catch
                        {
                        }
                    }
                }
            } 
        }

        /// <summary>
        /// Parse the value of line
        /// </summary>
        /// <param name="line">Line with value to get</param>
        /// <returns>Value</returns>
        public static string GetValue(string line)
        {
            //value=" is 7 characters long
            int CHARS_TIL_READ = 7;
            //Used to walk through value
            int indx;
            //Builds the value
            StringBuilder tempText = new StringBuilder();

            //Gets the beginning position of value to read
            indx = line.IndexOf("value") + CHARS_TIL_READ;

            //While the " hasn't been closed
            while (line[indx] != '"')
            {
                //Append to tempText and increase index
                tempText.Append(line[indx++]);
            }

            //Return value
            return tempText.ToString();
        }

        /// <summary>
        /// Save file
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (emailInput.Text != "")
            {
                if (validateFields())
                {
                    StreamWriter appFile;
                    StringBuilder tempString = new StringBuilder();

                    //Write out copy of config file with added values

                    tempString.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n");
                    tempString.Append("<configuration>\n");
                    tempString.Append("   <startup>\n");
                    tempString.Append("     <supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.5.2\"\n/>");
                    tempString.Append("   </startup>\n");
                    tempString.Append("  <appSettings>\n");
                    tempString.Append("  <!-- Settings -->\n");
                    tempString.Append("    <add key=\"mailserver\" value=\"smtp.gmail.com\"/>\n");
                    tempString.Append("    <add key=\"portNum\" value=\"587\"/>\n");
                    tempString.Append("    <add key=\"sender\" value=\"");
                    tempString.Append(emailInput.Text);
                    tempString.Append("\"/>\n");
                    tempString.Append("    <add key=\"senderPass\" value=\"");
                    tempString.Append(passInput.Text);
                    tempString.Append("\"/>\n");
                    tempString.Append("    <add key=\"receiver\" value=\"");
                    tempString.Append(emailInput.Text);
                    tempString.Append("\"/>\n");
                    tempString.Append("    <add key=\"CC\" value=\"");
                    //If we should include the copy list
                    if (copyButton.Checked)
                    {
                        tempString.Append(copyInputText.Text);
                    }
                    tempString.Append("\"/>\n");
                    tempString.Append("    <add key=\"thoroughSearch\" value=\"");
                    //If thorough search was checked
                    if (thoroughButton.Checked)
                    {
                        tempString.Append("true");
                    }
                    else
                    {
                        tempString.Append("false");
                    }
                    tempString.Append("\"/>\n");
                    tempString.Append("    <add key=\"debugging\" value=\"false\"/>\n");
                    tempString.Append("    <add key=\"webPage\" value=\"https://www.reddit.com/r/gamedeals\"/>\n");
                    tempString.Append("  </appSettings>\n");
                    tempString.Append("</configuration>");

                    try
                    {
                        //If there is currently a .bat file
                        if (File.Exists(GameDealApp.SETTINGS_FOLDER + APP_FILE))
                        {
                            //Delete it
                            File.Delete(GameDealApp.SETTINGS_FOLDER + APP_FILE);
                        }
                        //Create a new .bat file
                        appFile = File.AppendText(GameDealApp.SETTINGS_FOLDER + APP_FILE);
                        //Write out to file
                        appFile.Write(tempString.ToString());
                        //Close file
                        appFile.Close();
                        //Calls the status check of the GameDealApp main form
                        (this.Owner as GameDealApp).CheckStatus();
                        //Close form
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                //If email field is empty assume user wants to delete file
                try
                {
                    //If there is currently a .bat file
                    if (File.Exists(GameDealApp.SETTINGS_FOLDER + APP_FILE))
                    {
                        //Delete it
                        File.Delete(GameDealApp.SETTINGS_FOLDER + APP_FILE);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //Calls the status check of the GameDealApp main form
                (this.Owner as GameDealApp).CheckStatus();
                //Close form
                 this.Close();
            }
        }

        /// <summary>
        /// Validate all the fields
        /// </summary>
        /// <returns>Results</returns>
        private bool validateFields()
        {
            //Holds results assumes false
            bool validFields = false;
            
            //If no available fields are empty or errored out
            if (emailInput.BackColor != Color.Red && emailInput.Text != "" && 
                passInput.Text != "" && (!copyButton.Checked ||
               (copyButton.Checked && copyInputText.Text != "" && 
               copyInputText.BackColor != Color.Red)))
            {
                //We have valid fields
                validFields = true;
            }
            else
            {
                //If email is empty warn the user with color
                if (emailInput.Text == "")
                {
                    emailInput.BackColor = Color.Red;
                    emailError.Visible = true;
                }
                //If password is empty warn user with color
                if (passInput.Text == "")
                {
                    passInput.BackColor = Color.Red;
                    passError.Visible = true;
                }
                //If cc is empty and button was checked warn user
                if (copyButton.Checked && copyButton.Text == "")
                {
                    copyButton.BackColor = Color.Red;
                    ccError.Visible = true;
                }
            }

            //Return results
            return validFields;
        }
        
        /// <summary>
        /// Validates email passed
        /// </summary>
        /// <param name="email">Email to check</param>
        /// <returns>Result</returns>
        private bool ValidEmail(string email)
        {
            //Holds result
            bool isEmail;
            
            //Try to create a MailAddress with email
            try
            {
                MailAddress emailAddress = new MailAddress(email);
                //If we match then success
                isEmail = emailAddress.Address == email;
            } catch
            {
                //Else catch the failure
                isEmail = false;
            }

            //Return results
            return isEmail;
        }

        /// <summary>
        /// Copy button was checked or unchecked
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        private void copyButton_CheckedChanged(object sender, EventArgs e)
        {
            if (copyButton.Checked)
            {
                //Enable text box
                copyInputText.Enabled = true;
                copyInputText.Visible = true;
                separationLabel.Visible = true;
                copyButton.Text = "    CC:";
                copyInputText.Focus();
            } else
            {
                //Disable textbox
                copyInputText.Enabled = false;
                copyInputText.Visible = false;
                separationLabel.Visible = false;
                copyButton.Text = "Send copies to other emails";
                //If it was errored we also clear text
                if (copyInputText.BackColor == Color.Red)
                {
                    copyInputText.Text = "";
                    //Reset color and error
                    ccError.Visible = false;
                    copyInputText.BackColor = Color.White;
                }
            }
        }


        /// <summary>
        /// If thorough search was changed
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        private void thoroughButton_CheckedChanged(object sender, EventArgs e)
        {
            //If it was checked then we WARN them again
            if (thoroughButton.Checked)
            {
                thoroughWarning.ForeColor = Color.Red;
            } else
            {
                thoroughWarning.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Tests the email function with the inputs from user
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        private void testButton_Click(object sender, EventArgs e)
        {
            if (validateFields())
            {
                //Set up MailMessage based on input
                MailMessage testMsg = new MailMessage(emailInput.Text, emailInput.Text);
                testMsg.Subject = "GameDeal App Test";
                testMsg.IsBodyHtml = true;
                testMsg.Body = "Success! Email is working as intended!";

                //Set up SmtpClient based on input
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new NetworkCredential(emailInput.Text, passInput.Text);
                client.EnableSsl = true;

                try
                {
                    //Try to mail
                    client.Send(testMsg);
                    //Dispose of opened resources
                    testMsg.Dispose();
                    MessageBox.Show("Test email send. Please check your inbox (allow up to a few minutes)");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nError testing email. Check your input and try again.");
                }
            }
        }

        /// <summary>
        /// Reset error when user enters this field
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        private void emailInput_Enter(object sender, EventArgs e)
        {
            //Reset color and hide error
            emailInput.BackColor = Color.White;
            emailError.Visible = false;
        }

        /// <summary>
        /// Check if email is valid when user attempts to exit this field
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        private void emailInput_Leave(object sender, EventArgs e)
        {
            //Check email and if not valid warn user
            if (emailInput.Text != "" && !ValidEmail(emailInput.Text))
            {
                emailInput.BackColor = Color.Red;
                emailError.Visible = true;
            }
        }

        /// <summary>
        /// Reset error when user enters this field
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        private void passInput_Enter(object sender, EventArgs e)
        {
            //Reset color and hide error
            passInput.BackColor = Color.White;
            passError.Visible = false;
        }

        /// <summary>
        /// Reset error when user enters this field
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        private void copyInputText_Enter(object sender, EventArgs e)
        {
            //Reset color and hide error
            copyInputText.BackColor = Color.White;
            ccError.Visible = false;
        }

        /// <summary>
        /// Check if emails are valid when user attempts to exit this field
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        private void copyInputText_Leave(object sender, EventArgs e)
        {
            //Holds results
            bool allEmailsValid = true;

            //If the field is empty then it must be invalid
            if ( copyInputText.Text == "")
            {
                allEmailsValid = false; 
                
            } else
            {
                //Split emails by the space
                string[] emailsList = copyInputText.Text.Split(',');
                //For each email we read
                foreach (string email in emailsList)
                {
                    //If emails are still valid
                    if (allEmailsValid)
                    {
                        //Check current email
                        allEmailsValid = ValidEmail(email);
                    }
                }
            }

            //If at any point we found invalid emails
            if (!allEmailsValid)
            {
                //Change color to red and warn user
                copyInputText.BackColor = Color.Red;
                ccError.Visible = true;
            }
        }

        /// <summary>
        /// Prevents whitespaces
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        private void emailInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Prevent whitespaces
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        private void copyInputText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
