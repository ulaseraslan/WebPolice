using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace cs408_client2
{



    public partial class Form1 : Form {

        bool terminating = false;
        bool connect = false;
        Socket clientSocket;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            terminating = true;
            connect = false;
            Environment.Exit(0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void send_button_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string port = port_box.Text;
            string IP = "127.0.0.1";


            int portNum;
            

            if (Int32.TryParse(port, out portNum))
            {
                try
                {
                    clientSocket.Connect(IP, portNum);
              
                    connect = true;
                    //response_box.AppendText("Connected to the server!\n");

                    Thread receiveThread = new Thread(Receive);
                    receiveThread.Start();

                    string message;
                    message = request_box.Text;

                    if (message != " " )
                    {
                        Byte[] buffer = new Byte[1000];
                        buffer = Encoding.Default.GetBytes(message);
                        clientSocket.Send(buffer);
                    }
                }

                catch
                {
                    response_box.AppendText("Could not connect to the server!\n");
                }
            }
            else
            {
                response_box.AppendText("Check Port Number!");
            }


        }

        private void Receive()
        {
            while (connect)
            {

                try
                {
                    Byte[] buffer = new byte[1024];
                    clientSocket.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);

                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    response_box.AppendText( (incomingMessage) + "\n");

                    connect = false;
                    clientSocket.Close();

                    if (incomingMessage == "Access Denied!!")
                    {
                        connect = false;
                        clientSocket.Close();
                        
                    }

                }
                catch
                {
                    if (!terminating)
                    {
                        response_box.AppendText("Server has disconnected!\n");
                       
                    }
                    clientSocket.Close();
                    connect = false;
                }
            }
        }
    }
}
