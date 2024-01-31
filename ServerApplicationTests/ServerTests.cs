using MultipleChoiceTestsGenerator;
using System.Net.Sockets;

namespace ServerApplicationTests
{
    [TestFixture]
    public class ServerTests
    {
        private Server server;
        [SetUp]
        public void Setup()
        {
            this.server = new Server();
            Assert.IsNotNull(this.server);
        }
        [TearDown]
        public void TearDown()
        {
        }
        [Test]
        public async Task ListenForClientsAsyncTest()
        {
            await this.server.ListenForClients();
            TcpListener tcpListener = this.server.GetTcpListener();
            Assert.IsNotNull(tcpListener);
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            Assert.IsTrue(tcpClient.Connected);
        }
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