using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        bool terminated = false;
        bool connected = false;
        Socket clientSocket;

        string m_splitter = "'\\'";
        string m_fName;
        string[] m_split = null; // splitted words
        byte[] m_clientData; // data to be sent

        public Client()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Client_FormClosing);

            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void Client_FormClosing(object sender, System.ComponentModel.CancelEventArgs e) // disconnect by closing client window
        {
            connected = false;
            terminated = true;
            Environment.Exit(0);
        }

        private void label_IP_Click(object sender, EventArgs e)
        {

        }

        private void textBox_IP_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_Port_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Port_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = textBox_IP.Text;

            int portNum;
            if (Int32.TryParse(textBox_Port.Text, out portNum)) 
            {
                try
                {
                    clientSocket.Connect(IP, portNum);
                    button_Connect.Enabled = false;
                    connected = true;
                    richTextBox_msg.AppendText("Connection established...\n");
                    richTextBox_msg.AppendText("Port: "+ portNum.ToString()+"\n");
                    
                    if (connected == true) { // get server details

                        string message = textBox_uname.Text;
                        button_Browse.Enabled = true;

                        if (message != "" && message.Length <= 64)
                        {
                            Byte[] buffer = new Byte[64];
                            buffer = Encoding.Default.GetBytes(message);
                            clientSocket.Send(buffer); //send username
                            richTextBox_msg.AppendText("Username sent: " + message + "\n");
                            Thread receiveThread = new Thread(Receive); //recieve message to confirm connection
                            receiveThread.Start();
                        }
                    }
                }
                catch // print error messages
                {
                    richTextBox_msg.AppendText("Problem occured while connecting...\n");
                }
            }
            else
            {
                richTextBox_msg.AppendText("Problem occured while connecting...\n");
            }

        }

        private void richTextBox_msg_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_uname_Click(object sender, EventArgs e)
        {

        }

        private void textBox_uname_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Browse_Click(object sender, EventArgs e)
        {
            char[] delimiter = m_splitter.ToCharArray();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog(); // check if the user has selected a file
            if (result == DialogResult.OK) // if selected, continue
            {
                try
                {
                    textBox_file.Text = openFileDialog.FileName; // displays path of file
                    m_split = (textBox_file.Text).Split(delimiter);
                    int limit = m_split.Length;
                    m_fName = m_split[limit - 1].ToString(); // get file name

                    if (textBox_file.Text != null)
                        button_transfer.Enabled = true; //enable transfer button to send the file to server
                }
                catch (Exception ex) // if file could not be acquired
                {
                    richTextBox_msg.AppendText("\n" + ex.Message); // display error message
                }
            }
        }

        private void textBox_file_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_file_Click(object sender, EventArgs e)
        {

        }

        private void button_transfer_Click(object sender, EventArgs e)
        {
            try
            {

                byte[] fileName = Encoding.UTF8.GetBytes(m_fName); //file name
                byte[] fileData = File.ReadAllBytes(textBox_file.Text); //file
                byte[] fileNameLen = BitConverter.GetBytes(fileName.Length); //length of file name
                m_clientData = new byte[4 + fileName.Length + fileData.Length]; //file to be sent

                //get file details to send
                richTextBox_msg.AppendText("Transferring file: " + m_fName + "\n");
                fileNameLen.CopyTo(m_clientData, 0); 
                fileName.CopyTo(m_clientData, 4); 
                fileData.CopyTo(m_clientData, 4 + fileName.Length);

                //send file to server
                clientSocket.Send(m_clientData);
                richTextBox_msg.AppendText("The file has been transferred: " + m_fName + "\n");
            }
            catch (Exception ex) //fail to send
            {
                richTextBox_msg.AppendText("\n" + ex.Message);
            }
        }

        private void Receive()
        {
            if(connected)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    clientSocket.Receive(buffer); // recieve message from server

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                    richTextBox_msg.AppendText("Server: " + incomingMessage + "\n"); // display server message
                    button_Connect.Enabled = true;
                }
                catch
                {
                    if (!terminated) // disconnection occured
                    {
                        richTextBox_msg.AppendText("The server has disconnected\n"); // display disconnection error to user
                        button_Connect.Enabled = true;
                    }

                    //clientSocket.Close();
                    //connected = false;
                }
            }
        }
    }
}
