using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace MyService
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IService
    {
        [OperationContract]
        int CreateProcess(string name);

        [OperationContract(IsOneWay = true)]
        void Reply(int id, int idFrom);

        [OperationContract(IsOneWay = true)]
        void TryEnterToCS(int id);

        [OperationContract(IsOneWay = true)]
        void UploadFile(int id);

        [OperationContract(IsOneWay = true)]
        void UploadMusic(int id);

        [OperationContract(IsOneWay = true)]
        void UploadGame(int id);

        void DeleteProcess(int id);
    }

    public interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void MsgCallback(string msg);

        [OperationContract(IsOneWay = true)]
        void SendReplyCallback(int processToId, int id);
    }
}
