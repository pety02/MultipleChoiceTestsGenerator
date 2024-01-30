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
        private TestQuestionsBank questionsBank;
        private string username;
        private int seconds;
        private int questionsCount;

        private TcpListener tcpListener;
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public Server()
        {
            username = "";
            seconds = 0;
            questionsCount = 0;
            questionsBank = new TestQuestionsBank(questionsCount);
        }

        public void ListenForClients()
        {
                this.tcpListener = new TcpListener(IPAddress.Any, 1234);
                this.tcpListener.Start();
                tcpClient = tcpListener.AcceptTcpClient();
                ReceiveData(tcpClient);
                this.tcpListener.Stop();
        }

        private string ReadData(TcpClient clientObj, string clientData)
        {
            try
            {
                stream = clientObj.GetStream();
                int bytes = clientObj.Available;
                byte[] bytesArr = new byte[bytes];
                stream.Read(bytesArr, 0, bytes);
                clientData = Encoding.UTF8.GetString(bytesArr);
                return clientData;
            }
            catch (Exception)
            {
                Console.WriteLine($"log - {DateTime.Now}: Error in reading");
                return "";
            }
        }

        private void ParseClientData(string clientData)
        {
            string receivedDataComponent = "";
            int componenetsCount = 0;
            bool isLastChar = false;
            for (int i = 0; i < clientData.Length; ++i)
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
                    isLastChar = true;
                    break;
                }
                else
                {
                    receivedDataComponent += clientData[i];
                }
            }

            if (isLastChar)
            {
                questionsCount = int.Parse(receivedDataComponent);
            }
        }

        private void ReceiveData(TcpClient clientObj)
        {
            try { 
                string clientData = "";
                clientData = ReadData(clientObj, clientData);
                ParseClientData(clientData);

                questionsBank = new TestQuestionsBank(questionsCount);
                SendData(clientObj, questionsBank);
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"log - {DateTime.Now}: {ex.Message}");
            }
        }

        private void SendData(TcpClient client, TestQuestionsBank questions)
        {
            try
            {
                stream = client.GetStream();
                writer = new StreamWriter(stream);
                string serverMessage = "";
                foreach (var question in questions.Questions)
                {
                    serverMessage += question.QuestionText;
                    serverMessage += "\nPossible Answers\n";
                    foreach (var possibleAnswer in question.PossibleAnswers)
                    {
                        serverMessage += possibleAnswer;
                        serverMessage += '\n';
                    }
                    serverMessage += "Correct Answers\n";
                    foreach (var correctAnswer in question.CorrectAnswers)
                    {
                        serverMessage += correctAnswer;
                        serverMessage += "\n";
                    }
                    serverMessage += "*\n";
                }
                Console.WriteLine(serverMessage);
                writer.Write(serverMessage);
                writer.Flush();
                //stream.Flush();
                
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"log - {DateTime.Now}: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            Console.WriteLine($"Server started on {DateTime.Now}:");
            Console.WriteLine("Server listening for clients...");
            server.ListenForClients();
        }
    }
}