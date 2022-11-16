using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace MyService
{
    public class MyProcess : LogicTimer
    {
        public int Id;
        public string Name;
        public int ReplyCounter;
        public bool IsRunInCS;
        public bool IsTryEnterInCS;
        public OperationContext OperationContext;

        private List<int> DR;

        public MyProcess(int id, string name, OperationContext operationContext) : base()
        {
            Id = id;
            Name = name;
            ReplyCounter = 0;
            OperationContext = operationContext;
            DR = new List<int>();
        }

        public override void GetRequest(int time, int idFrom)
        {
            if (IsRunInCS)
                // добавляем id в очередь, чтобы после выхода из КС отправить Reply
                DR.Add(idFrom);
            else if (IsTryEnterInCS)
            {
                ChangeMaxTime(time);
                if (LocalTime > time)
                    Reply(idFrom, Id);
            }
            else
                Reply(idFrom, Id);
        }

        public void ReplyAllWating()
        {
            foreach (var id in DR)
                Reply(id, Id);
            ReplyCounter = 0;
            DR.Clear();
        }

        public override void Reply(int id, int idFrom)
        {
            OperationContext.GetCallbackChannel<IServiceCallback>().SendReplyCallback(id, idFrom);
        }
    }
}
