using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OPIlab
{
    public partial class Form2 : Form
    {
        
        public Detail d;




        public Form2()
        {
            InitializeComponent();
        }


       private Detail getDetail()
            { return d; }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            if (textCode.Text == string.Empty)
            {
                MessageBox.Show("Недопустимые значения параметров.", "Ошибка");
                return;
            }
            d.code = textCode.Text;
            if (textCat.Text == string.Empty)
            {
                MessageBox.Show("Недопустимые значения параметров.", "Ошибка");
                return;
            }
            d.category=textCat.Text;
            if (textQ.Text==string.Empty)
                d.quantity = 0;
            else d.quantity = int.Parse(textQ.Text);
            if (textP.Text == string.Empty)
                d.price = 0;
            else d.price = float.Parse(textP.Text);
            Close();

        }
    }
}
