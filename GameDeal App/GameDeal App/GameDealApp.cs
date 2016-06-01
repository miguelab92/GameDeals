/// @author: Miguel Bermudez
/// @ver: 2016.05.30
/// @name: GameDeal app
/// @desc: Visual form to make the use of GameDealsSearch
/// app much easier to use

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GameDeal_App
{
    public partial class GameDealApp : Form
    {
        //Name of .bat file
        private static string BAT_FILE = "GameDealsChecker.bat";

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
            if (File.Exists(BAT_FILE))
            {
                //Get the current argument list
                getArgs();
            } else
            {
                //Create a new BAT
                if (SaveList())
                {
                    MessageBox.Show("Welcome first time user! Please make sure you follow " +
                        "the README file for instructions on how to set up the program correctly.");
                }
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
            string batFile = File.ReadAllText(BAT_FILE);

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
                if (File.Exists(BAT_FILE))
                {
                    File.Delete(BAT_FILE);
                }
                
                //Create a new stream writter to the new BAT file
                StreamWriter writter = File.AppendText(BAT_FILE);
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
        /// Add the written item into the list
        /// </summary>
        private void AddToList ()
        {
            //if the input box is not empty
            if (inputBox.Text != "")
            {
                //If the game is not already in the list
                if (!gamesList.Items.Contains(inputBox.Text))
                {
                    //Add game in input box
                    gamesList.Items.Add(inputBox.Text);
                }
            }
        }

        /// <summary>
        /// Add to list
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void addButton_Click(object sender, EventArgs e)
        {
            //Add text to list, save and clear text box
            AddToList();
            SaveList();
            inputBox.Text = "";
            inputBox.Focus();
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

                //Save updated list
                SaveList();
            }
            else
            {
                if (gamesList.Items.Count > 0)
                {
                    MessageBox.Show("Select a game from the list to delete");
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
            }
        }

        /// <summary>
        /// Calls scheduler
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void scheduleButton_Click(object sender, EventArgs e)
        {
            Scheduler settingsCall = new Scheduler();
            settingsCall.ShowDialog();
        }
    }
}
