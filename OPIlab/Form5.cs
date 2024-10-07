using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPIlab
{
    public partial class Form5 : Form
    {
        public int[] totalAmount = new int[] { };
        public float[] totalPrice = new float[] { };
        public Detail[] md;
        public void print(int i)
        {
            dataGridView.Rows.Add();
            dataGridView.Rows[i].Cells[0].Value = i + 1;
            dataGridView.Rows[i].Cells[1].Value = codeFind[i];
            dataGridView.Rows[i].Cells[2].Value = totalAmount[i];
            dataGridView.Rows[i].Cells[3].Value = totalPrice[i];
        }
        public int countC;
        public string[] codeFind;
        public Form5()
        {
            InitializeComponent();
            countC = 0;
            codeFind = new string[] { };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Недопустимые значения параметров.", "Ошибка");
                return;
            }
            else
            {
                countC++;
                Array.Resize(ref codeFind, countC);
                codeFind[countC-1] = textBox1.Text;
            }

            dataGridView.Rows.Clear();

                Array.Resize(ref totalAmount, codeFind.Length);
                Array.Resize(ref totalPrice, codeFind.Length);

            for (int i = 0; i < codeFind.Length; i++)
                {
            totalAmount[i] = 0;
            totalPrice[i] = 0;
                    for (int j = 0; j < md.Length; j++)
                    {
                        if (codeFind[i] == md[j].code)
                        {
                            totalAmount[i] = totalAmount[i] + md[j].quantity;
                            totalPrice[i] = totalPrice[i] + md[j].price*md[j].quantity;
                        }
                    }
                }

            for (int i = 0; i < codeFind.Length; i++)
            {
                print(i);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int countF = 0;
            bool flag = false;
            string codeDel = textBox1.Text;
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Недопустимые значения параметров.", "Ошибка");
                return;
            }
            int i = 0; 
            while (i < codeFind.Length)
            {
                if (codeFind[i] == codeDel)
                {
                    countF++;
                    countC--;
                    for (int j = i; j < codeFind.Length - 1; j++)
                        codeFind[j] = codeFind[j + 1];

                    Array.Resize(ref codeFind, codeFind.Length - 1);
                }
                else i++;
            }

            
            dataGridView.Rows.Clear();
            
            for (i = 0; i < codeFind.Length; i++)
                print(i);
              
        }
    }
}
