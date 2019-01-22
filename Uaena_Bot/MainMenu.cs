using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uaena_Bot
{
    public partial class MainMenu : Form
    {
        // Initialise Account Settings
        UserAccount userAccount = new UserAccount();
        private string userName;
        private string channel;
        private string twitchOAuth;


        // Initialise IRC Client
        IrcClient irc;

        string chatLog = "";


        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            // Set Account Settings
            userName = userAccount.GetUserName();
            channel = userAccount.GetChannel();
            twitchOAuth = userAccount.GetTwitchOAuth();

            irc = new IrcClient("irc.twitch.tv", 6667, userName, twitchOAuth, channel);

            //irc.SendPublicChatMessage("Uaena");
            ChatLogBG.RunWorkerAsync();
        }

        private void BtnAddImg_Click(object sender, EventArgs e)
        {
            using (var addImageForm = new AddImageForm())
            {
                DialogResult addImageFormResult = addImageForm.ShowDialog();

                if (addImageFormResult == DialogResult.OK)
                {
                    string imageName = addImageForm.imageName;
                    string imageKeyword = addImageForm.imageKeyword;
                    string imageLocation = addImageForm.imageLocation;

                    DgvImage.Rows.Add(imageName,imageKeyword,imageLocation);
                }
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        
        private void BtnChatMsg_Click(object sender, EventArgs e)
        {
            chatLog += textBox1.Text + "\n\n";

            LblChat.Text = chatLog;

            PnlChat.VerticalScroll.Value = PnlChat.VerticalScroll.Maximum;

            PnlChat.PerformLayout();

            irc.SendPublicChatMessage(textBox1.Text);
        }

        private void ChatLogBG_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                
                string irc_message = irc.ReadMessage();

                chatLog += irc_message + "\n\n";
                LblChat.Text = chatLog;

                PnlChat.VerticalScroll.Value = PnlChat.VerticalScroll.Maximum;
                PnlChat.PerformLayout();
                
            }
        }

        private void LblChat_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PnlChat_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
