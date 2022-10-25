using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    public partial class LifeSimulator
    {
        public void DrawMap(Graphics g)
        {
            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    if (map[i, j] == 0)
                        g.DrawImage(Properties.Resources.No_Corona, j * y, i * x, new Rectangle(new Point(0, 0), new Size(x, y)), GraphicsUnit.Pixel);
                    else
                        g.DrawImage(Properties.Resources.corona, j * y, i * x, new Rectangle(new Point(0, 0), new Size(x, y)), GraphicsUnit.Pixel);
                }
            }
            pictureBox1.Image = lifeImage;
        }
    }
}
