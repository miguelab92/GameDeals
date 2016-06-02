/// @author: Miguel Bermudez
/// @ver: 2016.06.02
/// @name: GameDeal app
/// @desc: Visual form to make the use of GameDealsSearch
/// app much easier to use

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using TaskScheduler;

namespace GameDeal_App
{
    public partial class GameDealApp : Form
    {
        //Path to a subfolder called Processes
        public readonly static string SETTINGS_FOLDER = 
            Application.StartupPath + "/Processes/";
        //Name of .bat file
        public readonly static string BAT_FILE = "GameDealsChecker.bat";

        /// <summary>
        /// Constructor
        /// </summary>
        public GameDealApp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Checks for the files needed on load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameDealApp_Load(object sender, EventArgs e)
        {
            //If there is a previous BAT file
            if (File.Exists(SETTINGS_FOLDER + BAT_FILE))
            {
                //Get the current argument list
                getArgs();
            }
            else
            {
                //Create a new BAT
                if (SaveList())
                {
                    MessageBox.Show("Welcome first time user! Please make sure you follow " +
                        "the README file for instructions on how to set up the program correctly.", "Hello!");
                }
            }

            //Check status of email and scheduler
            CheckStatus();
        }

        /// <summary>
        /// Checks the status of email and schedule
        /// </summary>
        public void CheckStatus()
        {
            //Create a new interface for the task scheduler
            ITaskService taskService = new TaskScheduler.TaskScheduler();
            taskService.Connect();

            //Get the root folder of scheduled tasks
            ITaskFolder rootFolder = taskService.GetFolder("\\");

            //Get all registered tasks from folder
            IRegisteredTaskCollection registeredTasks = rootFolder.GetTasks(0);

            //Holds if we found task
            bool taskFound = false;

            //For each task inside list of tasks
            foreach (IRegisteredTask task in registeredTasks)
            {
                //If a task matches with this program
                if (task.Name == Scheduler.TASK_NAME)
                {
                    scheduleLabel.BackColor = Color.Green;
                    taskFound = true;
                }
            }

            //If task was not found we change color back
            if (!taskFound)
            {
                scheduleLabel.BackColor = Color.Red;
            }

            //If the value for sender is not empty
            if (File.Exists(SETTINGS_FOLDER + ExtraSettings.APP_FILE))
            {
                emailLabel.BackColor = Color.Green;
            }
            else
            {
                emailLabel.BackColor = Color.Red;
            }

            //Check if both are completed
            if ( emailLabel.BackColor == Color.Green && scheduleLabel.BackColor == Color.Green )
            {
                //Hide if completed
                emailLabel.Visible = false;
                scheduleLabel.Visible = false;
            } else
            {
                //Show if incompleted
                emailLabel.Visible = true;
                scheduleLabel.Visible = true;
            }
        }

        /// <summary>
        /// Get the arguments in the BAT file
        /// </summary>
        private void getArgs()
        {
            //Tells us if we are currently between "s
            bool readingArg = false;
            //Temporary string used to read letters and append
            StringBuilder tempStr = new StringBuilder();

            //The text of the BAT file
            string batFile = File.ReadAllText(SETTINGS_FOLDER + BAT_FILE);

            //For each letter in the BAT file
            foreach (char letter in batFile)
            {
                //If we reach a "
                if (letter == '"')
                {
                    //And we are reading an argument
                    if (readingArg)
                    {
                        //Add the read string into the listBox
                        gamesList.Items.Add(tempStr.ToString());
                        //Clear the string builder for next arg
                        tempStr.Clear();
                        //No longer reading an argument
                        readingArg = false;
                    }
                    else
                    {
                        //Now we start reading an argument
                        readingArg = true;
                    }
                }
                else
                {
                    //If we are currently reading an argument
                    if (readingArg)
                    {
                        //Append it to the word being build
                        tempStr.Append(letter);
                    }
                    //Else ignore letter
                }
            }
        }

        /// <summary>
        /// Save the list
        /// </summary>
        private bool SaveList()
        {
            //Holds result
            bool saveSuccessful = false;
            //Temporary string with all arguments
            StringBuilder tempString = new StringBuilder();

            //If list is not empty
            if (gamesList.Items.Count > 0)
            {
                //Append the command for the executable
                tempString.Append("Start GameDealsChecker.exe ");

                //For each game in the list
                foreach (string game in gamesList.Items)
                {
                    //Add quotations around it and the name
                    tempString.Append('"');
                    tempString.Append(game);
                    tempString.Append("\" ");
                }
            }
            else
            {
                //else we have no reason to call exe and instead
                //just display a message that list is empty
                tempString.Append("REM No games listed in GameDeal App\n");
                tempString.Append("@ECHO off\n");
                tempString.Append("PAUSE");
            }

            try
            {
                //If BAT exists we delete it
                if (File.Exists(SETTINGS_FOLDER + BAT_FILE))
                {
                    File.Delete(SETTINGS_FOLDER + BAT_FILE);
                }
                
                //Create a new stream writter to the new BAT file
                StreamWriter writter = File.AppendText(SETTINGS_FOLDER + BAT_FILE);
                //Write the first line
                writter.WriteLine("@ECHO");
                //Write the build string with exe and arguments
                writter.WriteLine(tempString.ToString());
                //Close file
                writter.Close();
                //Successful save
                saveSuccessful = true;
            }
            catch (Exception ex)
            {
                //Error, likely due to permissions
                MessageBox.Show(ex.Message + "\nPlease check folder settings " +
                    "to ensure program can read and write out to file");
            }

            return saveSuccessful;
        }

        /// <summary>
        /// Checks and adds item to list returning result
        /// </summary>
        /// <param name="game">Game to add</param>
        /// <returns>Did we successfully add game</returns>
        private bool AddToList ( string game )
        {
            //Holds results
            bool validAdd = false;

            //If the game is not already in the list
            if (!gamesList.Items.Contains(game))
            {
                //Add game in input box
                gamesList.Items.Add(game);
                validAdd = true;
            }

            return validAdd;
        }

        /// <summary>
        /// Add to list
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void addButton_Click(object sender, EventArgs e)
        {
            //if the input box is not empty
            if (inputBox.Text.Trim() != "")
            {
                //Attempt to add to list. If successful attemp to save
                if (AddToList(inputBox.Text.Trim()))
                {
                    //If save was successful
                    if (SaveList())
                    {
                        successLabel.Visible = true;
                        inputBox.Text = "";
                        inputBox.Focus();
                    }
                } else
                {
                    //Game is already in list
                    gameInListError.Visible = true;
                    inputBox.Text = "";
                }
            }
        }

        /// <summary>
        /// Remove from list
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void remove_Click(object sender, EventArgs e)
        {
            int curLocation;

            //If user selected an index
            if (gamesList.SelectedIndex != -1)
            {
                //Save the current index
                curLocation = gamesList.SelectedIndex;
                //Delete game at that index
                gamesList.Items.RemoveAt(gamesList.SelectedIndex);

                //Point to new index
                GetNewIndex(curLocation);

                //Save updated list
                SaveList();
                successLabel.Visible = true;
            }
            else
            {
                //If the list contains a game that is currently written in the textBox
                if (gamesList.Items.Contains(inputBox.Text.Trim())) {
                    //Get index of game
                    curLocation = gamesList.Items.IndexOf(inputBox.Text.Trim());
                    //Remove game from list and clear the input box
                    gamesList.Items.RemoveAt(curLocation);

                    //Point to new index
                    GetNewIndex(curLocation);

                    //Save updated list
                    SaveList();
                    successLabel.Visible = true;
                } else {
                    //If there are games we tell user they must select
                    if (gamesList.Items.Count > 0)
                    {
                        deleteErrorLabel.Visible = true;
                        deleteErrorLabel.Focus();
                    } else
                    {
                        //Otherwise warn user that there is no games
                        noItemLabel.Visible = true;
                        noItemLabel.Focus();
                    }
                }
            }
        }

        /// <summary>
        /// Get the new index gameList should point towards
        /// </summary>
        /// <param name="curLocation">old/current index</param>
        private void GetNewIndex ( int curLocation )
        {
            //If there still remains at least one game
            if (gamesList.Items.Count > 0)
            {
                //If the selected index was not at 0
                if (curLocation != 0)
                {
                    //Our new selected index is the old index minus one
                    gamesList.SelectedIndex = curLocation - 1;
                }
                else
                {
                    //Our index is now 0
                    gamesList.SelectedIndex = curLocation;
                }
            }
        }

        /// <summary>
        /// Extra settings
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void settingsButton_Click(object sender, EventArgs e)
        {
            ExtraSettings settingsCall = new ExtraSettings();
            settingsCall.Owner = this;
            settingsCall.ShowDialog();
        }

        /// <summary>
        /// Checks what key was pressed
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void inputBox_KeyDown(object sender, KeyEventArgs e)
        {
            //If it was enter or return
            if ( e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return )
            {
                //Act as if add button was clicked
                addButton.PerformClick();
            } else if ( e.KeyCode == Keys.Delete )
            {
                //Act as if delete button was clicked
                remove.PerformClick();
                gamesList.SelectedIndex = -1;
                inputBox.Text = "";
                inputBox.Focus();
            }
        }

        /// <summary>
        /// Calls scheduler
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void scheduleButton_Click(object sender, EventArgs e)
        {
            Scheduler scheduleCall = new Scheduler();
            scheduleCall.Owner = this;
            scheduleCall.ShowDialog();
        }

        /// <summary>
        /// Hide the delete error label when user focuses on anything else
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void deleteErrorLabel_Leave(object sender, EventArgs e)
        {
            deleteErrorLabel.Visible = false;
        }

        /// <summary>
        /// Hide the possible labels when user focuses on anything
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void inputBox_Leave(object sender, EventArgs e)
        {
            successLabel.Visible = false;
            gameInListError.Visible = false;
        }

        /// <summary>
        /// Hide the success label when user focuses on anything
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void remove_Leave(object sender, EventArgs e)
        {
            successLabel.Visible = false;
        }

        /// <summary>
        /// Hide the error label when user focuses on anything else
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void noItemLabel_Leave(object sender, EventArgs e)
        {
            noItemLabel.Visible = false;
        }

        /// <summary>
        /// Thank you message from the developer!
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void moreButton_Click(object sender, EventArgs e)
        {
            StringBuilder tempString = new StringBuilder();

            tempString.Append("@Author: Miguel Bermudez\n");
            tempString.Append("@Version: 2016.06.02\n");
            tempString.Append("\n");
            tempString.Append("Thank you so much for using this app! ");
            tempString.Append("Your support is greatly appreciated!\n");
            tempString.Append("\n");
            tempString.Append("If you have any questions, concerns or ");
            tempString.Append("suggestions for future versions, please ");
            tempString.Append("feel free to contact me at miguelab92@gmail.com\n");
            tempString.Append("\n");
            tempString.Append("This is a free open-source app. You can find and help ");
            tempString.Append("improve the code at github.com/miguelab92/GameDealApp");

            MessageBox.Show(tempString.ToString(), "Thank you!");
        }

        /// <summary>
        /// When this label is visible the success label is hidden
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void gameInListError_VisibleChanged(object sender, EventArgs e)
        {
            if (gameInListError.Visible == true)
            {
                successLabel.Visible = false;
            }
        }

        /// <summary>
        /// When this label is visible the in game list label is hidden
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void successLabel_VisibleChanged(object sender, EventArgs e)
        {
            if (successLabel.Visible == true)
            {
                gameInListError.Visible = false;
            }
        }

        /// <summary>
        /// Unselect game list when click on inputBox
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void inputBox_Enter(object sender, EventArgs e)
        {
            //Unselect game list if focusing on inputBox
            gamesList.SelectedIndex = -1;
        }
    }
}
