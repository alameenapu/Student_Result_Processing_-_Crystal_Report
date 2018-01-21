using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace nrp
{
    public partial class Form1 : Form
    {
        SqlConnection vcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Opu\Documents\aa.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            vcon.Open();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*if (textBox1.Text == "cse" && textBox2.Text == "1234")
            {
            }
            else
            {
                panel1.Hide();
                MessageBox.Show("PLEASE ENTER YOUR NAME AND PASSWORD !!! ");
            }*/
               
                process p = new process();
                p.Show();
                Form1 f1 = new Form1();
                f1.Hide();
                //this.Close();
            
            textBox1.Clear();
            textBox2.Clear();

            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Location = new Point(label1.Location.X,label1.Location.Y+1);
            if(label1.Location.Y==55)
            { label1.Location = new Point(136, 45); }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(136, 45);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
