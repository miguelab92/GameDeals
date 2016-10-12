/// Author: Miguel Bermudez
/// Application: GameDeal app
/// Brief: Visual form to make the use of GameDealsSearch
/// app much easier to use

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
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
        /// Checks for applicable files on load
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void GameDealApp_Load(object sender, EventArgs e)
        {
            //Get a previous BAT if exists or create a new one
            LoadBAT();
            //Check status of email and scheduler
            CheckStatus();
        }

        /// <summary>
        /// Gets existing BAT file settings or creates a new one
        /// </summary>
        private void LoadBAT()
        {
            //If there is a previous BAT file
            if (File.Exists(SETTINGS_FOLDER + BAT_FILE))
            {
                //Get the current argument list
                getArgs();
            }
            else
            {
                //If directory path to exe exists
                if (Directory.Exists(SETTINGS_FOLDER))
                {
                    //If program exe exists
                    if (File.Exists(SETTINGS_FOLDER + "GameDealsChecker.exe"))
                    {
                        //Create a new BAT
                        if (SaveList())
                        {
                            MessageBox.Show("Welcome first time user! Please make sure you follow " +
                                "the README file for instructions on how to set up the program correctly.",
                                "Hello!");
                        }
                    }
                    else
                    {
                        //Missing program exe
                        MessageBox.Show("Missing necessary GameDealsChecker.exe file in Processes folder."
                            , "Missing GameDealsChecker");
                    }
                }
                else
                {
                    //Try to create a new directory
                    try
                    {
                        Directory.CreateDirectory(SETTINGS_FOLDER);
                        //Call this method again
                        LoadBAT();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\nError with directory creation.");
                    }
                }
            }
        }

        /// <summary>
        /// Checks users status in email setup and scheduling the task
        /// </summary>
        public void CheckStatus()
        {
            //Holds if we found task
            bool taskFound = false;

            //Create a new interface used to check scheduled tasks
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
                if (task.Name == Scheduler.TASK_NAME)
                {
                    taskFound = true;
                }
            }

            //Depending on whether we found the task or not we change colors
            if (taskFound)
            {
                scheduleLabel.BackColor = Color.Green;
            } else
            {
                scheduleLabel.BackColor = Color.Red;
            }

            //Check to see if an config file exists
            if (File.Exists(SETTINGS_FOLDER + ExtraSettings.APP_FILE))
            {
                //if exists we color green
                emailLabel.BackColor = Color.Green;
            }
            else
            {
                //If it doesn't exist we color red
                emailLabel.BackColor = Color.Red;
            }

            //Check if both are completed
            if ( emailLabel.BackColor == Color.Green && 
                scheduleLabel.BackColor == Color.Green )
            {
                //Hide if completed
                emailLabel.Visible = false;
                scheduleLabel.Visible = false;
                //Show credits
                moreButton.Visible = true;
            } else
            {
                //Show if incomplete
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
        /// Save the updated list
        /// </summary>
        /// <returns>Successful save results</returns>
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
                //Write out the contents of the temp string (exe and arguments)
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

            //Return results
            return saveSuccessful;
        }

        /// <summary>
        /// Sets the user feedback label to a message
        /// </summary>
        /// <param name="message">Not Used</param>
        /// <param name="isError">Not Used</param>
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

        /// <summary>
        /// If the user takes focus away from feedback we hope he read it and
        /// can freely hide it
        /// </summary>
        /// <param name="message">Not Used</param>
        /// <param name="isError">Not Used</param>
        private void userFeedback_Leave(object sender, EventArgs e)
        {
            userFeedback.Visible = false;
        }

        /// <summary>
        /// Remove all the 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gamesList_KeyDown(object sender, KeyEventArgs e)
        {
            //If the key pressed is delete
            if (e.KeyCode == Keys.Delete)
            {
                remove.PerformClick();
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

        /// <summary>
        /// Checks what key was pressed
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void inputBox_KeyDown(object sender, KeyEventArgs e)
        {
            //If it was enter or return
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                //First reset the userFeedback label
                userFeedback.Visible = false;
                //Act as if add button was clicked
                addButton.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                //First reset the userFeedback label
                userFeedback.Visible = false;
                //Act as if delete button was clicked
                remove.PerformClick();
                gamesList.SelectedIndex = -1;
                inputBox.Text = "";
                inputBox.Focus();
            }
        }

        /// <summary>
        /// Hide the possible labels when user focuses on anything
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void inputBox_Leave(object sender, EventArgs e)
        {
            userFeedback.Visible = false;
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
                        SetUserFeedback("Success!", false);
                        inputBox.Text = "";
                        inputBox.Focus();
                    }
                } else
                {
                    inputBox.Text = "";
                    SetUserFeedback("Game already in list");
                }
            }
        }

        /// <summary>
        /// Checks and adds item to list returning result
        /// </summary>
        /// <param name="game">Game to add</param>
        /// <returns>Did we successfully add game</returns>
        private bool AddToList(string game)
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
        /// Remove from list
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void remove_Click(object sender, EventArgs e)
        {
            //Holds index of current location
            int curLocation;

            //If user selected an index
            if (gamesList.SelectedIndex != -1)
            {
                //Save the current index
                curLocation = gamesList.SelectedIndex;

                //Holds a list of items to delete
                List<string> listToDelete = new List<string>();

                //Check all the items selected
                for (int i = 0; i < gamesList.Items.Count; ++i)
                {
                    //If the current item has been selected
                    if (gamesList.GetSelected(i) == true)
                    {
                        //Add it to the list to delete
                        listToDelete.Add((string)gamesList.Items[i]);
                    }
                }

                //For each item in list to delete
                foreach (string item in listToDelete)
                {
                    //Remove from local view
                    gamesList.Items.Remove(item);
                }

                if (listToDelete.Count == 1)
                {
                    //Point to new index
                    GetNewIndex(curLocation);
                }

                //Save updated list
                SaveList();
                SetUserFeedback("Success!", false);
            }
            else
            {
                //If the list contains a game that is currently 
                //written in the textBox
                if (gamesList.Items.Contains(inputBox.Text.Trim())) {
                    //Get index of game
                    curLocation = gamesList.Items.IndexOf(inputBox.Text.Trim());
                    //Remove game from list and clear the input box
                    gamesList.Items.RemoveAt(curLocation);
                    inputBox.Text = "";

                    //Point to new index
                    GetNewIndex(curLocation);

                    //Save updated list
                    SaveList();
                    SetUserFeedback("Success!", false);
                }
                else
                {
                    //If there are games we tell user they must select
                    if (gamesList.Items.Count > 0)
                    {
                        //If the input box was not empty
                        if (inputBox.Text != "")
                        {
                            //Game was not found in list
                            SetUserFeedback("Game is not in list");
                        }
                        else
                        {
                            //No item selected and nothing in inputbox
                            SetUserFeedback("Select games to delete");
                        }
                    }
                    else
                    {
                        //Game list is empty
                        SetUserFeedback("No items in list");
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
                if (curLocation > 0)
                {
                    //Our new selected index is the old index minus one
                    gamesList.SelectedIndex = curLocation - 1;
                }
                else
                {
                    //Our index is now 0
                    gamesList.SelectedIndex = 0;
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
        /// Thank you message from the developer!
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void moreButton_Click(object sender, EventArgs e)
        {
            StringBuilder tempString = new StringBuilder();

            tempString.Append("@Author: Miguel Bermudez\n");
            tempString.Append("@Version: ");
            tempString.Append(Assembly.GetExecutingAssembly().GetName().Version);
            tempString.Append("\n");
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

            moreButton.Visible = false;
        }
    }
}
