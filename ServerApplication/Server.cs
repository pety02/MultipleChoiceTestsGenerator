using System.Net.Sockets;
using System.Net;
using System.Text;

namespace MultipleChoiceTestsGenerator
{
    /// <summary>
    /// This class describes a multithread server with TcpListener and TcpClient.
    /// </summary>
    class Server
    {
        private TestQuestionsBank questionsBank;    // bank of random test questions
        private string username;                    // username of the student
        private int seconds;                        // seconds for solving the test
        private int questionsCount;                 // count of the questions
        private TcpListener tcpListener;            // tcp listener
        private TcpClient tcpClient;                // tcp client
        private NetworkStream stream;               // stream of messages
        private StreamReader reader;                // server stream reader
        private StreamWriter writer;                // server stream writer

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
        public async Task ListenForClients(TcpListener tcpListener)
        {
            this.tcpListener = new TcpListener(IPAddress.Any, 1234);
            this.tcpListener.Start();
            tcpClient = tcpListener.AcceptTcpClient();
            Console.WriteLine($"{DateTime.Now}: Client connected to the server.");
            await ReceiveData(tcpClient);
            this.tcpListener.Stop();
        }

        /// <summary>
        /// Reading data from the client.
        /// </summary>
        /// <param name="clientObj"> client object </param>
        /// <param name="clientData"> client message's data </param>
        /// <returns></returns>
        private string ReadData(TcpClient clientObj,
                                      string clientData)
        {
            try
            {
                stream = clientObj.GetStream();
                int bytes = clientObj.Available;
                byte[] bytesArr = new byte[bytes];
                stream.Read(bytesArr, 0, bytes);
                clientData = Encoding.UTF8.GetString(bytesArr);
            }
            catch (Exception)
            {
                Console.WriteLine($"log - {DateTime.Now}: Error in reading");
            }

            return clientData;
        }

        /// <summary>
        /// Asyncronuously parsing client data like username, time 
        /// in seconds and preffered questions count.
        /// </summary>
        /// <param name="clientData"> client message's data as string </param>
        private async Task ParseClientData(string clientData)
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
        /// Asyncronuously receiving data from TcpClient.
        /// </summary>
        /// <param name="clientObj"> tcpClient object </param>
        private async Task ReceiveData(TcpClient clientObj)
        {
            try { 
                string clientData = "";
                clientData = ReadData(clientObj, clientData);
                await ParseClientData(clientData);

                questionsBank = new TestQuestionsBank(questionsCount);
                await SendData(clientObj, questionsBank);
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"log - {DateTime.Now}: {ex.Message}");
            }
        }

        /// <summary>
        /// Asyncronuously sending data to the client.
        /// </summary>
        /// <param name="client"> Client - receiver of the test questions bank </param>
        /// <param name="questions"> test questions bank </param>
        private async Task SendData(TcpClient client, TestQuestionsBank questions)
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
                writer.Write(serverMessage);
                writer.Flush();
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"log - {DateTime.Now}: {ex.Message}");
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
            await server.ListenForClients(server.GetTcpListener());
        }
    }
}