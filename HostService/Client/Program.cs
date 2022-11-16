using System;
using System.Threading.Tasks;
using Client.ServiceHost;
using System.ServiceModel;
using System.Diagnostics;
using System.Threading;

namespace Client
{
    class Program 
    {
        static void Main(string[] args)
        {
            var client = new MyCLient(5);
            client.Start();

            Console.ReadKey();
        }
    }

    public class MyCLient : IServiceCallback
    {
        private int ProcessCount;
        private ServiceClient Client;
        private Random rand;
        public MyCLient(int processCount)
        {
            ProcessCount = processCount;
            Client = new ServiceClient(new InstanceContext(this));
            rand = new Random();
        }

        public void Start()
        {
            StartProcess();
        }

        private void StartProcess()
        {
            int id = Client.CreateProcess("File");
            Client.UploadFile(id);
            Console.WriteLine("Пытаемся загрузить файл");
        }

        public void MsgCallback(string msg)
        {
            Console.WriteLine(msg);
        }

        public void SendReplyCallback(int processToId, int id)
        {
            Client.Reply(processToId, id);
        }
    }
}
