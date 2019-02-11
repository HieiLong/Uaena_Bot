using System;
using System.Windows.Forms;

namespace Uaena_Bot
{
    public partial class ChatBot : Form
    {
        // PARAMETERS
        private UserAccount UserAccount;
        private IrcClient IrcClient;


        public ChatBot()
        {
            InitializeComponent();
        }

        private void ChatBot_Load(object sender, EventArgs e)
        {
            GetUserAccount();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            if (UserAccount.RemoveUserAccount())
            {
                MessageBox.Show("User Successfully Logged Out. Good Bye!");
                Close();
            }
        }

        private void GetUserAccount()
        {
            // Verify user
            using (var LogIn = new LogIn())
            {
                var DialogResult = LogIn.ShowDialog();

                if (DialogResult == DialogResult.Yes)
                {
                    UserAccount = LogIn.GetUserAccount();
                    string[] UserAccountInfo = UserAccount.GetUserAccountCSVString().Split(',');

                    LoggedInLbl.Text = string.Format("Logged In: {0} @ {1}", UserAccountInfo[0], UserAccountInfo[1]);
                }
                else
                {
                    Close();
                }
            }
        }
    }
}
