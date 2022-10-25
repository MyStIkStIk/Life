using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Life
{
    public partial class LifeStarter : Form
    {
        static int[,] map = new int[Map.MyMap.GetLength(0), Map.MyMap.GetLength(1)];
        public LifeStarter()
        {
            InitializeComponent();
        }
        private void LifeStarter_Load(object sender, EventArgs e)
        {
            Thread creater = new Thread(CreateButtonMap);
            creater.IsBackground = true;
            creater.Start();
        }
        public void CreateButtonMap()
        {
            int row = map.GetLength(0);
            int column = map.GetLength(1);
            Padding padd = new Padding(1);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Button myButton = new Button { Dock = DockStyle.Fill, BackColor = Color.White, Margin = padd, FlatStyle = FlatStyle.Flat, FlatAppearance = { BorderSize = 0 } };
                    myButton.Click += MyButton_Click;
                    this.Invoke((MethodInvoker)delegate
                    {
                        tableLayoutPanel1.Controls.Add(myButton, j, i);
                        if (tableLayoutPanel1.ColumnCount <= column)
                        {
                            tableLayoutPanel1.ColumnCount++;
                        }
                        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent));
                        tableLayoutPanel1.ColumnStyles[j].Width = 100 / column;
                    });
                }
                this.Invoke((MethodInvoker)delegate
                {
                    tableLayoutPanel1.RowCount++;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent));
                    tableLayoutPanel1.RowStyles[i].Height = 100 / row;
                });
            }
        }
        private void MyButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] == button)
                {
                    int row = i / (tableLayoutPanel1.RowCount - 1);
                    int column = i % (tableLayoutPanel1.ColumnCount - 1);
                    if (map[row, column] == 0)
                    {
                        button.BackColor = Color.Red;
                        map[row, column] = 1;
                    }
                    else
                    {
                        button.BackColor = Color.White;
                        map[row, column] = 0;
                    }
                }
            }
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            Map.MyMap = map;
            new Thread(() =>
            {
                LifeSimulator life = new LifeSimulator();
                life.ShowDialog();
            }).Start();
            this.Close();
        }
    }
}
