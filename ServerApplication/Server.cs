using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Collections;

namespace MultipleChoiceTestsGenerator
{
    class Server
    {
        private TcpListener tcpListener;
        private TestQuestionsBank questionsBank;
        private string username = "";
        private int seconds = 0;
        private int questionsCount = 0;
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public Server()
        {
            this.tcpListener = new TcpListener(IPAddress.Any, 1234);  
        }

        public void ListenForClients()
        {
            this.tcpListener.Start();
            do
            {
                tcpClient = tcpListener.AcceptTcpClient();
                stream = tcpClient.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);

                ReceiveData(tcpClient);
            } while (true);
        }

        private string ReadData(object clientObj, string clientData)
        {
            TcpClient tcpClient = (TcpClient)clientObj;
            int bytes = tcpClient.Available;

            try
            {
                NetworkStream networkStream = tcpClient.GetStream();

                byte[] bytesArr = new byte[bytes];
                bytes = stream.Read(bytesArr, 0, bytes);
                clientData = Encoding.UTF8.GetString(bytesArr);
                Console.WriteLine(clientData);
                return clientData;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in reading");
                return "";
            }
        }

        private void ParseClientData(string clientData)
        {
            string receivedDataComponent = "";
            int componenetsCount = 0;
            for (int i = 0; clientData != null && i < clientData.Length; ++i)
            {

                if (clientData[i] == ',' && componenetsCount == 0)
                {
                    username = receivedDataComponent;
                    receivedDataComponent = "";
                    componenetsCount++;
                }
                else if (clientData[i] == ',' && componenetsCount == 1)
                {
                    seconds = int.Parse(receivedDataComponent);
                    receivedDataComponent = "";
                    componenetsCount++;
                }
                else if ('0' <= clientData[i] && clientData[i] <= '9' && clientData.Length <= i + 1 && componenetsCount == 2)
                {
                    receivedDataComponent += clientData[i];
                }
                else
                {
                    receivedDataComponent += clientData[i];
                }
            }

            questionsCount = int.Parse(receivedDataComponent);
        }

        private void ReceiveData(object clientObj)
        {
            string clientData = "";
            clientData = ReadData(clientObj, clientData);
            ParseClientData(clientData);

            questionsBank = new TestQuestionsBank(questionsCount);
            SendData(tcpClient, questionsBank);
        }

        private void SendData(TcpClient client, TestQuestionsBank questions)
        {
            NetworkStream clientStream =  client.GetStream();
            string s = questions.Questions.ToString();
            byte[] buffer = Encoding.ASCII.GetBytes(questions.Questions.ToString());
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.ListenForClients();
        }
    }
}