using System.Net.Sockets;
using System.Net;
using System.Text;

namespace MultipleChoiceTestsGenerator
{
    /// <summary>
    /// 
    /// </summary>
    class Server
    {
        private TestQuestionsBank questionsBank;    //
        private string username;                    //
        private int seconds;                        //
        private int questionsCount;                 //
        private TcpListener tcpListener;            //
        private TcpClient tcpClient;                //
        private NetworkStream stream;               //
        private StreamReader reader;                //
        private StreamWriter writer;                //

        /// <summary>
        /// 
        /// </summary>
        public Server()
        {
            username = "";
            seconds = 0;
            questionsCount = 0;
            questionsBank = new TestQuestionsBank(questionsCount);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ListenForClients()
        {
            this.tcpListener = new TcpListener(IPAddress.Any, 1234);
            this.tcpListener.Start();
            tcpClient = tcpListener.AcceptTcpClient();
            Console.WriteLine($"{DateTime.Now}: Client connected to the server.");
            ReceiveData(tcpClient);
            this.tcpListener.Stop();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientObj"></param>
        /// <param name="clientData"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientData"></param>
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
        /// 
        /// </summary>
        /// <param name="clientObj"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="questions"></param>
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
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            Console.WriteLine($"{DateTime.Now}: Server started.");
            Console.WriteLine("Server listening for clients...");
            server.ListenForClients();
        }
    }
}