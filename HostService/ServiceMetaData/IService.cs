using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace HostService
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IService
    {
        [OperationContract]
        public int CreateProcess();

        [OperationContract(IsOneWay = true)]
        public void Reply(int id);

        [OperationContract(IsOneWay = true)]
        public void TryEnterToCS(int id);

        public void DeleteProcess(int id);
    }

    public interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        public void MsgCallback(string msg);

        [OperationContract(IsOneWay = true)]
        public void SendRequestCallback(int id, int time, int processToId);

        [OperationContract(IsOneWay = true)]
        public void GetRequestCallback(int id, int time, int processToId);

        [OperationContract(IsOneWay = true)]
        public void SendReplyCallback(int processToId);
    }
}
