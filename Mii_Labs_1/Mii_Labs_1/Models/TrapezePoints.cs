using System;
using System.Collections.Generic;
using System.Text;

namespace Mii_Labs_1.Models
{
    public class TrapezePoints
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }

        public bool CheckPoints()
        {
            if (A >= B || B >= C || C >= D)
                return false;
            return true;
        }

        public List<int> ToList()
        {
            return new List<int>() { A, B, C, D };
        }
    }
}
