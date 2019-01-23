namespace Uaena_Bot
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ImagePreview = new System.Windows.Forms.PictureBox();
            this.GifLibary = new System.Windows.Forms.DataGridView();
            this.ImageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageKeyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnChatMsg = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnDebug = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnAddImg = new System.Windows.Forms.Button();
            this.PnlChat = new System.Windows.Forms.Panel();
            this.LblChat = new System.Windows.Forms.Label();
            this.ChatLogBG = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GifLibary)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.PnlChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.GifLibary, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.PnlChat, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(824, 511);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ImagePreview);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 232);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Preview";
            // 
            // ImagePreview
            // 
            this.ImagePreview.BackColor = System.Drawing.Color.LawnGreen;
            this.ImagePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagePreview.ImageLocation = "";
            this.ImagePreview.Location = new System.Drawing.Point(3, 22);
            this.ImagePreview.Name = "ImagePreview";
            this.ImagePreview.Size = new System.Drawing.Size(400, 207);
            this.ImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagePreview.TabIndex = 0;
            this.ImagePreview.TabStop = false;
            // 
            // GIFLibary
            // 
            this.GifLibary.AllowUserToAddRows = false;
            this.GifLibary.AllowUserToDeleteRows = false;
            this.GifLibary.AllowUserToResizeColumns = false;
            this.GifLibary.AllowUserToResizeRows = false;
            this.GifLibary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GifLibary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GifLibary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImageName,
            this.ImageKeyword,
            this.ImageLocation});
            this.GifLibary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GifLibary.Location = new System.Drawing.Point(3, 241);
            this.GifLibary.MultiSelect = false;
            this.GifLibary.Name = "GIFLibary";
            this.GifLibary.ReadOnly = true;
            this.GifLibary.RowHeadersVisible = false;
            this.GifLibary.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GifLibary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GifLibary.Size = new System.Drawing.Size(406, 232);
            this.GifLibary.TabIndex = 1;
            // 
            // ImageName
            // 
            this.ImageName.HeaderText = "Name";
            this.ImageName.Name = "ImageName";
            this.ImageName.ReadOnly = true;
            // 
            // ImageKeyword
            // 
            this.ImageKeyword.HeaderText = "Keyword";
            this.ImageKeyword.Name = "ImageKeyword";
            this.ImageKeyword.ReadOnly = true;
            // 
            // ImageLocation
            // 
            this.ImageLocation.HeaderText = "Location";
            this.ImageLocation.Name = "ImageLocation";
            this.ImageLocation.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.BtnChatMsg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(415, 479);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 29);
            this.panel1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(331, 23);
            this.textBox1.TabIndex = 1;
            // 
            // BtnChatMsg
            // 
            this.BtnChatMsg.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnChatMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BtnChatMsg.Location = new System.Drawing.Point(331, 0);
            this.BtnChatMsg.Name = "BtnChatMsg";
            this.BtnChatMsg.Size = new System.Drawing.Size(75, 29);
            this.BtnChatMsg.TabIndex = 0;
            this.BtnChatMsg.Text = "Chat";
            this.BtnChatMsg.UseVisualStyleBackColor = true;
            this.BtnChatMsg.Click += new System.EventHandler(this.BtnChatMsg_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnDebug);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.BtnAddImg);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 479);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(406, 29);
            this.panel3.TabIndex = 5;
            // 
            // BtnDebug
            // 
            this.BtnDebug.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnDebug.Location = new System.Drawing.Point(150, 0);
            this.BtnDebug.Name = "BtnDebug";
            this.BtnDebug.Size = new System.Drawing.Size(75, 29);
            this.BtnDebug.TabIndex = 3;
            this.BtnDebug.Text = "Debug";
            this.BtnDebug.UseVisualStyleBackColor = true;
            this.BtnDebug.Click += new System.EventHandler(this.BtnDebug_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button3.Location = new System.Drawing.Point(75, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 29);
            this.button3.TabIndex = 2;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "Modify";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // BtnAddImg
            // 
            this.BtnAddImg.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAddImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BtnAddImg.Location = new System.Drawing.Point(331, 0);
            this.BtnAddImg.Name = "BtnAddImg";
            this.BtnAddImg.Size = new System.Drawing.Size(75, 29);
            this.BtnAddImg.TabIndex = 0;
            this.BtnAddImg.Text = "Add";
            this.BtnAddImg.UseVisualStyleBackColor = true;
            this.BtnAddImg.Click += new System.EventHandler(this.BtnAddImg_Click);
            // 
            // PnlChat
            // 
            this.PnlChat.AutoScroll = true;
            this.PnlChat.AutoSize = true;
            this.PnlChat.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.PnlChat.Controls.Add(this.LblChat);
            this.PnlChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlChat.Location = new System.Drawing.Point(415, 3);
            this.PnlChat.Name = "PnlChat";
            this.tableLayoutPanel1.SetRowSpan(this.PnlChat, 2);
            this.PnlChat.Size = new System.Drawing.Size(406, 470);
            this.PnlChat.TabIndex = 6;
            this.PnlChat.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlChat_Paint);
            // 
            // LblChat
            // 
            this.LblChat.AutoSize = true;
            this.LblChat.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LblChat.Location = new System.Drawing.Point(0, 0);
            this.LblChat.MaximumSize = new System.Drawing.Size(390, 0);
            this.LblChat.Name = "LblChat";
            this.LblChat.Size = new System.Drawing.Size(183, 17);
            this.LblChat.TabIndex = 0;
            this.LblChat.Text = "Chat Meassages Go Here...";
            this.LblChat.Click += new System.EventHandler(this.label1_Click);
            // 
            // ChatLogBG
            // 
            this.ChatLogBG.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ChatLogBG_DoWork);
            // 
            // MainMenu
            // 
            this.AcceptButton = this.BtnChatMsg;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainMenu";
            this.Text = "Uaena_Bot - Main Menu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GifLibary)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.PnlChat.ResumeLayout(false);
            this.PnlChat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView GifLibary;
        private System.Windows.Forms.Button BtnAddImg;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnChatMsg;
        private System.Windows.Forms.Panel panel3;
        private System.ComponentModel.BackgroundWorker ChatLogBG;
        private System.Windows.Forms.Panel PnlChat;
        private System.Windows.Forms.Label LblChat;
        private System.Windows.Forms.PictureBox ImagePreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImageKeyword;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImageLocation;
        private System.Windows.Forms.Button BtnDebug;
    }
}

