using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ClientGame.ServiceHost;
using System.Threading;

namespace ClientGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MyCLient();
            client.Start();

            Console.ReadKey();
        }
    }

    public class MyCLient : IServiceCallback
    {
        private ServiceClient Client;
        public MyCLient()
        {
            Client = new ServiceClient(new InstanceContext(this));
        }

        public void Start()
        {
            StartProcess();
        }

        private void StartProcess()
        {
            int id = Client.CreateProcess("Game");
            Thread.Sleep(350);
            Client.UploadGame(id);
            Console.WriteLine("Пытаемся загрузить игру");
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
