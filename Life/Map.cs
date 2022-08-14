using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    internal class Map
    {
        static int[,] map = new int[10, 10];
        public int[,] MyMap
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
