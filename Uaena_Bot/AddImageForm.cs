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
    public partial class AddImageForm : Form
    {
        public string imageName { get; set; }
        public string imageKeyword { get; set; }
        public string imageLocation { get; set; }

        public AddImageForm()
        {
            InitializeComponent();
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            // Validate Image Location, Name ,and Keyword
            if ((ImageLocation.Text != String.Empty) && (ImageName.Text != String.Empty) && (ImageKeyword.Text != String.Empty))
            {
                this.imageLocation = ImageLocation.Text;
                this.imageName = ImageName.Text;
                this.imageKeyword = ImageKeyword.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("One or More Fields are Empty.");
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBrowseImage_Click(object sender, EventArgs e)
        {        
            if (OfdBrowseImage.ShowDialog() == DialogResult.OK)
            {
                ImagePreview.ImageLocation = OfdBrowseImage.FileName;

                // Store filename in to a string then print to chat
                string OfdFileName = OfdBrowseImage.FileName;
                ImageLocation.Text = OfdFileName;
            }
        }
    }
}
