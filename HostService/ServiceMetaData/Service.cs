using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;

namespace HostService
{
    public class Service : IService
    {
        private List<MyProcess> Processes = new List<MyProcess>();
        private int nextId = 0;

        public int CreateProcess()
        {
            MyProcess process = new MyProcess(nextId++, OperationContext.Current);
            Processes.Add(process);
            process.IncrementLocalTime();

            return process.Id;
        }

        public void DeleteProcess(int id)
        {
            var process = Processes.FirstOrDefault(x => x.Id == id);
            if (process != null)
                Processes.Remove(process);
        }

        public void TryEnterToCS(int id)
        {
            var process = Processes.FirstOrDefault(x => x.Id == id);
            if (process == null)
                return;

            process.IsTryEnterInCS = true;
            process.OperationContext.GetCallbackChannel<IServiceCallback>().MsgCallback($"Процесс {id} пытается войти в КС");

            // sending reuest
            foreach (var item in Processes)
            {
                if (item.Id == process.Id)
                    return;

                item.GetRequest(process.LocalTime, process.Id);
            }
        }

        public void Reply(int id)
        {
            var process = Processes.FirstOrDefault(x => x.Id == id);
            if (process == null)
                return;
            process.ReplyCounter += 1;
            if (process.ReplyCounter == Processes.Count - 1)
                EnterToCS(process);
        }

        private void EnterToCS(MyProcess process)
        {
            process.IsRunInCS = true;
            process.IsTryEnterInCS = false;
            process.OperationContext.GetCallbackChannel<IServiceCallback>().MsgCallback($"Процесс {process.Id} вошел в КС");

            Thread.Sleep(300);

            process.IsRunInCS = false;
            process.OperationContext.GetCallbackChannel<IServiceCallback>().MsgCallback($"Процесс {process.Id} вышел из КС");
            process.ReplyAllWating();
        }
    }
}
