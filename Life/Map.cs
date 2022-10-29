using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    internal static class Map
    {
        static int[,] map = new int[15, 15];
        public static int[,] MyMap
        {
            get
            {
                return map;
            }
            set
            {
                map = value;
            }
        }
    }
}
