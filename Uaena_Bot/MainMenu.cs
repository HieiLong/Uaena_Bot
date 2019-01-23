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

            // Create Instance of the IRC CLient 
            irc = new IrcClient("irc.twitch.tv", 6667, userName, twitchOAuth, channel);
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
            chatLog += String.Format("{0}: {1} \n\n", userName, textBox1.Text);

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
                string irc_userName = "";
                string message = "";

                if (irc_message.Contains("PRIVMSG"))
                {
                    int intIndexParseSign = irc_message.IndexOf('!');
                    irc_userName = irc_message.Substring(1, intIndexParseSign - 1);

                    intIndexParseSign = irc_message.IndexOf(" :");
                    message = irc_message.Substring(intIndexParseSign + 2);

                    chatLog += String.Format("{0}: {1} \n\n", irc_userName, message);
                }
                else
                {
                    chatLog += irc_message + "\n\n";
                }

                LblChat.Text = chatLog;

                PnlChat.VerticalScroll.Value = PnlChat.VerticalScroll.Maximum;
                PnlChat.PerformLayout();

                // Loop Through the Rows in DgvImage
                int imageCount = DgvImage.Rows.Count;

                if (imageCount >= 1)
                {
                    for (int i = 0; i < imageCount; i++)
                    {
                        if (DgvImage.Rows[i].Cells[1].Value.ToString().Contains(message))
                        {
                            string imageLocation = DgvImage.Rows[i].Cells[2].Value.ToString();
                            ImagePreview.ImageLocation = imageLocation;
                        }
                    }

                }
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

        // DEBUG - Shows Selected Row in DgvImage
        private void BtnDebug_Click(object sender, EventArgs e)
        {
            int imageCount = DgvImage.Rows.Count;

            if (imageCount >= 1)
            {
                int selectedCell = DgvImage.CurrentCell.RowIndex;

                string imageLocation = DgvImage.Rows[selectedCell].Cells[2].Value.ToString();

                string imageName = DgvImage.Rows[selectedCell].Cells[0].Value.ToString();

                string imageKeyword = DgvImage.Rows[selectedCell].Cells[1].Value.ToString();

                // DEBUG - sample chat message 
                string chatMsg = "IU";
                if (imageKeyword.Contains(chatMsg.ToLower()) || imageKeyword.Contains(chatMsg.ToUpper()))
                {
                    ImagePreview.ImageLocation = imageLocation;
                }
                else
                {
                    ImagePreview.ImageLocation = "";
                }

                string imageDetails = String.Format("Name/Keyword: {0}  | ({1}) \n Location: {2}", imageName, imageKeyword, imageLocation);

                MessageBox.Show(imageDetails);
            }
            else
            {
                MessageBox.Show("Please Add Some Images.");
            }

            
        }
    }
}
