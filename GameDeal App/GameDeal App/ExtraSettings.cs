/// @author: Miguel Bermudez
/// Extra settings for GameDeal app

using System;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using Logger;

namespace GameDeal_App
{
    public partial class ExtraSettings : Form
    {
        private readonly string APP_FILE = "GameDealsChecker.exe.config";

        public ExtraSettings()
        {
            InitializeComponent();
            GetData();
        }

        /// <summary>
        /// Get previous data from config file
        /// </summary>
        private void GetData()
        {
            //If file already exists we can read
            if ( File.Exists(APP_FILE))
            {
                //Parse into lines
                string[] configFile = File.ReadAllLines(APP_FILE);

                //For each line in the parsed file
                foreach (string line in configFile )
                {
                    //If it contains sender then we look for email
                    if (line.Contains("sender")) {
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
                        //Likely an error with formatting. Can be ignored
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
        private string GetValue(string line)
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
                //Append to tempText
                tempText.Append(line[indx]);
                ++indx;
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
            if (emailInput.Text != "" && passInput.Text != "")
            {
                StreamWriter appFile;
                StringBuilder tempString = new StringBuilder();

                //Write out copy of config file with added values

                tempString.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n");
                tempString.Append("<configuration>\n");
                tempString.Append("   <startup>\n");
                tempString.Append("     <supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.5.2\"\n/>");
                tempString.Append("   </startup>\n");
                tempString.Append("  <appSettings>\n" );
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
                if (copyButton.Checked)
                {
                    tempString.Append(copyInputText.Text);
                }
                tempString.Append("\"/>\n");
                tempString.Append("    <add key=\"thoroughSearch\" value=\"");
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
                    if (File.Exists(APP_FILE)) {
                        File.Delete(APP_FILE);
                    }
                    appFile = File.AppendText(APP_FILE);
                    appFile.Write(tempString.ToString());
                    //Close file
                    appFile.Close();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //Close form
                this.Close();
            } else
            {
                MessageBox.Show("Email and/or Password input is empty");
            }
            
        }

        /// <summary>
        /// Copy cutton was changed
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        private void copyButton_CheckedChanged(object sender, EventArgs e)
        {
            //If it was checked we enable text writting otherwise disable it
            if (copyButton.Checked)
            {
                copyInputText.Enabled = true;
            } else
            {
                copyInputText.Enabled = false;
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
            //Temp test log
            LogFile testLog = new LogFile("GameDeal App Test");

            //Set up MailMessage based on input
            MailMessage testMsg = new MailMessage(emailInput.Text, emailInput.Text);
            testMsg.Subject = "GameDeal App Test";
            testMsg.IsBodyHtml = true;

            //Set up SmtpClient based on input
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential(emailInput.Text, passInput.Text);
            client.EnableSsl = true;

            //Try to mail
            try {
                testLog.MailLog(client, testMsg);
                MessageBox.Show("Test email send. Please check your inbox (allow a few minutes)");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nError testing email. Check your input.");
            }
        }
    }
}
