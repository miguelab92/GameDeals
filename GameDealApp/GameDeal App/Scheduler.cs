/// @author: Miguel Bermudez
/// Form to create a scheduled task

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using TaskScheduler;

namespace GameDeal_App
{
    public partial class Scheduler : Form
    {
        //Task name
        public readonly static string TASK_NAME = "GameDealsChecker";
        public readonly static string TASK_LOCATION = 
            GameDealApp.SETTINGS_FOLDER + GameDealApp.BAT_FILE;

        /// <summary>
        /// Constructor
        /// </summary>
        public Scheduler()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load up previous info on task
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void Scheduler_Load(object sender, EventArgs e)
        {
            if (ValidateSchedule())
            {
                taskExistsLabel.BackColor = Color.Lime;
            }
            //If task doesn't exist
            else 
            {
                taskExistsLabel.BackColor = Color.Red;
            }

            //Sets the mask for the input box
            timeInputBox.Mask = "00:00";
        }

        private bool ValidateSchedule()
        {
            bool taskExists = false;

            List<string> commands = new List<string>();
            List<string> output = new List<string>();
            string taskLine = "";
            commands.Add("schtasks");

            output = RunCMD(commands);

            foreach(string scheduleTask in output)
            {
                if ( scheduleTask.Contains(TASK_NAME) )
                {
                    taskExists = true;
                    taskLine = scheduleTask;
                }
            }

            if (taskExists)
            {
                MessageBox.Show(taskLine);
            }

            return taskExists;
        }
        
        private List<string> RunCMD(List<string> commands)
        {
            //Output lines and errors
            List<string> outputLines = new List<string>();
            List<string> errorLines = new List<string>();

            //Create new process using cmd.exe
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";

            //Set start information
            cmd.StartInfo.WorkingDirectory = GameDealApp.SETTINGS_FOLDER; ;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardError = true;
            cmd.StartInfo.UseShellExecute = false;

            //Start process
            cmd.Start();

            //For each command given to this method
            foreach (string command in commands)
            {
                cmd.StandardInput.WriteLine(command);
            }

            //Exit at end
            cmd.StandardInput.WriteLine("exit");

            //Flush anything left
            cmd.StandardInput.Flush();

            //Read all error and output lines
            while (!cmd.StandardOutput.EndOfStream)
            {
                outputLines.Add(cmd.StandardOutput.ReadLine());
            }

            //Close all streams
            cmd.StandardInput.Close();
            cmd.StandardOutput.Close();
            cmd.StandardError.Close();

            //wait for exit, and close all streams
            cmd.WaitForExit();

            //Return the output
            return outputLines;
        }

        /// <summary>
        /// Save schedule
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void scheduleButton_Click(object sender, EventArgs e)
        {
            if (taskExistsLabel.BackColor != Color.Lime) {
                List<string> commands = new List<string>();
                StringBuilder command = new StringBuilder();

                command.Append("schtasks /Create ");

                //Else if the timer button is checked
                if (timedButton.Checked)
                {
                    command.Append("/SC DAILY ");
                }
                //If the startup button is checked
                else
                {
                    command.Append("/SC ONSTART ");
                }

                command.Append("/TN ");
                command.Append(TASK_NAME);
                command.Append(" /TR \"");
                command.Append(TASK_LOCATION);
                command.Append('\"');

                if (timedButton.Checked)
                {
                    command.Append(" /ST ");

                    //Get scheduled time
                    DateTime scheduleTime = DateTime.Parse(timeInputBox.Text);

                    //Add 12 hours if PM is checked
                    if (timeButtonPM.Checked)
                    {
                        scheduleTime = scheduleTime.AddHours(12);
                    }

                    command.Append(scheduleTime.ToString("HH:mm"));
                }

                commands.Add(command.ToString());
                try
                {
                    RunCMD(commands);
                    taskExistsLabel.BackColor = Color.Lime;

                    //Calls the status check of the GameDealApp main form
                    (Owner as GameDealApp).CheckStatus();

                    //User feedback
                    successLabel.Visible = true;
                    successLabel.Focus();
                } catch (Exception ex)
                {
                    MessageBox.Show("Error in creation: " + ex.Message);
                }
            } else {
                taskExistsError.Visible = true;
                taskExistsError.Focus();
            }
        }

        /// <summary>
        /// Validate time
        /// </summary>
        /// <returns>results</returns>
        private bool ValidTime()
        {
            //Temp holds time
            StringBuilder tempTime = new StringBuilder();

            //Holds results
            bool isValid = false;

            //Check that if we split it by : there are two parts
            string[] parts = timeInputBox.Text.Split(':');

            //If either part is an empty string we must rebuild
            if (parts[0].Trim() == "" || parts[1].Trim() == "") {

                //If hours left empty
                if (parts[0].Trim() == "")
                {
                    parts[0] = "00";
                }

                //Append hours and :
                tempTime.Append(parts[0]);
                tempTime.Append(':');

                //If minutes left empty
                if (parts[1].Trim() == "")
                {
                    parts[1] = "00";
                }

                //Appends minutes
                tempTime.Append(parts[1]);
                //Save new text
                timeInputBox.Text = tempTime.ToString();

                //Split again with new text
                parts = timeInputBox.Text.Split(':');
            }

            //If the hours are not between 0-11 and the minutes are not between 0-59
            if (int.Parse(parts[0]) >= 0 && int.Parse(parts[0]) < 12 &&
                  int.Parse(parts[1]) >= 0 && int.Parse(parts[1]) < 60)
            {
                isValid = true;
            }

            //If not valid error
            if (!isValid)
            {
                //Show invalid time label
                invalidTimeLabel.Visible = true;
                invalidTimeLabel.Focus();
                timeInputBox.BackColor = Color.Red;
            }

            //Return results
            return isValid;
        }

        /// <summary>
        /// Delete the scheduled task
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void deleteScheduleButton_Click(object sender, EventArgs e)
        {
            if (taskExistsLabel.BackColor == Color.Lime)
            {
                List<string> commands = new List<string>();
                StringBuilder command = new StringBuilder();

                command.Append("schtasks /Delete /TN ");
                command.Append(TASK_NAME);
                command.Append(" /F");

                commands.Add(command.ToString());

                try
                {
                    RunCMD(commands);
                    taskExistsLabel.BackColor = Color.Red;

                    //Calls the status check of the GameDealApp main form
                    (Owner as GameDealApp).CheckStatus();

                    //User feedback
                    successLabel.Visible = true;
                    successLabel.Focus();

                } catch (Exception ex)
                {
                    MessageBox.Show("Error in deletion: " + ex.Message);
                }
            } else
            {
                deleteErrorLabel.Visible = true;
                deleteErrorLabel.Focus();
            }
        }

        /// <summary>
        /// Only allows digits in time textbox
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void timeInputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || !char.IsControl(e.KeyChar))
            {
                //Ignore any keys that aren't digits or control keys
                e.Handled = true;
            }
        }

        /// <summary>
        /// Time button was changed
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void timedButton_CheckedChanged(object sender, EventArgs e)
        {
            //If turned on we allow extra options if turned off we disable
            if (timedButton.Checked)
            {
                timeInputBox.Enabled = true;
                timeButtonAM.Enabled = true;
                timeButtonPM.Enabled = true;
                timeGroup.Visible = true;
                timeInputBox.Visible = true;
                timeFormatLabel.Visible = true;
                scheduleWarningLabel.Visible = true;

                //Default to AM if nothing else was checked
                if ( timeButtonAM.Checked == false && timeButtonPM.Checked == false )
                {
                    timeButtonAM.Checked = true;
                }

                timeInputBox.Focus();
            } else
            {
                timeInputBox.Enabled = false;
                timeButtonAM.Enabled = false;
                timeButtonPM.Enabled = false;
                timeGroup.Visible = false;
                timeInputBox.Visible = false;
                timeFormatLabel.Visible = false;
                scheduleWarningLabel.Visible = false;
            }
        }

        /// <summary>
        /// If user focuses on anything but the label
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void successLabel_Leave(object sender, EventArgs e)
        {
            successLabel.Visible = false;
        }

        /// <summary>
        /// If user focuses on anything but the label
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void deleteErrorLabel_Leave(object sender, EventArgs e)
        {
            deleteErrorLabel.Visible = false;
        }

        /// <summary>
        /// If user focuses on anything but the label
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void invalidTimeLabel_Leave(object sender, EventArgs e)
        {
            invalidTimeLabel.Visible = false;
        }

        /// <summary>
        /// Clears out error
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void timeInputBox_Enter(object sender, EventArgs e)
        {
            timeInputBox.BackColor = Color.White;
        }

        /// <summary>
        /// Checks that time is valid and if not errors out
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void timeInputBox_Leave(object sender, EventArgs e)
        {
            //Validate the time
            ValidTime();
        }

        private void taskExistsError_Leave(object sender, EventArgs e)
        {
            taskExistsError.Visible = false;
        }
    }
}
