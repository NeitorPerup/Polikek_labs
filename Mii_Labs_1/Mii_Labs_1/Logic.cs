using System;
using System.Collections.Generic;
using System.Text;
using Mii_Labs_1.Models;

namespace Mii_Labs_1
{
    public class Logic
    {
        /// <summary>
        /// возвращает значение от 0 до 1
        /// </summary>
        /// <returns></returns>
        public static double Affilation(TrapezePoints points, int x)
        {
            if (x >= points.A && x <= points.B)
                return (1.0 * (x - points.A)) / (points.B - points.A);
            if (x > points.B && x < points.C)
                return 1;
            if (x >= points.C && x <= points.D)
                return (1.0 * (points.D - x)) / (points.D - points.C);
            return 0;
        }
    }
}
