using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;

namespace MyService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        private List<MyProcess> Processes = new List<MyProcess>();
        private int nextId = 0;

        private MyProcess GetProcess(int id)
        {
            return Processes.FirstOrDefault(x => x.Id == id);
        }

        private void PrintMessage(OperationContext context, string message)
        {
            context.GetCallbackChannel<IServiceCallback>().MsgCallback(message);
            Console.WriteLine(message);
        }

        public int CreateProcess(string name)
        {
            MyProcess process = new MyProcess(nextId++, name, OperationContext.Current);
            if (Processes.FirstOrDefault(x => x.Name == name) != null)
            {
                PrintMessage(process.OperationContext, $"Процесс с именем {process.Name} уже существует");
                return -1;
            }
            Processes.Add(process);
            process.IncrementLocalTime();
            PrintMessage(process.OperationContext, $"Процесс {process.Name} создан");

            return process.Id;
        }

        public void DeleteProcess(int id)
        {
            var process = GetProcess(id);
            if (process != null)
                Processes.Remove(process);
        }

        public void TryEnterToCS(int id)
        {
            var process = GetProcess(id);
            if (process == null)
                return;

            process.IsTryEnterInCS = true;
            PrintMessage(process.OperationContext, $"Процесс {process.Name} пытается войти в КС");

            if (Processes.Count == 1)
                EnterToCS(process);

            // sending reuest
            foreach (var item in Processes)
            {
                if (item.Id == process.Id)
                    continue;

                item.GetRequest(process.LocalTime, process.Id);
            }
        }

        public void Reply(int id, int idFrom)
        {
            var process = GetProcess(id);
            var processFrom = GetProcess(idFrom);
            if (process == null || processFrom == null)
                return;

            process.ReplyCounter += 1;
            PrintMessage(process.OperationContext,
                $"Процесс {process.Name} получил Reply от {processFrom.Name}. {process.ReplyCounter}/{Processes.Count - 1}");
            if (process.ReplyCounter == Processes.Count - 1)
                EnterToCS(process);
        }

        private void EnterToCS(MyProcess process)
        {
            process.IsRunInCS = true;
            process.IsTryEnterInCS = false;
            PrintMessage(process.OperationContext, $"Процесс {process.Name} вошел в КС");

            Thread.Sleep(300);

            process.IsRunInCS = false;
            PrintMessage(process.OperationContext, $"Процесс {process.Name} вышел из КС");
            process.ReplyAllWating();
        }

        public void UploadFile(int id)
        {
            TryEnterToCS(id);
        }

        public void UploadMusic(int id)
        {
            TryEnterToCS(id);
        }

        public void UploadGame(int id)
        {
            TryEnterToCS(id);
        }
    }
}
