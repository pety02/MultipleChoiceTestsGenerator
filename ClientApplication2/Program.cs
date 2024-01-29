using System.Net.Sockets;
using System.Text;

internal class Program
{
    static void Main()
    {
        TcpClient client = new TcpClient("127.0.0.1", 12345);
        using (NetworkStream stream = client.GetStream())
        {
            // Send data to the server
            string sendData = "Hello from client!";
            byte[] sendBytes = Encoding.UTF8.GetBytes(sendData);
            stream.Write(sendBytes, 0, sendBytes.Length);

            // Read response from the server
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string responseData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Received response: {responseData}");
        }

        client.Close();
    }
}