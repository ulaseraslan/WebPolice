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

namespace projetest
{
    public class HttpRequest
    {
        String CRLF = "\r\n";
        int HTTP_PORT = 80;

        /** Store the request parameters */
        String method;
        String URI;
        String version;
        String headers = "";

        /** Server and port */
        private String host;
        private int port;

        Socket clientSocket;

        /** Create HttpRequest by reading it from the client socket */
        public HttpRequest(Byte[] from)
        {
            // TODO: Convert byte array "from" to string to process it.

            string incomingMessage = Encoding.Default.GetString(from);
            incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));


            // TODO: Extract first line of the converted string.
            String firstLine = "";
            try
            {

                firstLine = incomingMessage.Substring(0, incomingMessage.IndexOf("\n"));
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading request line: " + e);
            }



            //TO DO: Split byte array and assign appropriate values to method, URI and version 

            int method_index = 0;
            method_index = firstLine.IndexOf(" /");
            int version_index = 0;
            version_index = firstLine.IndexOf("HTTP");


            method = firstLine.Substring(0, method_index);
            URI = firstLine.Substring(method_index+1, version_index -  method_index - 2);
            version = firstLine.Substring(version_index);

            port = HTTP_PORT;


            Console.WriteLine("URI is: " + URI);
            if (method != "GET")
            {
                Console.WriteLine("Error: Method not GET");
            }

            try
            {
                String[] lines = incomingMessage.Split('\n'); //error will be gone when you do TODOs above
                foreach (string line in lines)
                {
                    headers += line + CRLF;
                    /* We need to find host header to know which server to
                    * contact in case the request URI is not complete. */
                     
                
                      
                       // TO DO determine the Host and Port number 
                      if (line.Contains("Host:"))
                    {
                        host = line.Substring(line.IndexOf(":")+2);
                    }

                      if (line.Contains("Port:"))
                    {
                        string port_str = line.Substring(line.IndexOf(":")+2);
                        port = Int32.Parse(port_str);
                    }

                    
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading from socket: " + e);
                return;
            }
        }

        /** Return host for which this request is intended */
        public String getHost()
        {
            return host;
        }

        public String getURL()
        {

            string url = host + URI;
            return url;
        }

        /** Return port for server */
        public int getPort()
        {
            return port;
        }
        /**
         * Convert request into a string for easy re-sending.
         */
        public String toString()
        {
            String req = "";

            //req = method + " " + URI + " " + version + CRLF;
            req += headers;
            /* This proxy does not support persistent connections */
            req += "Connection: close" + CRLF;
            req += CRLF;

            return req;
        }
    }
}
