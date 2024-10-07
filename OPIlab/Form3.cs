using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPIlab
{
    public partial class Form3 : Form
    {
        public string categ;
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(textBox1.Text==string.Empty)
            {
                MessageBox.Show("Недопустимые значения параметров.", "Ошибка");
                return;
            }
            //Text = textBox1.Text;
            categ = textBox1.Text;

        }
    }
}
