using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1072041
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 1; i <= 9; i++)
            {
                Button btn = (Button)Controls.Find("button" + i, true)[0];
                btn.Click += new System.EventHandler(btn_Click);
                btn.Font = new System.Drawing.Font("微軟正黑體", 20.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(136)));
            }
            label2.Font = new System.Drawing.Font("微軟正黑體", 20.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(136)));
        }
        private bool b;
        private bool win;
        int x = 0;
        int o = 0;
        void btn_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "")
            {
                string who = b ? "X" : "O";
                ((Button)sender).Text = who;
                ((Button)sender).ForeColor = b ? Color.Red : Color.Green;
                label2.Text = b ? "O" : "X";
                label2.ForeColor = b ? Color.Green : Color.Red;
                if (Whowin(who))
                {
                    MessageBox.Show(who + "贏了");
                    if (b) label6.Text = Convert.ToString(++x);
                    else label7.Text = Convert.ToString(++o);

                    Clean();
                }
                if (Peace())
                {
                    MessageBox.Show("平手");
                    Clean();
                }
                b = !b;
            }
        }
        private bool Peace()
        {
            bool space = false;
            for (int i = 1; i <= 9; i++)
            {
                Button btn = (Button)Controls.Find("button" + i, true)[0];
                if (btn.Text == "") space = true;
            }
            return space ? false : true;
        }
        private bool Whowin(string who)
        {
            win = false;
            bool[] now = new bool[9];
            for (int i = 1; i <= 9; i++)
            {
                Button btn = (Button)Controls.Find("button" + i, true)[0];
                if (btn.Text == who)
                {
                    now[i - 1] = true;
                }
            }
            for (int i = 0; i <= 7; i++)
            {
                int count = 0;
                for (int j = 0; j <= 2; j++)
                {
                    if (now[arr[i, j]]) count++;
                }
                if (count == 3)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        Button btn = (Button)Controls.Find("button" + (arr[i, j] + 1), true)[0];
                        btn.ForeColor = Color.Wheat;
                        btn.Font = new System.Drawing.Font("微軟正黑體", 20.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(136)));
                        btn.BackColor = Color.Red;
                    }
                    win = true;
                    break;
                }
            }
            return win ? true : false;
        }
        private void Clean()
        {
            for (int i = 1; i <= 9; i++)
            {
                Button btn = (Button)Controls.Find("button" + i, true)[0];
                btn.Text = "";
                btn.BackColor = SystemColors.Control;
                btn.UseVisualStyleBackColor = true;
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private int[,] arr = new int[,] { { 0, 1, 2 },
                                          { 3, 4, 5 },
                                          { 6, 7, 8 },
                                          { 0, 3, 6 },
                                          { 1, 4, 7 },
                                          { 2, 5, 8 },
                                          { 0, 4, 8 },
                                          { 2, 4, 6 } };
    }
}
