using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace projetest
{
    class Program
    {
        /** Port for the proxy */
        private static int port;
        /** Socket for client connections */
        private static Socket socket;

        /** Create new socket object*/
        public static void init(int p)
        {

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            port = p;
            Console.WriteLine("Port number is: " + p.ToString());

            try
            {
                // TODO: Create endpoint, socket then bind and start listening for connections

                IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, port); // Create an endpoint like 127.0.0.1:port (IPAddress+port) 
                socket.Bind(endPoint); // Binding endpoint
                socket.Listen(3);


            }
            catch (IOException e)
            {
                Console.WriteLine("Error creating socket: " + e);
                return;
            }
        }

        public static void handle(Socket client)
        {
            Socket server = null;

            HttpRequest request = null;
            HttpResponse response = null;

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);

            /* Process request. If there are any exceptions, then simply
             * return and end this thread. This unfortunately means the
             * client will hang for a while, until it timeouts. */

            /* Read request */
            try
            {
                // TODO: Receive request text from client by using buffer as always (client socket sent as parameter to the function from main)

               
                    Byte[] buffer = new byte[1024]; // To convert coming message to human readable type
                    client.Receive(buffer);

                    Console.WriteLine("Reading request..." + "\n");
                    string incomingmessage = Encoding.Default.GetString(buffer);
                    incomingmessage = incomingmessage.Substring(0, incomingmessage.IndexOf("\0")); // To prevent from unmeaningful messages when text is empty
                    Console.WriteLine( incomingmessage + "\n");

                request = new HttpRequest(buffer); //TODO: error will be gone when you create request object with buffer created above.

                string fileName = @"C:\Users\ulas.eraslan\Desktop\VSProjects\cs408_webpolice\BannedWords.txt";
                string[] lines = File.ReadAllLines(fileName);

                for (int i =0; i< lines.Length; i++)
                {
                    if (request.getURL().Contains(lines[i]))
                    {
                        client.Send(Encoding.ASCII.GetBytes("Access Denied!!"));
                        client.Close();
                        return;
                    }
                }

                Console.WriteLine("Got request...");
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading request from client: " + e);
                return;
            }

            /* Send request to web page */
            try
            {
                // TODO: crate new socket to "server" socket (server = new..) and connect to the host with determined port with this socket (Hint:use HttpRequest getHost() and getPort())
                //then send request which is HttpRequest object now through the server socket (hint: use toString() for string buffer conversion setup for socket communication.

                

                IPHostEntry hostEntry;
                hostEntry = Dns.GetHostEntry(request.getHost());

                var ip = hostEntry.AddressList[0];

                IPEndPoint request_endpoint = new IPEndPoint(ip, request.getPort());
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                server.Connect(request_endpoint);

                string request_url = request.toString();
                server.Send(Encoding.ASCII.GetBytes(request.toString()));
                



            }
            catch (IOException e)
            {
                Console.WriteLine("Error writing request to server: " + e);
                return;
            }

            /* Read response and forward it to client */
            try
            {
                //TODO: Create new buffer, receive response from host using server socket, convert it to HttpResponse object (response = new...), 
                //then send it to client with "client" socket (hint: HttpResponse's toString function for converting response to string.


                Byte[] buffer_response = new byte[1024]; // To convert coming message to human readable type
                server.Receive(buffer_response);

                response = new HttpResponse(buffer_response);

                client.Send(Encoding.ASCII.GetBytes(response.toString()));

              

                 
                client.Close();
                server.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("Error writing response to client: " + e);
            }
        }

        /** Get input from command prompt and start server */
        public static void Main(string[] args)
        {
            int myPort = 0;
            string val;
            Console.Write("Enter port: ");
            val = Console.ReadLine();

            // TODO: Parse port to integer 
            myPort = Int32.Parse(val);
             
           

            init(myPort);

            /** Main loop. Listen for incoming connections and spawn a new thread for handling them */
            Socket client = null;

            while (true)
            {
                try
                {
                    client = socket.Accept();
                    Console.WriteLine("Got connection " + client);
                    // TODO: Create and start threads with function "handle" for receiving clients at the same time
                    Thread receiveThread = new Thread(() =>handle(client)); // To receive new messages create a new thread.
                    receiveThread.Start();

                }
                catch (IOException e)
                {
                    Console.WriteLine("Error reading request from client: " + e);
                    /* Definitely cannot continue, so skip to next
                        * iteration of while loop. */
                    continue;
                }
            }

        }
    }
}
