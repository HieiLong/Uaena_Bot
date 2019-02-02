using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Uaena_Bot_v2
{
    public class GifLibrary
    {
        // PARAMETERS
        private Dictionary<int, GifImage> Library = new Dictionary<int, GifImage>();

        private string LibraryHeaders = "ID,Name,Keyword,Location,Duration";

        // File Locations 
        private string ConfigLocation = @".\Config\";
        private string LibraryFileLocation = @".\Config\GifLibrary.csv";

        // Default Constructor
        public GifLibrary()
        {
            // Check for directory existence
            if (!Directory.Exists(ConfigLocation))
            {
                Directory.CreateDirectory(ConfigLocation);
            }

            // Check for LibraryFile existence
            if (!File.Exists(LibraryFileLocation))
            {
                File.WriteAllText(LibraryFileLocation, LibraryHeaders);
            }
            else
            {
                LoadGifLibrary();
            }
        }

        // METHODS

        // Produce a list of all Gifs in the Library
        public Dictionary<int, GifImage> GetGifList()
        {
            return Library;
        }

        // Add GifImage to Dictionary
        public bool AddGifImage(GifImage gifImage)
        {
            int GifID = Library.Count();
            Library.Add(GifID, gifImage);

            // Check if the added GifImage now exist in the Library
            if (Library.ContainsKey(GifID) && Library[GifID] == gifImage)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Remove GifImage from Dictionary
        public bool RemoveGifImage(int GifID)
        {
            Library.Remove(GifID);

            // Check if a GifImage with an associated GifID exist in the Library
            if (Library.ContainsKey(GifID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Save GifLibrary to File
        public void SaveGifLibrary()
        {
            StringBuilder GifLibrary = new StringBuilder();


            foreach (KeyValuePair<int, GifImage> Gif in Library)
            {
                string GifImage = string.Format("{0},{1}", Gif.Key, Gif.Value.GetGifInfoCSVString());
                GifLibrary.AppendLine(GifImage);
            }

            File.WriteAllText(LibraryFileLocation, GifLibrary.ToString());
        }

        // Load GifLibrary from File
        public void LoadGifLibrary()
        {
            string[] GifLibraryFile = File.ReadAllLines(LibraryFileLocation);

            foreach (string line in GifLibraryFile)
            {
                string[] GifImageInfo = line.Split(',');

                Library.Add(Convert.ToInt32(GifImageInfo[0]),
                    new GifImage(GifImageInfo[1],
                    GifImageInfo[2],
                    GifImageInfo[3],
                    Convert.ToInt32(GifImageInfo[4])));
            }
        }
    }
}
