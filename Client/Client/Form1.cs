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
using System.Net.Http;
using System.Net;
using System.Collections.Specialized;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static readonly HttpClient client = new HttpClient();
        HttpClass test = new HttpClass();

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                string kod = textBox1.Text;
                richTextBox1.Text = test.GetTest(kod);
            }

            if (radioButton2.Checked == true)
            {
                string str = richTextBox1.Text;
                test.PostTest(str);
            }


            if (radioButton3.Checked == true)
            {
                string str = richTextBox1.Text;
                
                test.MessageUpdate(3, str);
            }


            if (radioButton4.Checked == true)
            {
                test.MessageDelete(3);
            }

        }
    }
}
