using System;
using System.Collections.Generic;
using System.IO;
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

            // Execute BackgroundWorkers
            ChatLogBG.RunWorkerAsync();
            ImagePreviewBG.RunWorkerAsync();

            // Check if Directory Exist
            if (!Directory.Exists(@".\Uaena_Data\"))
            {
                Directory.CreateDirectory(@".\Uaena_Data\");
            }
            
            // Check if GifList.csv Exist
            if (File.Exists(@".\Uaena_Data\GifList.csv"))
            {
                // Read GifList
                string[] GifListLines = File.ReadAllLines(@".\Uaena_Data\GifList.csv");
                
                foreach (string line in GifListLines)
                {
                    string[] GifList = line.Split(',');

                    GifLibary.Rows.Add(GifList[0], GifList[1], GifList[2]);
                }
            }
            
        }

        // Create a Form to Add a GIF to the GifLibrary
        private void BtnAddImg_Click(object sender, EventArgs e)
        {
            using (var addImageForm = new AddImageForm())
            {
                DialogResult addImageFormResult = addImageForm.ShowDialog();

                if (addImageFormResult == DialogResult.OK)
                {
                    // Return the Values of the Image's Name, Keyword and Location to Local Variables 
                    string imageName = addImageForm.imageName;
                    string imageKeyword = addImageForm.imageKeyword;
                    string imageLocation = addImageForm.imageLocation;

                    // Add the Image's Values to the GifLibrary
                    GifLibary.Rows.Add(imageName,imageKeyword,imageLocation);
                }
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        
        // Send the Message to the Chatroom
        private void BtnChatMsg_Click(object sender, EventArgs e)
        {
            // Append the Message to the chatLog Variable
            chatLog += String.Format("{0}: {1} \n\n", userName, textBox1.Text);

            // Overwrite the Values of LblChat with chatLog
            LblChat.Text = chatLog;

            //Scroll to the Bottom of PnlChat and Display the Latest Message
            PnlChat.VerticalScroll.Value = PnlChat.VerticalScroll.Maximum;
            PnlChat.PerformLayout();

            // Send Message using the IRC Client
            irc.SendPublicChatMessage(textBox1.Text);
        }

        // Analyse the Chatroom for any IRC Messages
        private void ChatLogBG_DoWork(object sender, DoWorkEventArgs e)
        {
            // Infinite Loop
            while (true)
            {
                // Initialise Local Variables to Separate the Username and the Message from Raw IRC Message
                string irc_message = irc.ReadMessage();
                string irc_userName = "";
                string message = "";

                // Format the Message if it is Sent by a User
                if (irc_message.Contains("PRIVMSG"))
                {
                    // Isolate the Username Within the Raw IRC Message
                    int intIndexParseSign = irc_message.IndexOf('!');
                    irc_userName = irc_message.Substring(1, intIndexParseSign - 1);

                    // Isolate the Message Within the Raw IRC Message
                    intIndexParseSign = irc_message.IndexOf(" :");
                    message = irc_message.Substring(intIndexParseSign + 2);

                    // Append the Message to the chatLog Variable
                    chatLog += String.Format("{0}: {1} \n\n", irc_userName, message);
                }
                else
                {
                    // Append the Message to the chatLog Variable
                    chatLog += irc_message + "\n\n";
                }

                // Overwrite the Values of LblChat with chatLog
                LblChat.Text = chatLog;

                //Scroll to the Bottom of PnlChat and Display the Latest Message
                PnlChat.VerticalScroll.Value = PnlChat.VerticalScroll.Maximum;
                PnlChat.PerformLayout();

                if (message != String.Empty)
                {
                    // Split Every Word in the Message
                    string[] words = message.Split(' ');

                    // Count Total Rows in GifLibrary
                    int imageCount = GifLibary.Rows.Count;


                    // For each Word in the Message, Loop Through and Change the ImageLocation in ImagePreview
                    foreach (string word in words)
                    {
                        if (imageCount >= 1)
                        {
                            for (int i = 0; i < imageCount; i++)
                            {
                                if (GifLibary.Rows[i].Cells[1].Value.ToString().Contains(word.ToLower()) ||
                                    GifLibary.Rows[i].Cells[1].Value.ToString().Contains(word.ToUpper()))
                                {
                                    string imageLocation = GifLibary.Rows[i].Cells[2].Value.ToString();
                                    ImagePreview.ImageLocation = imageLocation;
                                }
                            }
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
            // Check if Directory Exist
            if (!Directory.Exists(@".\Uaena_Data\"))
            {
                Directory.CreateDirectory(@".\Uaena_Data\");
            }

            // Check if GifList.csv Exist
            if (File.Exists(@".\Uaena_Data\GifList.csv"))
            {
                // Read GifList
                string[] GifListLines = File.ReadAllLines(@".\Uaena_Data\GifList.csv");

                foreach (string line in GifListLines)
                {
                    string[] GifList = line.Split(',');

                    GifLibary.Rows.Add(GifList[0], GifList[1], GifList[2]);
                }
            }
        }

        // Save GifLibrary to a CSV File on Exit
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            StringBuilder GifList = new StringBuilder();

            foreach (DataGridViewRow row in GifLibary.Rows)
            {
                string gifName = row.Cells[0].Value.ToString();
                string gifKeyword = row.Cells[1].Value.ToString();
                string gifLocation = row.Cells[2].Value.ToString();
                string gifCSV = String.Format("{0},{1},{2}", gifName, gifKeyword, gifLocation);
                GifList.AppendLine(gifCSV);
            }

            File.WriteAllText(@".\Uaena_Data\GifList.csv", GifList.ToString());

        }

        // Empty the ImagePreview after 7 Secounds (* Might Want to Change How this Works to Maximise Performance)
        private void ImagePreviewBG_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (ImagePreview.ImageLocation != String.Empty || ImagePreview.ImageLocation != "")
                {
                    System.Threading.Thread.Sleep(7000);
                    ImagePreview.ImageLocation = "";
                }
            }
        }
    }
}
