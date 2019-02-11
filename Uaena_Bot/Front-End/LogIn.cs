using System;
using System.Windows.Forms;

namespace Uaena_Bot
{
    public partial class LogIn : Form
    {
        // Initialise UserAccount
        private UserAccount UserAccount;
        
        public LogIn()
        {
            InitializeComponent();
        }        

        private void Login_Load(object sender, EventArgs e)
        {
            UserAccount = new UserAccount();

            LogInCheck();
        }


        private void LoginBtn_Click(object sender, EventArgs e)
        {
            // Fill out UserAccount(string userName, string channel, string twitchOAuth)
            UserAccount = new UserAccount(UserName.Text, Channel.Text, TwitchOAuth.Text, RememberMe.Checked);
            LogInCheck();

            if (RememberMe.Checked)
            {
                UserAccount.SaveUserAccount();
            }
            else
            {
                UserAccount.RemoveUserAccount();
            }

            
        }

        // Check UserAccount
        private void LogInCheck()
        {           
            bool UserExist = UserAccount.GetAccountExistence();

            // Log In user
            if (UserExist)
            {
                // Fill out text fields
                string[] UserAccountInfo = UserAccount.GetUserAccountCSVString().Split(',');

                UserName.Text = UserAccountInfo[0];
                Channel.Text = UserAccountInfo[1];
                TwitchOAuth.Text = UserAccountInfo[2];
                RememberMe.Checked = Convert.ToBoolean(UserAccountInfo[3]);

                // Try to Log the user to the Twitch IRC
                bool ValidUser = LogInUser();

                if (ValidUser)
                {
                    DialogResult = DialogResult.Yes;
                    Close();
                }
            }
        }

        // Tries to validate the UserAccount by Logging in the user to Twitch IRC server
        private bool LogInUser()
        {
            try
            {
                IrcClient IrcClient = new IrcClient("irc.twitch.tv", 6667, UserName.Text, TwitchOAuth.Text, Channel.Text);
                string message = IrcClient.ReadMessage() + "\n";
                
                // Check if the user logged in to the Twitch IRC server through a keyword it sends back
                if (message.Contains("Welcome, GLHF!"))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(message);
                    return false;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }            
        }

        // Pass the UserAccount
        public UserAccount GetUserAccount()
        {
            return UserAccount;
        }
    }
}
