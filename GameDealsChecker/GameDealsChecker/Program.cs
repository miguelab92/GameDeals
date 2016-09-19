/// @author: Miguel Bermudez
/// @name: GameDealChecker
/// @desc: Check /r/GameDeals for the games passed to this program as
/// arguments. If game is found email the user.

using Logger;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace GameDealsChecker
{
    class Program
    {
        //Program name for email
        private readonly static string PROGRAM_NAME = "GameDealsChecker";

        //All settings from app.config
        private static string aReceiver;
        private static string aCC;
        private static string website = "https://www.reddit.com/r/gamedeals";
        private static string gameFound = " is currently on /r/GameDeals!";

        [STAThread]
        static void Main(string[] args)
        {
            //Log file
            LogFile log = new LogFile(PROGRAM_NAME);

            //If we have arguments
            if (GetConfigSettings(ref log) && args.Length > 0)
            {
                //Creates string that will hold the HTML file
                string pageHTML = GetWebPage();

                //For each game targetted we check against the pageHTML for a mention
                foreach (string targetGame in args)
                {
                    CheckForGame(pageHTML, targetGame, ref log);
                }

                //If the log had an error, a found game message, or we are debugging
                if (log.GetLog().Contains(LogFile.GetErrorCode()) || 
                    log.GetLog().Contains(gameFound))
                {
                    
                    //Attempt to email
                    try
                    {
                        EmailUser(ref log);
                    }
                    catch (Exception ex)
                    {
                        log.Log(ex.Message, true);
                    }
                }

                //Save log
                log.SaveLog();

            }
            else
            {
                //Check the argument count
                if (args.Count() == 0)
                {
                    log.Log("No arguments were passed at time of call", true);
                    Console.Write("Add at least one game for program to function.\n");
                    Console.Write("Press any key to continue...\n");
                    Console.ReadKey();
                }

                //Show that we had an error with the config file
                log.SaveLog();
            }
        }

        /// <summary>
        /// Gets the webpage HTML
        /// </summary>
        /// <returns>Webpage HTML</returns>
        private static string GetWebPage()
        {
            //Creates string that will hold the HTML file
            string pageHTML = "";

            //Create a web browser
            WebBrowser wBrowser = new WebBrowser();

            //Surpress script error
            wBrowser.ScriptErrorsSuppressed = true;

            //Navigate to the URL
            wBrowser.Navigate(website);

            //When the document is completely loaded we copy the HTML into pageHTML for parsing
            while (wBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            //Save the entire webpage into pageHTML
            pageHTML = wBrowser.DocumentText;
            pageHTML = pageHTML.ToLower();

            return pageHTML;
        }

        /// <summary>
        /// Check for the game in the html file
        /// </summary>
        /// <param name="pageHTML">Page to check in</param>
        /// <param name="targetGame">Game to check for</param>
        /// <param name="log">log</param>
        private static void CheckForGame(string pageHTML, string targetGame, ref LogFile log)
        {
            //Holds previous letter to game and next letter after game
            int prevLetterIndx;
            int nextLetterIndx;

            if (pageHTML.Contains(targetGame.ToLower()))
            {
                prevLetterIndx = pageHTML.IndexOf(targetGame.ToLower()) - 1;
                nextLetterIndx = pageHTML.IndexOf(targetGame.ToLower()) + targetGame.Length;

                //We try to check the previous and next characters in where the game was found
                //If they are anything other than characters or digits we should be okay. If they
                //are characters or digits they might be part of an url
                try
                {
                    if (!char.IsLetterOrDigit(pageHTML[prevLetterIndx]) &&
                        (!char.IsLetterOrDigit(pageHTML[nextLetterIndx]) ||
                         pageHTML[nextLetterIndx] == '-' || pageHTML[nextLetterIndx] == ':'))
                    {
                        log.Log(targetGame + gameFound);
                    }
                }
                catch {
                    //Catch any out of bounds
                }
            }
        }

        /// <summary>
        /// Email user the game was found/error
        /// </summary>
        /// <param name="log">log</param>
        private static void EmailUser(ref LogFile log)
        {
            //WebClient
            SmtpClient smtpC;
            
            //Create the SMTP Client and set all the setting from app
            smtpC = new SmtpClient("smtp.gmail.com", 587);

            //Enter your credentials here to send the email (* is a placeholder)
            smtpC.Credentials = new NetworkCredential("GameDealsChecker@gmail.com", "*" );
            smtpC.EnableSsl = true;

            //Create MailMessage and set all the setting from app
            MailMessage msg = new MailMessage("GameDealsChecker@gmail.com", aReceiver);
            msg.IsBodyHtml = true;
            msg.Subject = PROGRAM_NAME;

            //If settings has a non-empty CC
            if (aCC != "")
            {
                //Split the config value by commas
                string[] ccEmails = aCC.Split(',');
                //For each email address in the resulting split
                foreach (string emailAddress in ccEmails)
                {
                    //Add to CC list
                    msg.CC.Add(emailAddress);
                }
            }

            //Attempt to mail
            log.MailLog(smtpC, msg);
        }

        /// <summary>
        /// Get app data and return whether we were successful or not
        /// </summary>
        /// <param name="log">Log</param>
        /// <returns>True if successful</returns>
        private static bool GetConfigSettings(ref LogFile log)
        {
            //False until we get everything working
            bool retVal = false;

            // Get core settings. Any failure skips to return false.
            if (
                GetConfigSetting("receiver", ref aReceiver, ref log) &&
                GetConfigSetting("CC", ref aCC, ref log) )
            {
                //Successfully got all app data
                retVal = true;
            }

            //Return result
            return retVal;
        }

        /// <summary>
        /// Gets the configuration settings from App.config
        /// </summary>
        /// <param name="aSettingKey">Key to lookup</param>
        /// <param name="aValue">Reference where we save data into</param>
        /// <param name="log">Log</param>
        /// <returns>True if successful</returns>
        private static bool GetConfigSetting(string aSettingKey, ref string aValue, ref LogFile log)
        {
            bool retVal = true; //Holds results. Assumes success

            //Attempt to get the data
            aValue = ConfigurationManager.AppSettings[aSettingKey];

            //If aValue is null (no data from App.config)
            if (aValue == null)
            {
                //Log the key lookup used
                log.Log("Error retrieving core " + aSettingKey +
                                    " configuration setting; Application cannot start.", true);
                //Could not retrieve info
                retVal = false;
            }

            //Return results
            return retVal;
        }
    }
}
