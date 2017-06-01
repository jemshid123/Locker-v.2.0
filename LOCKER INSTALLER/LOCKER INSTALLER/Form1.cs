using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "the author of this software is not in any way liable to loss of data that may happen dewto software malfuction.use this software only if you agree to the condition.created by JEMSHID M H,{0} CONTACT jemshidmh@gmail.com"
       ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 a=new Form2();
            a.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
