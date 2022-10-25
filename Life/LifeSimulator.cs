using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Life
{
    public partial class LifeSimulator : Form
    {
        static int[,] map = Map.MyMap;
        const int x = 75;
        const int y = 75;
        static Image lifeImage;
        Graphics g;

        public LifeSimulator()
        {
            InitializeComponent();
        }
        private void LifeSimulator_Load(object sender, EventArgs e)
        {
            this.Width = map.GetLength(1) * x + 17;
            this.Height = map.GetLength(0) * y + 40;
            pictureBox1.Width = map.GetLength(1) * x;
            pictureBox1.Height = map.GetLength(0) * y;
            lifeImage = new Bitmap(map.GetLength(1) * x, map.GetLength(0) * y);
            g = Graphics.FromImage(lifeImage);
            timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Start();
            timer1.Tick += new EventHandler(UpdateImage);
        }
        private void UpdateImage(object sender, EventArgs e)
        {
            DrawMap(g);
            UpdateMap.Update(ref map);
        }
        private void LifeSimulator_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawMap(g);
        }
    }
}
