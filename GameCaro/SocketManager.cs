using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameCaro
{
    public class SocketManager
    {
        #region Clinet
        Socket client;
        public bool ConnectServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), PORT);
            client = new Socket(AddressFamily.InterNetwork, socketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(iep);
                return true;
            }
            catch
            {
                return false;
            }
            client.Connect(iep);
            return true; }
        #endregion

        #region server
        Socket server;
        public void CreateServer()
        {

            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), PORT);
            server = new Socket(AddressFamily.InterNetwork, socketType.Stream, ProtocolType.Tcp);

            server.Bind(iep);
            server.Listen(10);
            Thread acceptClient = new Thread(() =>
                {
                    client = server.Accept();
                });
            acceptClient.IsBackground = true;
            acceptClient.Start();
        }
        #endregion

        #region Both
        public string IP = "127.0.0.1";
        public int PORT = 9999;
        public const int BUFFER = 1024;
        public bool isServer = true;
        public bool Send(object data)
        {
            byte[] sendData = SerializeData(data);
           
            {
                return SendData(client, sendData);
            }
      
        }

        private byte[] SerializeData(object data)
        {
            throw new NotImplementedException();
        }

        public object Receive()
        {
            byte [] receiveData = new byte[BUFFER];
            bool isOk = ReceiveData(client, receiveData);
            return DeserializeData(receiveData);
        }

        private object DeserializeData(byte[] receiveData)
        {
            throw new NotImplementedException();
        }

        private bool SendData(Socket target, byte[] data)
        {
            return target.Send(data) == 1 ? true : false;

        }
        private bool ReceiveData(Socket target, ref byte[] data)
        {
            return target.Receive(data) == 1 ? true : false;
        }
        private object socketType;
    }
}