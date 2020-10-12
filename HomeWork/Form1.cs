using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace HomeWork
{
    public partial class Form1 : Form
    {
        int point=0;
        int life=10;
        int level;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            label1.Text = point.ToString();
            label2.Text = life.ToString();
            timer1.Interval = 500;
            label3.Text ="난이도를 먼저 선택해주세요";
            
        }

        private string File()
        {
            
            List<string> list = new List<string>();
            Random rand = new Random();
            using (StreamReader sr = new StreamReader("level1.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                   
                }
            }

            int a = rand.Next(0, list.Count);
            string[] a_sr = list.ToArray();
           
            return a_sr[a];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (progressBar1.Value < 10)
            {
                life = life - 1;
                label2.Text = life.ToString();
                progressBar1.Value = 100;
                timer1.Stop();
            }
            else
                progressBar1.Value = progressBar1.Value - level;

           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.KeyChar//캐릭 값
               if(e.KeyChar==13)//13이 엔터를 뜻함
            {
               
                if (textBox1.Text == label3.Text)
                {
                    point = point + 100;
                    label1.Text = point.ToString();
                   
                    label3.Text = File();
                    textBox1.Text = "";
                    timer1.Stop();
                }
                else
                {
                    life = life - 1;
                    label2.Text = life.ToString();
                    
                    label3.Text = File();
                    textBox1.Text = "";
                    if (life == 0)
                    {
                        MessageBox.Show("목숨이 다 됬습니다.");
                        Close();
                    }
                    timer1.Stop();
                }
                progressBar1.Value = 100;
            }
          

        }

        private void 초급ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label3.Text = File();
            level = 10;
        }

        private void 중급ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label3.Text = File();
            level = 20;
        }

        private void 고급ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label3.Text = File();
            level = 30;
        }
    }
}
