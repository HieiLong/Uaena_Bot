using System;
using System.Windows.Forms;

namespace Uaena_Bot
{
    public partial class LogInForm : Form
    {
        // Initialise UserAccount
        UserAccount UserAccount;
        
        public LogInForm()
        {
            InitializeComponent();
        }        

        private void Login_Load(object sender, EventArgs e)
        {
            LogInCheck();
        }

        private void LogInCheck ()
        {
            UserAccount = new UserAccount();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            // Fill out UserAccount(string userName, string channel, string twitchOAuth)
            UserAccount = new UserAccount(Username.Text, Channel.Text, TwitchOAuth.Text, RememberMe.Checked);
            if (RememberMe.Checked)
            {
                UserAccount.SaveUserAccount();
            }
            else
            {
                UserAccount.RemoveUserAccount();
            }
        }
    }
}
