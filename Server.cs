using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

class Server {
    private static TcpListener server = null;
    public static void Start() {
        try {
            //set tcp listener to port 26950
            Int32 port = 26950;

            server = new TcpListener(IPAddress.Any, port);

            //Start listening for client requests
            server.Start();
            server.BeginAcceptTcpClient(TCPConnectCallBack, null);

            //buffer for reading data
            // byte[] buffer = new byte[256];
            // string data = "";
        } catch (SocketException e) {
            Console.WriteLine($"Socket Exception: {e}");
        } catch (Exception e) {
            Console.Write($"Exception: {e}");
        }
    }

    private static void TCPConnectCallBack(IAsyncResult _result) {
        try {
            TcpClient _client = server.EndAcceptTcpClient(_result);
            server.BeginAcceptTcpClient(TCPConnectCallBack, null);
            Console.WriteLine($"Incoming connection from {_client.Client.RemoteEndPoint}");

            Byte[] bytes = new Byte[256];
            string data = null;

            NetworkStream stream = _client.GetStream();

            int i;
            
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0) {
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine($"Message received from Client: {data}");

                byte[] msg = System.Text.Encoding.ASCII.GetBytes("Cliente conectado");
                stream.Write(msg, 0, msg.Length);
            }

            _client.Close();
        } catch (System.Exception e) {
            Console.WriteLine($"Exception: {e}");
        }
    }

    public static void Stop() {
        server.Stop();
    }
}