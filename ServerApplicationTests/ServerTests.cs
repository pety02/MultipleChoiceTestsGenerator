using MultipleChoiceTestsGenerator;
using System.Net.Sockets;

namespace ServerApplicationTests
{
    /// <summary>
    /// This class describes the Server NUnit tests.
    /// </summary>
    [TestFixture]
    public class ServerTests
    {
        private Server server;

        /// <summary>
        /// Initialize class private fields to prepare them for testing.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.server = new Server();
            Assert.IsNotNull(this.server);
        }

        /// <summary>
        /// Clears the memory where it is needed.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
        }

        /// <summary>
        /// Tests the server asynchronuous listening for clients.
        /// </summary>
        /// <returns> nothing </returns>
        [Test]
        public async Task ListenForClientsAsyncTest()
        {
            await this.server.ListenForClients();
            TcpListener tcpListener = this.server.GetTcpListener();
            Assert.IsNotNull(tcpListener);
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            Assert.IsTrue(tcpClient.Connected);
        }

        /// <summary>
        /// Tests the server asynchronuous reading data from the client.
        /// </summary>
        /// <returns> nothing </returns>
        [Test]
        public async Task ReadDataAsyncTest()
        {
            await this.server.ListenForClients();
            TcpClient clientObj = this.server.GetTcpListener().AcceptTcpClient();
            Assert.That(actual: clientObj, Is.Not.EqualTo(null));
            string clientData = "";
            await this.server.ReadDataAsync(clientObj, clientData);
            Assert.That(actual: clientData, Is.Not.EqualTo(null));
            Assert.That(actual: clientData, Is.Not.EqualTo(""));
        }

        /// <summary>
        /// Tests the server asynchronupus sending data to the client.
        /// </summary>
        /// <returns> nothing </returns>
        [Test]
        public async Task SendDataAsync()
        {
            await this.server.ListenForClients();
            TcpClient clientObj = this.server.GetTcpListener().AcceptTcpClient();
            int questionsCount = 3;
            TestQuestionsBank questionsBank = new TestQuestionsBank(questionsCount);
            await this.server.SendData(clientObj, questionsBank);
            Assert.That(actual: questionsBank, Is.Not.EqualTo(null));
            Assert.That(actual: questionsBank.Questions.Length, Is.EqualTo(questionsCount));
        }
    }
}