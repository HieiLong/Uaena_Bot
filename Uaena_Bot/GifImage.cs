using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Uaena_Bot
{
    public class GifImage
    {
        // PARAMETERS 
        private string GifName { get; set; }
        private string GifKeyword { get; set; }
        private string GifLocation { get; set; }
        private int GifDuration { get; set; }

        // Default Contructor 
        public GifImage(string gifName, string gifKeyword, string gifLocation)
        {
            // Set the GifImage's parameters
            GifName = gifName;
            GifKeyword = gifKeyword;
            GifLocation = gifLocation;

            // Calculate GifDuration
            using (Image GifFile = Image.FromFile(GifLocation))
            {
                // Check if GifFile is really a Gif file
                if (GifFile.RawFormat.Equals(ImageFormat.Gif))
                {
                    // Check if GifFile has multiple frames
                    if (ImageAnimator.CanAnimate(GifFile))
                    {
                        FrameDimension frameDimension = new FrameDimension(GifFile.FrameDimensionsList[0]);

                        int FrameCount = GifFile.GetFrameCount(frameDimension);
                        int TotalDelay = 0;
                        int CurrentDelay = 0;
                        int Index = 0;

                        // Count the TotalDelay 
                        for (int Frame = 0; Frame < FrameCount; Frame++)
                        {
                            CurrentDelay = BitConverter.ToInt32(GifFile.GetPropertyItem(20736).Value, Index) * 10;
                            TotalDelay += (CurrentDelay < 100 ? 100 : CurrentDelay);  // Minimum delay is 100 ms
                            Index += 4;
                        }

                        GifDuration = TotalDelay;
                    }
                }
            }
        }

        // Full Constructor
        public GifImage(string gifName, string gifKeyword, string gifLocation, int gifDuration)
        {
            // Set the GifImage's parameters
            GifName = gifName;
            GifKeyword = gifKeyword;
            GifLocation = gifLocation;
            GifDuration = gifDuration;
        }

        // METHODS

        // Produce a string containing all of the GifImage's parameters 
        public string GetGifInfoCSVString()
        {
            string CSVString = string.Format("{0},{1},{2},{3}", GifName, GifKeyword, GifLocation, GifDuration);
            return CSVString;
        }

        // Produce a list of the GifImage's Attributes
        public List<string> GetGifInfoList()
        {
            List<string> AttributeList = new List<string>
            {
                GifName,
                GifKeyword,
                GifLocation,
                Convert.ToString(GifDuration)
            };

            return AttributeList;
        }
    }
}
