using System.IO;

namespace Uaena_Bot_v2
{
    class UserAccount
    {
        // PARAMETERS
        private string UserName { get; set; }
        private string Channel { get; set; }
        private string TwitchOAuth { get; set; }

        private string UserAccountHeaders = "UserName,Channel,TwitchOAuth";

        // File Locations 
        private string ConfigLocation = @".\Config\";
        private string UserAccountFileLocation = @".\Config\UserAccount.csv";

        // Default Constructor
        public UserAccount()
        {
            // Check for directory existence
            if (!Directory.Exists(ConfigLocation))
            {
                Directory.CreateDirectory(ConfigLocation);
            }

            // Check for LibraryFile existence
            if (!File.Exists(UserAccountFileLocation))
            {
                File.WriteAllText(UserAccountFileLocation, UserAccountHeaders);
            }
            else
            {
                LoadUserAccount();
            }
        }

        // Full Constructor
        public UserAccount(string userName, string channel, string twitchOAuth)
        {
            // PARAMETERS
            UserName = userName;
            Channel = channel;
            TwitchOAuth = twitchOAuth;
        }

        // METHODS

        // Produce a string containing all of the UserAccount's parameters 
        public string GetUserAccountCSVString()
        {
            string CSVString = string.Format("{0},{1},{2}", UserName, Channel, TwitchOAuth);
            return CSVString;
        }

        // Save UserAccount to File
        public void SaveUserAccount()
        {
            string CSVString = GetUserAccountCSVString();
            File.WriteAllText(UserAccountFileLocation, CSVString);
        }

        // Load UserAccount from File
        public void LoadUserAccount()
        {
            string[] UserAccountFile = File.ReadAllLines(UserAccountFileLocation);

            foreach (string line in UserAccountFile)
            {
                string[] UserAccountInfo = line.Split(',');

                UserName = UserAccountInfo[0];
                Channel = UserAccountInfo[1];
                TwitchOAuth = UserAccountInfo[2];
            }
        }
    }
}
