using System;
using System.Collections;

namespace InformationSecurity.BusinessLogic.Services.GOSTCryptoService
{
    public class BasicStep
    {
        uint N1, N2, X;

        public BasicStep(ulong dateFragment, uint keyFragment)
        {
            N1 = (uint)(dateFragment >> 32);
            N2 = (uint)((dateFragment << 32) >> 32);
            X = keyFragment;

            var N1bit = ConvertToBit(N1);
            var N2bit = ConvertToBit(N2);
            var keyFragmentbit = ConvertToBit(keyFragment);
            var dateFragmentbit = ConvertToBit(dateFragment);
        }

        public ulong BasicEncrypt(bool IsLastStep)
        {
            return (FourthAndFifthStep(IsLastStep, ThirdStep(SecondStep(FirstStep()))));
        }

        private uint FirstStep()
        {
            return (uint)((X + N1) % (Convert.ToUInt64(Math.Pow(2, 32))));
        }

        private uint SecondStep(uint S)
        {
            uint newS, S0, S1, S2, S3, S4, S5, S6, S7;

            S0 = S >> 28;
            S1 = (S << 4) >> 28;
            S2 = (S << 8) >> 28;
            S3 = (S << 12) >> 28;
            S4 = (S << 16) >> 28;
            S5 = (S << 20) >> 28;
            S6 = (S << 24) >> 28;
            S7 = (S << 28) >> 28;

            var S0bit = ConvertToBit(S0);
            var S1bit = ConvertToBit(S1);
            var S2bit = ConvertToBit(S2);
            var S3bit = ConvertToBit(S3);
            var S4bit = ConvertToBit(S4);
            var S5bit = ConvertToBit(S5);
            var S6bit = ConvertToBit(S6);
            var S7bit = ConvertToBit(S7);

            S0 = ReplacementTab.Table[S0];
            S1 = ReplacementTab.Table[0x10 + S1];
            S2 = ReplacementTab.Table[0x20 + S2];
            S3 = ReplacementTab.Table[0x30 + S3];
            S4 = ReplacementTab.Table[0x40 + S4];
            S5 = ReplacementTab.Table[0x50 + S5];
            S6 = ReplacementTab.Table[0x60 + S6];
            S7 = ReplacementTab.Table[0x70 + S7];

            S0bit = ConvertToBit(S0);
            S1bit = ConvertToBit(S1);
            S2bit = ConvertToBit(S2);
            S3bit = ConvertToBit(S3);
            S4bit = ConvertToBit(S4);
            S5bit = ConvertToBit(S5);
            S6bit = ConvertToBit(S6);
            S7bit = ConvertToBit(S7);

            newS = S7 + (S6 << 4) + (S5 << 8) + (S4 << 12) + (S3 << 16) +
                    (S2 << 20) + (S1 << 24) + (S0 << 28);

            var newSbit = ConvertToBit(newS);

            return newS;
        }

        private uint ThirdStep(uint S)
        {
            return (uint)(S << 11) | (S >> 21);
        }

        private ulong FourthAndFifthStep(bool IsLastStep, uint S)
        {
            var Sbit = ConvertToBit(S);
            ulong N;

            S = (S ^ N2);
            Sbit = ConvertToBit(S);

            if (!IsLastStep)
            {
                N2 = N1;
                N1 = S;
            }
            else
                N2 = S;

            var N2bit = ConvertToBit(N2);
            var N1bit = ConvertToBit(N1);

            N = ((ulong)N2) | (((ulong)N1) << 32);
            var Nbit = ConvertToBit(N);

            return N;
        }

        private string ConvertToBit(uint value)
        {
            return Convert.ToString(value, 2);
        }
        private string ConvertToBit(ulong value)
        {
            var byteArray = BitConverter.GetBytes(value);
            string[] result = new string[byteArray.Length];
            for (int i = 0; i < byteArray.Length; ++i)
            {
                result[i] = Convert.ToString(byteArray[i], 2).PadLeft(8, '0');
            }

            return string.Join("", result);
        }
    }

    struct ReplacementTab
    {
        internal static byte[] Table
        {
            get { return table; }
        }

        private static readonly byte[] table = {
                        0x4,0x2,0xF,0x5,0x9,0x1,0x0,0x8,0xE,0x3,0xB,0xC,0xD,0x7,0xA,0x6,
                        0xC,0x9,0xF,0xE,0x8,0x1,0x3,0xA,0x2,0x7,0x4,0xD,0x6,0x0,0xB,0x5,
                        0xD,0x8,0xE,0xC,0x7,0x3,0x9,0xA,0x1,0x5,0x2,0x4,0x6,0xF,0x0,0xB,
                        0xE,0x9,0xB,0x2,0x5,0xF,0x7,0x1,0x0,0xD,0xC,0x6,0xA,0x4,0x3,0x8,
                        0x3,0xE,0x5,0x9,0x6,0x8,0x0,0xD,0xA,0xB,0x7,0xC,0x2,0x1,0xF,0x4,
                        0x8,0xF,0x6,0xB,0x1,0x9,0xC,0x5,0xD,0x3,0x7,0xA,0x0,0xE,0x2,0x4,
                        0x9,0xB,0xC,0x0,0x3,0x6,0x7,0x5,0x4,0x8,0xE,0xF,0x1,0xA,0x2,0xD,
                        0xC,0x6,0x5,0x2,0xB,0x0,0x9,0xD,0x3,0xE,0x7,0xA,0xF,0x4,0x1,0x8
                };
    }
}
