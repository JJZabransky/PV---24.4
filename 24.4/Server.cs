using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _24._4
{
    public class Server
    {
        private TcpListener myServer;
        private bool isRunning;
        bool connected = false;

        public Server(int port)
        {
            myServer = new TcpListener(System.Net.IPAddress.Any, port);
            myServer.Start();
            isRunning = true;
            ServerLoop();
        }

        private void ServerLoop()
        {
            Console.WriteLine("Server byl spusten");
            while (isRunning)
            {
                TcpClient client = myServer.AcceptTcpClient();
                ClientLoop(client);
            }
        }

        private void ClientLoop(TcpClient client)
        {
            StreamReader reader = new StreamReader(client.GetStream(), Encoding.UTF8);
            StreamWriter writer = new StreamWriter(client.GetStream(), Encoding.UTF8);

            writer.WriteLine("Byl jsi pripojen");
            writer.Flush();
            writer.AutoFlush = true;
            bool clientConnect = true;
            string? data = null;
            string? dataRecive = null;
            
            while (clientConnect)
            {
                if(connected)
                {
                    data = reader.ReadLine();
                    data = data.ToLower();
                    switch (data)
                    {
                        case "exit":
                            clientConnect = false;
                            break;
                        case "who":
                            writer.WriteLine(" je pripojen");
                            break;
                        case "uptime":
                            clientConnect = false;
                            break;
                        case "stats":
                            clientConnect = false;
                            break;
                        case "last":
                            clientConnect = false;
                            break;
                        case "kvadrat":
                            clientConnect = false;
                            break;
                        case "ohm":
                            clientConnect = false;
                            break;
                    }
                    dataRecive = data + " prijato";
                    writer.WriteLine(dataRecive);
                    writer.Flush();
                }
                else
                {
                    writer.WriteLine("Zadejte uzivatelske jmeno:");
                    string uname = reader.ReadLine();
                    writer.WriteLine("Zadejte heslo:");
                    string upaswrd = reader.ReadLine();

                    Uzivatel u = new Uzivatel(uname, upaswrd);
                    
                    if(uname == )
                    {
                        connected = true;
                    }
                }
            }
            writer.WriteLine("Byl jsi odpojen");
            writer.Flush();
        }
    }
}
