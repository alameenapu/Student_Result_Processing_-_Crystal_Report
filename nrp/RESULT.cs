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
    public partial class RESULT : Form
    {
        SqlConnection vcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Opu\Documents\aa.mdf;Integrated Security=True;Connect Timeout=30");
        public RESULT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            process p = new process();
            p.Select();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            panel1.Show();
            string vsql = "select * from mark";
            SqlCommand vcom = new SqlCommand(vsql, vcon);
            DataSet vds = new DataSet();
            SqlDataAdapter vda = new SqlDataAdapter(vcom);
            vda.Fill(vds, "row");
            dataGridView1.DataSource = vds.Tables["row"];
            vda.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string vsql = "delete mark";
            SqlCommand vcom = new SqlCommand(vsql, vcon);
            DataSet vds = new DataSet();
            SqlDataAdapter vda = new SqlDataAdapter(vcom);
            vda.Fill(vds, "row");
            dataGridView1.DataSource = vds.Tables["row"];
            MessageBox.Show("TABLE CLERED SUCCESSFULLY");
            vda.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Location = new Point(480,243);
         
            panel2.Show();
            panel1.Hide();
            panel3.Hide();
           // panel2.Show();

            //SHOW
            string vsql = "select * from ct";
            SqlCommand vcom = new SqlCommand(vsql, vcon);
            DataSet vds = new DataSet();
            SqlDataAdapter vda = new SqlDataAdapter(vcom);
            vda.Fill(vds, "row");
            dataGridView2.DataSource = vds.Tables["row"];
            vda.Dispose();
           // panel2.Show();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Location = new Point(800, 243);

            panel3.Show();
            panel1.Hide();
            panel2.Hide();
            // panel2.Show();

            //SHOW
            string vsql = "select * from stdinfo";
            SqlCommand vcom = new SqlCommand(vsql, vcon);
            DataSet vds = new DataSet();
            SqlDataAdapter vda = new SqlDataAdapter(vcom);
            vda.Fill(vds, "row");
            dataGridView3.DataSource = vds.Tables["row"];
            vda.Dispose();
            // panel2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string vsql = "delete ct";
            SqlCommand vcom = new SqlCommand(vsql, vcon);
            DataSet vds = new DataSet();
            SqlDataAdapter vda = new SqlDataAdapter(vcom);
            vda.Fill(vds, "row");
            dataGridView2.DataSource = vds.Tables["row"];
            MessageBox.Show("TABLE CLERED SUCCESSFULLY");
            vda.Dispose();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string vsql = "delete stdinfo";
            SqlCommand vcom = new SqlCommand(vsql, vcon);
            DataSet vds = new DataSet();
            SqlDataAdapter vda = new SqlDataAdapter(vcom);
            vda.Fill(vds, "row");
            dataGridView3.DataSource = vds.Tables["row"];
            MessageBox.Show("TABLE CLERED SUCCESSFULLY");
            vda.Dispose();

        }

        private void RESULT_Load(object sender, EventArgs e)
        {

        }
    }
}
