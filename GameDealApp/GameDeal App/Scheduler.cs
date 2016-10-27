/// @author: Miguel Bermudez
/// @brief: Form to create a scheduled task

using Microsoft.Win32.TaskScheduler;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameDeal_App
{
    public partial class Scheduler : Form
    {
        //Task name
        public readonly static string TASK_NAME = "GameDealsChecker";
        //Task location
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
            //Checks if task exists
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

        /// <summary>
        /// Set the existing schedule's time
        /// </summary>
        /// <param name="parseLine">Line with info of schedule</param>
        private void SetExistingTime(string parseLine)
        {
            //Holds the time
            StringBuilder timeLine = new StringBuilder();
            int hour = int.Parse(parseLine.Substring(0, 2));
            //Holds if we are using AM or PM
            bool isAM = false;

            //If we fail simply don't show the time
            try
            {
                //If the first half is less than 12
                if (hour < 12)
                {
                    //We are dealing with AM
                    isAM = true;

                    //Check the length of the string to cover for single digit
                    if (hour.ToString().Length < 2)
                    {
                        timeLine.Append('0');
                    }

                    timeLine.Append(hour.ToString());
                }
                else
                {
                    //Lower hour down to under 12
                    hour -= 12;

                    //Check the length of the string to cover for single digit
                    if (hour.ToString().Length < 2)
                    {
                        timeLine.Append('0');
                    }

                    timeLine.Append(hour.ToString());
                }

                //Add the : and minutes
                timeLine.Append(parseLine.Substring(2, 3));

                //Select that we are working with time
                timedButton.Checked = true;
                //Set the time
                timeInputBox.Text = timeLine.ToString();

                //Set the AM or PM button
                if (isAM)
                {
                    timeButtonAM.Checked = true;
                }
                else
                {
                    timeButtonPM.Checked = true;
                }
            }
            catch
            {
                //Ignore errors
            }
        }

        /// <summary>
        /// Create or update the task
        /// </summary>
        /// <param name="type">Type of task (9 or 2)</param>
        /// <param name="startTime">Time to use as start time</param>
        private bool ValidateSchedule()
        {
            //Holds the results of whether task exists
            bool taskExists = false;
            
            //Create a new interface for the task scheduler
            using (TaskService taskService = new TaskService())
            {
                //Look for task
                Task task = taskService.GetTask(TASK_NAME);

                //If there is no task
                if (task == null)
                {
                    taskExistsLabel.BackColor = Color.Red;
                    taskExists = false;
                }
                else
                {
                    taskExistsLabel.BackColor = Color.Lime;
                    taskExists = true;

                    //Check the triggers to find if we had a time trigger
                    //otherwise we assume it is using on logon
                    foreach ( Trigger trigger in task.Definition.Triggers)
                    {
                        if (trigger.TriggerType == TaskTriggerType.Daily )
                        {
                            //Get the time to display
                            SetExistingTime(trigger.StartBoundary.
                                TimeOfDay.ToString(@"hh\:mm"));
                        }
                    }
                }
            }

            //Return result
            return taskExists;
        }

        /// <summary>
        /// Save schedule
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void scheduleButton_Click(object sender, EventArgs e)
        {
            //If a task doesn't already exist
            if (taskExistsLabel.BackColor != Color.Lime)
            {
                CreateSchedule();
            }
            else
            {
                SetUserFeedback("Schedule already exists!");
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
                SetUserFeedback("Time is not valid");
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
            //First be sure task exists
            if (taskExistsLabel.BackColor == Color.Lime)
            {
                DeleteSchedule();
            } else
            {
                SetUserFeedback("Schedule doesn't exist!");
            }
        }

        /// <summary>
        /// Create a scheduled task to run GitChecker
        /// </summary>
        private void CreateSchedule()
        {
            //Create a new interface for the task scheduler
            using (TaskService taskService = new TaskService())
            {
                //Get the folder for the root
                TaskFolder rootFolder = taskService.RootFolder;

                //Create a new task with some properties
                TaskDefinition taskDef = taskService.NewTask();
                taskDef.RegistrationInfo.Description =
                    "Automate GameDealChecker";
                taskDef.RegistrationInfo.Author = "GameDeal App";
                taskDef.Principal.LogonType = TaskLogonType.InteractiveToken;
                taskDef.Settings.Enabled = true;
                taskDef.Settings.StartWhenAvailable = true;

                //If user wants time based trigger
                if (timedButton.Checked)
                {
                    //Get the hour and time
                    int hour = int.Parse(timeInputBox.Text.Remove(2, 3));
                    int min = int.Parse(timeInputBox.Text.Substring(
                            timeInputBox.Text.IndexOf(':') + 1, 2));

                    //If PM button is used then we add 12 hours
                    if (timeButtonPM.Checked)
                    {
                        hour += 12;
                    }

                    //Use a temporary date of today
                    DateTime tempDate = DateTime.Now;
                    //Create a start time
                    DateTime startTime = new DateTime(tempDate.Year,
                        tempDate.Month, tempDate.Day, hour, min, 0);

                    //If the start time is before right now
                    if (startTime < DateTime.Now)
                    {
                        //Add a day to the temp date and recreate the 
                        //start time
                        tempDate.AddDays(1);
                        startTime = new DateTime(tempDate.Year, tempDate.Month,
                            tempDate.Day, hour, min, 0);
                    }

                    //Use a daily trigger using the start time we created
                    DailyTrigger dailyTrigger =
                        (DailyTrigger)taskDef.Triggers.Add(new DailyTrigger());
                    dailyTrigger.StartBoundary = startTime;
                }
                else
                {
                    //Create trigger. Runs on start up after 10 minutes
                    LogonTrigger logTrigger =
                        (LogonTrigger)taskDef.Triggers.Add(new LogonTrigger());
                    logTrigger.Delay = TimeSpan.FromMinutes(10);
                }

                //Create action of running GitChecker
                taskDef.Actions.Add(new ExecAction(TASK_LOCATION, null,
                    GameDealApp.SETTINGS_FOLDER));

                //Create the task
                rootFolder.RegisterTaskDefinition(TASK_NAME, taskDef,
                    TaskCreation.CreateOrUpdate, null, null,
                    TaskLogonType.InteractiveToken, null);
            }

            //Check the schedule
            if (ValidateSchedule())
            {
                //If it works we close run the status on the main form
                (Owner as GameDealApp).CheckStatus();
                this.Close();
            }
            else
            {
                SetUserFeedback("Error in creating schedule...");
            }
        }

        /// <summary>
        /// Delete GitChecker task
        /// </summary>
        private void DeleteSchedule()
        {
            //Create a new interface for the task scheduler
            using (TaskService taskService = new TaskService())
            {
                //Find and delete the task
                taskService.RootFolder.DeleteTask(TASK_NAME);

                if (ValidateSchedule())
                {
                    SetUserFeedback("Error in deleting schedule...");
                } else
                {
                    (Owner as GameDealApp).CheckStatus();
                    SetUserFeedback("Success!", false);
                }
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
                if ( timeButtonAM.Checked == false && 
                    timeButtonPM.Checked == false )
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
        private void userFeedback_Leave(object sender, EventArgs e)
        {
            userFeedback.Visible = false;
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

        private void SetUserFeedback(string message, bool isError = true)
        {
            //Set the user feedback to message and visible
            userFeedback.Visible = true;
            userFeedback.Text = message;

            //If its an error
            if (isError)
            {
                //Take focus away and make message red
                userFeedback.ForeColor = Color.Red;
            }
            else
            {
                //Otherwise just show message
                userFeedback.ForeColor = Color.Green;
            }
        }
    }
}
