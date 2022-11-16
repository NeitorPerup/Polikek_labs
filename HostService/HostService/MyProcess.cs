using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace HostService
{
    public class MyProcess : LogicTimer
    {
        public int Id;
        public int ReplyCounter;
        public bool IsRunInCS;
        public bool IsTryEnterInCS;
        public OperationContext OperationContext;

        private List<int> DR;

        public MyProcess(int id, OperationContext operationContext) : base()
        {
            Id = id;
            ReplyCounter = 0;
            OperationContext = operationContext;
            DR = new List<int>();
        }

        public override void GetRequest(int time, int id)
        {
            if (IsRunInCS)
                // добавляем id в очередь, чтобы после выхода из КС отправить Reply
                DR.Add(id);
            else if (IsTryEnterInCS)
            {
                ChangeMaxTime(time);
                if (LocalTime > time)
                    Reply(id);
            }
            else
                Reply(id);
        }

        public void ReplyAllWating()
        {
            foreach (var id in DR)
                Reply(id);
        }

        public override void Reply(int id)
        {
            OperationContext.GetCallbackChannel<IServiceCallback>().SendReplyCallback(id);
        }

        //public override void SendRequest(int time, int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
