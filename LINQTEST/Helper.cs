using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTEST
{
    internal class Helper
    {
        public static List<int> RandomList(int count, int min = 0, int max = Int32.MaxValue)
        {
            var list = new List<int>();
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                list.Add(random.Next(min, max));
            }
            return list;
        }
    }
}
