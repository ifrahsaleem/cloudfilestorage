namespace Client
{
    partial class Client
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
            this.label_IP = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.label_Port = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.button_Connect = new System.Windows.Forms.Button();
            this.richTextBox_msg = new System.Windows.Forms.RichTextBox();
            this.label_uname = new System.Windows.Forms.Label();
            this.textBox_uname = new System.Windows.Forms.TextBox();
            this.button_Browse = new System.Windows.Forms.Button();
            this.textBox_file = new System.Windows.Forms.TextBox();
            this.label_file = new System.Windows.Forms.Label();
            this.button_transfer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(80, 41);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(24, 17);
            this.label_IP.TabIndex = 0;
            this.label_IP.Text = "IP:";
            this.label_IP.Click += new System.EventHandler(this.label_IP_Click);
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(110, 38);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(250, 22);
            this.textBox_IP.TabIndex = 1;
            this.textBox_IP.TextChanged += new System.EventHandler(this.textBox_IP_TextChanged);
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(66, 80);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(38, 17);
            this.label_Port.TabIndex = 2;
            this.label_Port.Text = "Port:";
            this.label_Port.Click += new System.EventHandler(this.label_Port_Click);
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(110, 77);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(250, 22);
            this.textBox_Port.TabIndex = 3;
            this.textBox_Port.TextChanged += new System.EventHandler(this.textBox_Port_TextChanged);
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(185, 156);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(97, 28);
            this.button_Connect.TabIndex = 4;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // richTextBox_msg
            // 
            this.richTextBox_msg.Location = new System.Drawing.Point(417, 38);
            this.richTextBox_msg.Name = "richTextBox_msg";
            this.richTextBox_msg.Size = new System.Drawing.Size(410, 454);
            this.richTextBox_msg.TabIndex = 5;
            this.richTextBox_msg.Text = "";
            this.richTextBox_msg.TextChanged += new System.EventHandler(this.richTextBox_msg_TextChanged);
            // 
            // label_uname
            // 
            this.label_uname.AutoSize = true;
            this.label_uname.Location = new System.Drawing.Point(27, 118);
            this.label_uname.Name = "label_uname";
            this.label_uname.Size = new System.Drawing.Size(77, 17);
            this.label_uname.TabIndex = 6;
            this.label_uname.Text = "Username:";
            this.label_uname.Click += new System.EventHandler(this.label_uname_Click);
            // 
            // textBox_uname
            // 
            this.textBox_uname.Location = new System.Drawing.Point(110, 115);
            this.textBox_uname.Name = "textBox_uname";
            this.textBox_uname.Size = new System.Drawing.Size(250, 22);
            this.textBox_uname.TabIndex = 7;
            this.textBox_uname.TextChanged += new System.EventHandler(this.textBox_uname_TextChanged);
            // 
            // button_Browse
            // 
            this.button_Browse.Enabled = false;
            this.button_Browse.Location = new System.Drawing.Point(110, 369);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(97, 28);
            this.button_Browse.TabIndex = 8;
            this.button_Browse.Text = "Browse";
            this.button_Browse.UseVisualStyleBackColor = true;
            this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
            // 
            // textBox_file
            // 
            this.textBox_file.Location = new System.Drawing.Point(110, 319);
            this.textBox_file.Name = "textBox_file";
            this.textBox_file.Size = new System.Drawing.Size(250, 22);
            this.textBox_file.TabIndex = 9;
            this.textBox_file.TextChanged += new System.EventHandler(this.textBox_file_TextChanged);
            // 
            // label_file
            // 
            this.label_file.AutoSize = true;
            this.label_file.Location = new System.Drawing.Point(70, 322);
            this.label_file.Name = "label_file";
            this.label_file.Size = new System.Drawing.Size(34, 17);
            this.label_file.TabIndex = 10;
            this.label_file.Text = "File:";
            this.label_file.Click += new System.EventHandler(this.label_file_Click);
            // 
            // button_transfer
            // 
            this.button_transfer.Enabled = false;
            this.button_transfer.Location = new System.Drawing.Point(263, 369);
            this.button_transfer.Name = "button_transfer";
            this.button_transfer.Size = new System.Drawing.Size(97, 28);
            this.button_transfer.TabIndex = 11;
            this.button_transfer.Text = "Transfer";
            this.button_transfer.UseVisualStyleBackColor = true;
            this.button_transfer.Click += new System.EventHandler(this.button_transfer_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 526);
            this.Controls.Add(this.button_transfer);
            this.Controls.Add(this.label_file);
            this.Controls.Add(this.textBox_file);
            this.Controls.Add(this.button_Browse);
            this.Controls.Add(this.textBox_uname);
            this.Controls.Add(this.label_uname);
            this.Controls.Add(this.richTextBox_msg);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.label_Port);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.label_IP);
            this.Name = "Client";
            this.Text = "Client App";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.RichTextBox richTextBox_msg;
        private System.Windows.Forms.Label label_uname;
        private System.Windows.Forms.TextBox textBox_uname;
        private System.Windows.Forms.Button button_Browse;
        private System.Windows.Forms.TextBox textBox_file;
        private System.Windows.Forms.Label label_file;
        private System.Windows.Forms.Button button_transfer;
    }
}

