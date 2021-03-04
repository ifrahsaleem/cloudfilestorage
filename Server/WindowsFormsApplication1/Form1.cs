using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();
        static string dbpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"DataBase.txt");
        FileStream createDB = new FileStream(dbpath, FileMode.Create);
        List<String> userNames = new List<String>();
        
        bool terminating = false;
        bool listening = false;
        string folderName = "";

        public Form1()
        {
            createDB.Close();
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog(); 

            DialogResult result = folderBrowserDialog1.ShowDialog(); // opens the file browser and waits for the user to select file
            if (result == DialogResult.OK) 
            {   
                // if we succesfully select a file then we store directory
                folderName = folderBrowserDialog1.SelectedPath;
                textBox_path.Text = folderName;

            }

        }

        private void btn_listen_Click(object sender, EventArgs e)
        {
            int serverPort;

            if (Int32.TryParse(textBox_message.Text, out serverPort)) // establishing server connection
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                listening = true;
                btn_listen.Enabled = false;
                textBox_path.Enabled = true;
                btn_directory.Enabled = true;

                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                logs.AppendText("Started listening on port: " + serverPort + "\n");

            }
            else
            {
                logs.AppendText("Please check port number \n");
            }

        }

        private void Accept()
        {
            while (listening) 
            {
                try
                {
                    Socket newClient = serverSocket.Accept(); // establishing connection with client
                    clientSockets.Add(newClient);
                    logs.AppendText("A client is connected.\n");

                    Thread receiveThread = new Thread(() => Receive(newClient)); 
                    receiveThread.Start();
                    btn_directory.Enabled = true;
                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        logs.AppendText("The socket stopped working.\n");
                    }

                }
            }
        }

        private void Receive(Socket thisClient) 
        {
            bool connected = true;

            Byte[] buffer = new Byte[64];
            thisClient.Receive(buffer);

            string username = Encoding.Default.GetString(buffer); // get username from client
            username = username.Substring(0, username.IndexOf("\0"));
            logs.AppendText("Client: " + username + "\n");
            if (userNames.Contains(username)) // if the user is already connected
            {
                logs.AppendText("Client already connected");
                Byte[] buffer_2 = Encoding.Default.GetBytes("The username is already taken! Please try reconnecting again."); // error message
                thisClient.Send(buffer_2);
                thisClient.Close(); //reject connection
            }
            else // new user
            {
                userNames.Add(username); // keep track of connected users

                while (connected && !terminating)
                {
                    Byte[] clientData = new Byte[1024 * 5000]; // recieve file from client
                    int receivedBytesLen = thisClient.Receive(clientData);
                    int fileNameLen = BitConverter.ToInt32(clientData, 0); 
                    string fileName = Encoding.ASCII.GetString(clientData, 4, fileNameLen);
                    string[] arr = fileName.Split('.');
                    string temp = arr[0]; // root of file name i.e "file" of file.txt
                    fileName = username + "-" + fileName; // combine username with filename to add to database

                    try
                        {
                            int filecounter = 0; // keep track of duplicate files
                            const Int32 BufferSize = 128;
                            FileStream readDB = new FileStream(dbpath, FileMode.Open, FileAccess.Read, FileShare.Read); // open database

                            using (var streamReader = new StreamReader(readDB, Encoding.UTF8, true, BufferSize)) // read database
                            {
                                String line;
                                while ((line = streamReader.ReadLine()) != null)
                                {
                                     string[] fname;
                                     string[] words;
                                
                                if(line.Count(x => x == '-') == 2) // if there are 3 files with same name
                                {
                                    words = line.Split(' '); //seperate username
                                    fname = words[1].Split('-'); //seperate username from filename i.e user1 from user1-file.txt
                                    string root = fname[1].Split('.')[0]; // remove extension (.txt) to get the root of file name 

                                    if (temp == root && username == words[0]) // if filenames and usernames are same
                                    {
                                        filecounter++;
                                    }

                                }
                                else // if there are no duplicate files
                                {
                                    // similar split to get root of filename
                                    words = line.Split(' ');
                                    string required = words[1];
                                    fname = required.Split('-');
                                    string root = fname[1].Split('.')[0];

                                    if (temp == root && username == words[0]) // if filenames and usernames are same
                                    {
                                        filecounter++;
                                    }
                                }

                                }
                            
                           }
                           if (filecounter != 0) //if we found duplicate files
                           {
                              if(filecounter < 10)
                            {
                                fileName = username + "-" + temp + "-0" + filecounter + ".txt"; // if <10 duplicates add 0 to beginning!
                            }
                              else

                                fileName = username + "-" + temp + "-" + filecounter + ".txt"; // if >10 duplicates no 0 needed to be added!
                           }
                       
                        BinaryWriter bWrite = new BinaryWriter(File.Open(folderName + "/" + fileName, FileMode.Append)); // save file
                        logs.AppendText("Saving file... " + fileName + "\n"); // inform user
                        bWrite.Close();
                        Byte[] title = new UTF8Encoding(true).GetBytes((username + " " + fileName + "\n"));
                        File.AppendAllText(dbpath, username + " " + fileName + Environment.NewLine + DateTime.Now); // write file details on database

                        logs.AppendText("Added " + fileName + " to Database\n");
                        readDB.Close();
                    }
                    catch(Exception e)
                    {
                        if (!terminating)
                        {
                            logs.AppendText("A client has disconnected\n");
                            e.ToString();
                        }
                        thisClient.Close();
                        clientSockets.Remove(thisClient);
                        connected = false;
                    }
                }

            }
           
        }


        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }

    }
}
