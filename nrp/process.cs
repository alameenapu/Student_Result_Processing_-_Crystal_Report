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
    public partial class process : Form
    {
        public int a;
        public int b;
        public int average;
        public int ct;
        public int tot;
        public int all;
        public double g;
        SqlConnection vcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Opu\Documents\aa.mdf;Integrated Security=True;Connect Timeout=30");

        int p;
        public process()
        {
            //int b;
            vcon.Open();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Select();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (p == 10)
                p++;
            progressBar1.PerformStep();
            progressBar1.Refresh();



        }

        private void process_Load(object sender, EventArgs e)
        {
            panel3.Location = new Point(837, 260);
            timer1.Start();
            progressBar1.Minimum = p;
            progressBar1.Maximum = 10;
            //panel2.Location = new Point(1000, 213);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel4.Hide();
            panel3.Hide();
            panel1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (textBox1.Text == "")
            {
                MessageBox.Show("PLEASE INSERT ALL THE INFORMATIONS");
                panel1.Hide();
            }

            else
            {


                string vsql = string.Format("insert into stdinfo values('{0}','{1}','{2}','{3}')", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                SqlCommand vcom = new SqlCommand(vsql, vcon);
                vcom.ExecuteNonQuery();
                MessageBox.Show("INFORMATION INSERTED SUCCESFULLY");
                vcom.Dispose();
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            panel1.Hide();


        }

        private void button5_Click(object sender, EventArgs e)
        {

            //AVERAGE
            try
            {
                a = int.Parse(textBox7.Text);
                b = int.Parse(textBox8.Text);

                if (a < b)
                {
                    int temp = a;
                    a = b;
                    b = temp;
                }

                int res = a - b;
                label22.Text = res.ToString();
                if (res < 15)
                {
                    average = (a + b) / 2;
                    label21.Text = average.ToString();
                    string vsql = string.Format("insert into mark values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", textBox5.Text, textBox6.Text, a, b, average, textBox10.Text, textBox12.Text, textBox13.Text, ct, label19.Text, label20.Text);
                    SqlCommand vcom = new SqlCommand(vsql, vcon);
                    vcom.ExecuteNonQuery();
                    timer1.Start();
                    MessageBox.Show("RESULT INSERTED SUCCESSFULLY");
                    vcom.Dispose();
                    panel2.Hide();

                }

                else
                {
                    panel2.Hide();
                    MessageBox.Show("INTERNAL AND EXTERNAL MARKS DIFFERENCE IS MORE THAN 15 \n   SO THIRD EXAMINEER MARK IS NEEDED");
                    panel3.Location = new Point(398, 213);
                    panel3.Show();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("PLEASE INSERT ALL THE INFORMATION");

                panel2.Hide();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel3.Hide();
            panel4.Hide();
            panel2.Show();


        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel2.Location = new Point(panel2.Location.X - 10, panel2.Location.Y);
            if (panel2.Location.X == 600)
            {
                panel2.Location = new Point(600, 213);
                //timer2.Dispose();
            }

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // int average;
            a = int.Parse(textBox7.Text);
            b = int.Parse(textBox8.Text);

            if (a < b)
            {
                int temp = a;
                a = b;
                b = temp;

            }
            int res1 = a - b;
           



            average = (a + b) / 2;
            label21.Text = average.ToString();



            string updateQuery = string.Format("insert into mark values ( '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10})", textBox5.Text, textBox6.Text, a, b, label21.Text, textBox10.Text, textBox12.Text, textBox13.Text, ct, all, label20.Text);
            SqlCommand vcom = new SqlCommand(updateQuery, vcon);
            vcom.ExecuteNonQuery();

            vcom.Dispose();

            int x = int.Parse(textBox10.Text);
            int first, second, avg = 0;
            first = x - a;
            second = x - b;
            if (first < 0)
                first = first * (-1);

            if (second < 0)
                second = second * (-1);

            if (first > second)
                avg = (x + b) / 2;

            if (second > first)
                avg = (x + a) / 2;


            /* ct = int.Parse(textBox12.Text);
           int at = int.Parse(textBox13.Text);
           tot = ct + at;
           all = tot + average;
           label19.Text = all.ToString();*/
            //GPA
            if (all >= 40 && all <= 44)
            {
                g = 2.00;

                label20.Text = g.ToString();
            }
            if (all >= 45 && all <= 49)
            {
                g = 2.25;
                label20.Text = g.ToString();
            }
            if (all >= 50 && all <= 54)
            {
                g = 2.50;
                label20.Text = g.ToString();
            }
            if (all >= 55 && all <= 59)
            {
                g = 2.75;
                label20.Text = g.ToString();
            }
            if (all >= 60 && all <= 64)
            {
                g = 3.00;
                label20.Text = g.ToString();
            }
            if (all >= 65 && all <= 69)
            {
                g = 3.25;
                label20.Text = g.ToString();
            }
            if (all >= 70 && all <= 74)
            {
                g = 3.50;
                label20.Text = g.ToString();
            }
            if (all >= 75 && all <= 79)
            {
                g = 3.75;
                label20.Text = g.ToString();
            }
            if (all >= 79 && all <= 100)
            {
                g = 4.00;
                label20.Text = g.ToString();
            }

            string n = string.Format("update mark set AVERAGE = '{0}',TOTAL_MARKS='{1}',CGPA='{2}' where ID = '{3}'", avg, all, label20.Text, textBox9.Text);
            SqlCommand vncom = new SqlCommand(n, vcon);
            vncom.ExecuteNonQuery();
            MessageBox.Show("PROCEDURE SUCCED");
            vncom.Dispose();
            MessageBox.Show("SUCCESS");
            panel3.Hide();




            // catch (Exception EX)
            //{
            //MessageBox.Show("WRONG PROCUDERE");
            //  }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            panel4.Location = new Point(837, 210);
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RESULT r = new RESULT();
            r.Show();
            process p = new process();
            p.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
           // a = int.Parse(textBox7.Text);
            //b = int.Parse(textBox8.Text);

            /*if (a < b)
            {
                int temp = a;
                a = b;
                b = temp;

            }*/
            int res = a - b;



           // average = (a + b) / 2;
            label21.Text = average.ToString();


          


            if ( res< 15)
            {
                label21.Text = average.ToString();

            }

            else
            {
                int x = int.Parse(textBox10.Text);
                int first, second;
                average = 0;
                first = x - a;
                second = x - b;
                if (first < 0)
                    first = first * (-1);

                if (second < 0)
                    second = second * (-1);

                if (first > second)
                    average = (x + b) / 2;

                if (second > first)
                    average = (x + a) / 2;
                label21.Text=average.ToString();
            }



                //class
                try
                {
                    int ct = int.Parse(textBox12.Text);
                    int at = int.Parse(textBox13.Text);
                    tot = ct + at;
                    all = tot + average;
                    label19.Text = all.ToString();
                    //GPA
                    if (all >= 40 && all <= 44)
                    {
                        g = 2.00;

                        label20.Text = g.ToString();
                    }
                    if (all >= 45 && all <= 49)
                    {
                        g = 2.25;
                        label20.Text = g.ToString();
                    }
                    if (all >= 50 && all <= 54)
                    {
                        g = 2.50;
                        label20.Text = g.ToString();
                    }
                    if (all >= 55 && all <= 59)
                    {
                        g = 2.75;
                        label20.Text = g.ToString();
                    }
                    if (all >= 60 && all <= 64)
                    {
                        g = 3.00;
                        label20.Text = g.ToString();
                    }
                    if (all >= 65 && all <= 69)
                    {
                        g = 3.25;
                        label20.Text = g.ToString();
                    }
                    if (all >= 70 && all <= 74)
                    {
                        g = 3.50;
                        label20.Text = g.ToString();
                    }
                    if (all >= 75 && all <= 79)
                    {
                        g = 3.75;
                        label20.Text = g.ToString();
                    }
                    if (all >= 79 && all <= 100)
                    {
                        g = 4.00;
                        label20.Text = g.ToString();
                    }

                    string vsql = string.Format("insert into ct values('{0}','{1}','{2}','{3}')", textBox11.Text, ct, at, tot);
                    SqlCommand vcom = new SqlCommand(vsql, vcon);
                    vcom.ExecuteNonQuery();
                    MessageBox.Show("INSERT SUCCESS");
                    vcom.Dispose();

                    string updateString = String.Format("update mark set  CLASS_TEST= '{0}',ATTENDENCE='{1}',CLASS_TOTAL='{2}',TOTAL_MARKS='{3}',CGPA='{4}' where ID = '{5}'", ct, at, tot, all, label20.Text, textBox11.Text);
                    SqlCommand cmd = new SqlCommand(updateString, vcon);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" UPDATE SUCCESS");
                    cmd.Dispose();
                    panel4.Hide();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("INSERT THE INFORMATIONS PROPERLY");
                }
            }



        }

    }


