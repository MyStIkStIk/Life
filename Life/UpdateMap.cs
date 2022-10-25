using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    public static class UpdateMap
    {
        static List<(int, int, int)> list = new List<(int, int, int)>();
        static int[,] resultmap;
        public static void Update(ref int[,] map)
        {
            resultmap = map;
            UpdateLifeSlots();
            for (int i = 0; i < resultmap.GetLength(0); i++)
            {
                for (int j = 0; j < resultmap.GetLength(1); j++)
                {
                    if (resultmap[i,j] == 2)
                        resultmap[i,j] = 1;
                }
            }
            map = resultmap;
        }
        static void UpdateLifeSlots()
        {
            for (int i = 0; i < resultmap.GetLength(0); i++)
            {
                for (int j = 0; j < resultmap.GetLength(1); j++)
                {
                    if ((i > 0 & j > 0) & (i < resultmap.GetLength(0) - 1 & j < resultmap.GetLength(1) - 1))
                    {
                        list.Add((i - 1, j - 1, resultmap[i - 1, j - 1]));
                        list.Add((i, j - 1, resultmap[i, j - 1]));
                        list.Add((i + 1, j - 1, resultmap[i + 1, j - 1]));

                        list.Add((i - 1, j, resultmap[i - 1, j]));
                        list.Add((i, j, resultmap[i, j]));
                        list.Add((i + 1, j, resultmap[i + 1, j]));

                        list.Add((i - 1, j + 1, resultmap[i - 1, j + 1]));
                        list.Add((i, j + 1, resultmap[i, j + 1]));
                        list.Add((i + 1, j + 1, resultmap[i + 1, j + 1]));
                        MakeChoise(list, i, j);
                        list.Clear();
                    }
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            list.Add((i, j, resultmap[i, j]));
                            list.Add((i + 1, j, resultmap[i + 1, j]));

                            list.Add((i, j + 1, resultmap[i, j + 1]));
                            list.Add((i + 1, j + 1, resultmap[i + 1, j + 1]));

                            MakeChoise(list, i, j);
                            list.Clear();
                        }
                        if (j == resultmap.GetLength(1) - 1)
                        {
                            list.Add((i, j - 1, resultmap[i, j - 1]));
                            list.Add((i + 1, j - 1, resultmap[i + 1, j - 1]));

                            list.Add((i, j, resultmap[i, j]));
                            list.Add((i + 1, j, resultmap[i + 1, j]));

                            MakeChoise(list, i, j);
                            list.Clear();
                        }
                    }
                    if (i == resultmap.GetLength(0) - 1)
                    {
                        if (j == 0)
                        {

                            list.Add((i - 1, j, resultmap[i - 1, j]));
                            list.Add((i, j, resultmap[i, j]));

                            list.Add((i - 1, j + 1, resultmap[i - 1, j + 1]));
                            list.Add((i, j + 1, resultmap[i, j + 1]));

                            MakeChoise(list, i, j);
                            list.Clear();
                        }
                        if (j == resultmap.GetLength(1) - 1)
                        {
                            list.Add((i - 1, j - 1, resultmap[i - 1, j - 1]));
                            list.Add((i, j - 1, resultmap[i, j - 1]));

                            list.Add((i - 1, j, resultmap[i - 1, j]));
                            list.Add((i, j, resultmap[i, j]));

                            MakeChoise(list, i, j);
                            list.Clear();
                        }
                    }
                    if (j == 0)
                    {
                        if (i == 0)
                        {
                            list.Add((i, j, resultmap[i, j]));
                            list.Add((i + 1, j, resultmap[i + 1, j]));

                            list.Add((i, j + 1, resultmap[i, j + 1]));
                            list.Add((i + 1, j + 1, resultmap[i + 1, j + 1]));

                            MakeChoise(list, i, j);
                            list.Clear();
                        }
                        if (i == resultmap.GetLength(0) - 1)
                        {
                            list.Add((i - 1, j, resultmap[i - 1, j]));
                            list.Add((i, j, resultmap[i, j]));

                            list.Add((i - 1, j + 1, resultmap[i - 1, j + 1]));
                            list.Add((i, j + 1, resultmap[i, j + 1]));

                            MakeChoise(list, i, j);
                            list.Clear();
                        }
                    }
                    if (j == resultmap.GetLength(1) - 1)
                    {
                        if (i == 0)
                        {
                            list.Add((i, j - 1, resultmap[i, j - 1]));
                            list.Add((i + 1, j - 1, resultmap[i + 1, j - 1]));

                            list.Add((i, j, resultmap[i, j]));
                            list.Add((i + 1, j, resultmap[i + 1, j]));

                            MakeChoise(list, i, j);
                            list.Clear();
                        }
                        if (i == resultmap.GetLength(0) - 1)
                        {
                            list.Add((i - 1, j - 1, resultmap[i - 1, j - 1]));
                            list.Add((i, j - 1, resultmap[i, j - 1]));

                            list.Add((i - 1, j, resultmap[i - 1, j]));
                            list.Add((i, j, resultmap[i, j]));

                            MakeChoise(list, i, j);
                            list.Clear();
                        }
                    }
                }
            }
        }
        static void MakeChoise(List<(int, int, int)> list, int i, int j)
        {
            List<(int, int, int )> lifeList = new List<(int, int, int)>();
            List<(int , int , int )> noLifeList = new List<(int, int, int)>();
            foreach (var item in list)
            {
                if (item.Item3 == 1)
                {
                    lifeList.Add(item);
                }
                else if(item.Item3 == 0)
                {
                    noLifeList.Add(item);
                }
            }
            if ((lifeList.Count == 3) && resultmap[i, j] == 0)
                resultmap[i, j] = 1;
            if ((lifeList.Count < 3  || lifeList.Count > 4) && resultmap[i, j] == 1)
            {
                resultmap[i, j] = 0;
            }
        }
    }
}
