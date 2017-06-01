using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == textBox2.Text)&&(textBox1 .Text .Length > 0))
            {
                try
                {
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/ProgramData/locker/locklog.accdb;Persist Security Info=True;Jet OLEDB:Database Password=test");
                    con.Open();
                    OleDbCommand comm = new OleDbCommand();
                    comm.CommandText = "update locklog set passwd='" + textBox1.Text + "' where id=1";
                    comm.Connection = con;
                    comm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("password set");
                }
                catch (Exception q)
                {
                    MessageBox.Show(q.Message);
                }
                Application.Exit();

            }
            else
            {
                MessageBox.Show("password dont match");
            }
        }
    }
}
