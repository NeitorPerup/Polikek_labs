using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSecurity.BusinessLogic.Services.GOSTCryptoService
{
    public class Converter
    {
        public byte[] ConvertToByte(ulong[] fl)
        {
            int ulongLength = 8;
            byte[] temp = new byte[ulongLength];
            byte[] encrByteFile = new byte[fl.Length * 8];

            for (int i = 0; i < fl.Length; i++)
            {
                temp = BitConverter.GetBytes(fl[i]);

                for (int j = 0; j < ulongLength; j++)
                    encrByteFile[j + i * ulongLength] = temp[j];
            }

            return encrByteFile;
        }

        public byte[] ConvertToByte(uint[] fl)
        {
            int uintLength = 4;
            byte[] temp = new byte[uintLength];
            byte[] encrByteFile = new byte[fl.Length * uintLength];

            for (int i = 0; i < fl.Length; i++)
            {
                temp = BitConverter.GetBytes(fl[i]);

                for (int j = 0; j < uintLength; j++)
                    encrByteFile[j + i * uintLength] = temp[j];
            }

            return encrByteFile;
        }

        public uint[] GetUIntKeyArray(byte[] byteKey)
        {
            int uintLength = 4;
            uint[] key = new uint[byteKey.Length / uintLength];

            for (int i = 0; i < key.Length; i++)
            {
                key[i] = BitConverter.ToUInt32(byteKey, i * uintLength);
            }

            return key;
        }

        public ulong[] GetULongDataArray(byte[] byteData)
        {
            int ulongLength = 8;
            ulong[] data = new ulong[byteData.Length / ulongLength];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = BitConverter.ToUInt64(byteData, i * ulongLength);
            }

            return data;
        }
    }
}
