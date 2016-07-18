/// @author: Miguel Bermudez
/// Form to create a scheduled task

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TaskScheduler;

namespace GameDeal_App
{
    public partial class Scheduler : Form
    {
        //Holds task we are working on
        ITaskDefinition newTask;
        //Task name
        public readonly static string TASK_NAME = "GameDealsChecker";

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
            //Create a new interface for the task scheduler
            ITaskService taskService = new TaskScheduler.TaskScheduler();
            taskService.Connect();
            //Get the root folder of scheduled tasks
            ITaskFolder rootFolder = taskService.GetFolder("\\");
            
            //Get all registered tasks from folder
            IRegisteredTaskCollection registeredTasks = rootFolder.GetTasks(0);

            //For each task inside list of tasks
            foreach (IRegisteredTask task in registeredTasks)
            {
                //If a task matches with this program
                if (task.Name == TASK_NAME)
                {
                    //Use existing task as base
                    newTask = task.Definition;
                    taskExistsLabel.BackColor = Color.Lime;

                    //Check the trigger(s) for the type and start time/delay
                    foreach (ITrigger trigger in task.Definition.Triggers)
                    {
                        //If it was type Schedule on the hour
                        if (trigger.Type == (_TASK_TRIGGER_TYPE2) 2 )
                        {
                            //Check the time button as true
                            timedButton.Checked = true;
                            try
                            {
                                timeInputBox.Text = DateTime.Parse(trigger.StartBoundary).ToString();
                            }
                            catch (Exception ex)
                            {
                                //***CHANGE THIS: will get annoying if it doesn't work***
                                MessageBox.Show(ex.Message);
                            }
                        }
                        //Else if the type was on boot
                        else if (trigger.Type == (_TASK_TRIGGER_TYPE2) 9 )
                        {
                            startupButton.Checked = true;
                        }
                        //User has manually changed settings and its neither option
                        else
                        {}
                    }
                }
            }

            //If task doesn't exist
            if (taskExistsLabel.BackColor == Color. Red)
            {
                //Create new task
                newTask = taskService.NewTask(0);
            }

            //Sets the mask for the input box
            timeInputBox.Mask = "00:00";
        }

        /// <summary>
        /// Create or update the task
        /// </summary>
        /// <param name="type">Type of task (9 or 2)</param>
        /// <param name="startTime">Time to use as start time</param>
        private void CreateSchedule(int type, DateTime startTime)
        {
            //Definitions
            string timeFormat = "yyyy-MM-ddThh:mm:ss";
            string idleTime = XmlConvert.ToString(TimeSpan.FromMinutes(1));

            ITriggerCollection triggers;
            ITrigger trigger;
            IActionCollection actions;
            IAction action;
            IExecAction execAction;
            ITaskService taskService = new TaskScheduler.TaskScheduler();
            taskService.Connect();
            ITaskFolder rootFolder = taskService.GetFolder(@"\");

            /*******Use this for testing! **********/
            MessageBox.Show(taskService.ConnectedUser);

            /* Create or update task */

            //Task settings
            newTask.RegistrationInfo.Description = "Runs GameDealsChecker program";
            newTask.RegistrationInfo.Author = Environment.UserName;
            newTask.Settings.Enabled = true;
            newTask.Settings.Hidden = false;
            newTask.Settings.Compatibility = _TASK_COMPATIBILITY.TASK_COMPATIBILITY_V2;
            newTask.Settings.ExecutionTimeLimit = idleTime;
            newTask.Settings.RunOnlyIfIdle = false;

            // Triggers
            triggers = newTask.Triggers;

            //MAIN DECIDER ON WHEN TRIGGER GOES OFF (Check enum definition)
            trigger = triggers.Create((_TASK_TRIGGER_TYPE2)type);

            //Enable trigger to run and set start time
            trigger.Enabled = true;
            trigger.StartBoundary = startTime.ToString(timeFormat);

            // Actions
            actions = newTask.Actions;
            // Run exec
            action = actions.Create((_TASK_ACTION_TYPE)0);
            execAction = action as IExecAction;

            //Run path + GameDealsChecker.bat from folder path
            execAction.Path = GameDealApp.SETTINGS_FOLDER + GameDealApp.BAT_FILE;
            execAction.WorkingDirectory = GameDealApp.SETTINGS_FOLDER;

            try {
                //Same task name to update old one. 6 means update or create!
                rootFolder.RegisterTaskDefinition(TASK_NAME, newTask, 6,
                    null, null, _TASK_LOGON_TYPE.TASK_LOGON_NONE);

                //Task now exists
                taskExistsLabel.BackColor = Color.Lime;

                //Calls the status check of the GameDealApp main form
                (Owner as GameDealApp).CheckStatus();

                //User feedback
                successLabel.Visible = true;
                successLabel.Focus();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Save schedule
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void scheduleButton_Click(object sender, EventArgs e)
        {
            //If the startup button is checked
            if (startupButton.Checked ) 
            {
                CreateSchedule(9, DateTime.Now);
            }
            //Else if the timer button is checked
            else if (timedButton.Checked)
            {
                //Check that time is valid
                if (ValidTime())
                {
                    try
                    {
                        //Get scheduled time
                        DateTime scheduleTime = DateTime.Parse(timeInputBox.Text);

                        //Add 12 hours if PM is checked
                        if (timeButtonPM.Checked)
                        {
                            scheduleTime.AddHours(12);
                        }

                        //Call create scheudle
                        CreateSchedule(2, scheduleTime);
                    }
                    catch (Exception ex)
                    {
                        //Show error (likely parse)
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                }
            } else 
            {
                //Shouldn't get here!
                MessageBox.Show("Please select a scheduling method");
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
            //First be sure task exists
            if (taskExistsLabel.BackColor == Color.Lime)
            {
                ITaskService taskService = new TaskScheduler.TaskScheduler();
                taskService.Connect();

                //Get root folder
                ITaskFolder taskFolder = taskService.GetFolder("\\");
                try
                {
                    //Delete task
                    taskFolder.DeleteTask(TASK_NAME, 0);

                    //Calls the status check of the GameDealApp main form
                    (Owner as GameDealApp).CheckStatus();

                    //Update labels
                    taskExistsLabel.BackColor = Color.Red;
                    successLabel.Visible = true;
                    successLabel.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                //Show error label and give it focus
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
    }
}
