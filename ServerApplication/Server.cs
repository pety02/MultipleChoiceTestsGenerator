﻿using System.Net.Sockets;
using System.Net;
using System.Text;
using System;

namespace MultipleChoiceTestsGenerator
{
    /// <summary>
    /// This class describes a multithread server with TcpListener and TcpClient.
    /// </summary>
    public class Server
    {
        private TestQuestionsBank questionsBank;    // bank of random test questions
        private string username;                    // username of the student
        private int seconds;                        // seconds for solving the test
        private int questionsCount;                 // count of the questions
        private TcpListener tcpListener;            // tcp listener
        private TcpClient tcpClient;                // tcp client
        private NetworkStream stream;               // stream of messages
        private StreamWriter writer;                // server stream writer

        /// <summary>
        /// Parsing client data like username, time 
        /// in seconds and preffered questions count.
        /// </summary>
        /// <param name="clientData"> client message's data as string </param>
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

        /// <summary>
        /// Server default constructor.
        /// </summary>
        public Server()
        {
            username = "";
            seconds = 0;
            questionsCount = 0;
            questionsBank = new TestQuestionsBank(questionsCount);
        }

        /// <summary>
        /// Get methods for getting the tcp listener.
        /// </summary>
        /// <returns> current tcp listener </returns>
        public TcpListener GetTcpListener()
        {
            return tcpListener;
        }

        /// <summary>
        /// Asyncronuously listening for server's clients.
        /// </summary>
        public async Task ListenForClients()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 1234);
                tcpListener.Start();
                while (true)
                {
                    tcpClient = await tcpListener.AcceptTcpClientAsync();
                    Console.WriteLine($"{DateTime.Now}: Client connected to the server.");
                    await ReceiveData(tcpClient);
                }
            } 
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"{DateTime.Now}:{ex.Message}");
            }
        }

        /// <summary>
        /// Asynchronuous seading data from the client.
        /// </summary>
        /// <param name="clientObj"> client object </param>
        /// <param name="clientData"> client message's data </param>
        /// <returns></returns>
        public async Task<string> ReadDataAsync(TcpClient clientObj,
                                      string clientData)
        {
            try
            {
                byte[] buffer = new byte[8192];
                stream = clientObj.GetStream();
                int bytes;
                do
                {
                    bytes = await stream.ReadAsync(buffer, 0, buffer.Length);
                    clientData = Encoding.UTF8.GetString(buffer, 0, bytes);
                    byte[] responseData = Encoding.UTF8.GetBytes(clientData);
                    await stream.WriteAsync(responseData, 0, responseData.Length);
                } while (bytes == 0);
            }
            catch (Exception)
            {
                await Console.Out.WriteLineAsync($"log - {DateTime.Now}: Error in reading");
            }

            return clientData;
        }

        /// <summary>
        /// Asyncronuously receiving data from TcpClient.
        /// </summary>
        /// <param name="clientObj"> tcpClient object </param>
        public async Task ReceiveData(TcpClient clientObj)
        {
            try { 
                string clientData = "";
                clientData = await ReadDataAsync(clientObj, clientData);
                ParseClientData(clientData);

                questionsBank = new TestQuestionsBank(questionsCount);
                await SendData(clientObj, questionsBank);
            } 
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"log - {DateTime.Now}: {ex.Message}");
            }
        }

        /// <summary>
        /// Asyncronuously sending data to the client.
        /// </summary>
        /// <param name="client"> Client - receiver of the test questions bank </param>
        /// <param name="questions"> test questions bank </param>
        public async Task SendData(TcpClient client, TestQuestionsBank questions)
        {
            try
            {
                stream = client.GetStream();
                writer = new StreamWriter(stream);
                string serverMessage = "\n";
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
                await writer.WriteAsync(serverMessage);
                await writer.FlushAsync();
                writer.Close();
            } 
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"log - {DateTime.Now}: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Program class that runs the server.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Start point of the server application.
        /// </summary>
        /// <param name="args"> arguments of the Main method </param>
        /// <returns> nothing - it just triggers the server </returns>
        static async Task Main(string[] args)
        {
            Server server = new Server();
            Console.WriteLine($"{DateTime.Now}: Server started.");
            Console.WriteLine("Server listening for clients...");
            await server.ListenForClients();
        }
    }
}