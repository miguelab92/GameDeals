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
        private readonly static string TASK_NAME = "GameDealsChecker";

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
                    taskExistsLabel.BackColor = Color.Green;

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
            execAction.Path = AppDomain.CurrentDomain.BaseDirectory + "GameDealsChecker.bat";
            execAction.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;

            try {
                //Same task name to update old one. 6 means update or create!
                rootFolder.RegisterTaskDefinition(TASK_NAME, newTask, 6,
                    null, null, _TASK_LOGON_TYPE.TASK_LOGON_NONE);

                //Task now exists
                taskExistsLabel.BackColor = Color.Green;

                //User feedback
                MessageBox.Show("Task successfully created!");

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
                //Ensure at least one of AM or PM is checked
                if (timeButtonAM.Checked || timeButtonPM.Checked)
                {
                    //Check that time is valid
                    if (validTime())
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
                    } else
                    {
                        MessageBox.Show("Invalid time");
                    }
                }
            } else 
            {
                MessageBox.Show("Please select a scheduling method");
            }
        }

        /// <summary>
        /// Validate time
        /// </summary>
        /// <returns>results</returns>
        private bool validTime ()
        {
            //Holds results
            bool isValid = false;

            if (timeInputBox.Text != "")
            {
                //Check that if we split it by : there are two parts
                string[] parts = timeInputBox.Text.Split(':');

                if (int.Parse(parts[0]) >= 0 && int.Parse(parts[0]) < 12 &&
                      int.Parse(parts[1]) >= 0 && int.Parse(parts[1]) < 60)
                {
                    isValid = true;
                }
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
            if (taskExistsLabel.BackColor == Color.Green)
            {
                //Create a new interface for the task scheduler
                ITaskService taskService = new TaskScheduler.TaskScheduler();
                taskService.Connect();

                //Get root folder
                ITaskFolder taskFolder = taskService.GetFolder("\\");
                try
                {
                    //Delete task
                    taskFolder.DeleteTask(TASK_NAME, 0);
                    MessageBox.Show("Task successfully deleted!");
                    taskExistsLabel.BackColor = Color.Red;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                MessageBox.Show("No task to delete!");
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
            } else
            {
                timeInputBox.Enabled = false;
                timeButtonAM.Enabled = false;
                timeButtonPM.Enabled = false;
            }
        }

        private void taskExistsLabel_MouseHover(object sender, EventArgs e)
        {

        }
    }
}
