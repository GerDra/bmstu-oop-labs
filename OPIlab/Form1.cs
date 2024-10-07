using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OPIlab;

namespace OPIlab
{
    using System;
    using static System.Windows.Forms.AxHost;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

    public partial class Form1 : Form
    {
        public int counterMD;
        public Detail[] md;
        public Detail[] rd;
        public void PrintMD(Detail []md, int i)
        {
            dataGrid.Rows.Add();
            dataGrid.Rows[i].Cells[0].Value = i + 1;
            dataGrid.Rows[i].Cells[1].Value = md[i].code;
            dataGrid.Rows[i].Cells[2].Value = md[i].category;
            dataGrid.Rows[i].Cells[3].Value = md[i].quantity;
            dataGrid.Rows[i].Cells[4].Value = md[i].price;
            dataGrid.Rows[i].Cells[5].Value = md[i].quantity * md[i].price;
        }
            
        public Form1()
        {
            InitializeComponent();
            counterMD = 0;
            md = new Detail[7];
            counterMD = 7;
            md[0].code = "25";
            md[0].category = "klin";
            md[0].quantity = 5;
            md[0].price = 10;

            md[1].code = "253";
            md[1].category = "klin";
            md[1].quantity = 50;
            md[1].price = 10;

            md[2].code = "5";
            md[2].category = "dsjlkgh";
            md[2].quantity = 35;
            md[2].price = 120;

            md[3].code = "256";
            md[3].category = "likdhjoi";
            md[3].quantity = 59;
            md[3].price = 10;

            md[4].code = "532";
            md[4].category = "klin";
            md[4].quantity = 15;
            md[4].price = 153;

            md[5].code = "500";
            md[5].category = "wewe";
            md[5].quantity = 11;
            md[5].price = 15;

            md[6].code = "25";
            md[6].category = "klin";
            md[6].quantity = 30;
            md[6].price = 9;
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form2 examp = new Form2();
            //examp.Show();
            examp.Owner = this;
            examp.ShowDialog();
            if (examp.DialogResult == DialogResult.OK)
            {
                counterMD++;
                Array.Resize(ref md, counterMD);
                md[counterMD-1] = examp.d;
                ToolStripMenuItem6_Click(sender,e);
            }
            
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            int del = 0; bool flag = false;
            Form4 form4 = new Form4();
            form4.ShowDialog();
            del = form4.del - 1;
            dataGrid.Rows.Clear();
            if (form4.DialogResult == DialogResult.OK && del != -1 && del < counterMD && counterMD != 0)
            {
                counterMD--;
                for (int i = 0; i < counterMD; i++)
                {
                    if (i == del)
                        flag = true;
                    if (flag)
                        md[i] = md[i + 1];
                }
                Array.Resize(ref md, counterMD);

                for (int i = 0; i < md.Length; i++) PrintMD(md, i);
            }
        }
        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            int i,j;
            dataGrid.Rows.Clear();
            for(i= 0; i < md.Length; i++)
            {
                PrintMD(md, i);
            }
        }

        
            private void ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            string categ;
            int counterCateg=0;
            Form3 examp = new Form3();
            examp.Owner = this;
            examp.ShowDialog();
            categ = examp.categ;
            dataGrid.Rows.Clear();

            for(int i = 0; i < md.Length; i++)
            {
                if (md[i].category == categ) {
                dataGrid.Rows.Add();
                dataGrid.Rows[counterCateg].Cells[0].Value = counterCateg + 1;
                dataGrid.Rows[counterCateg].Cells[1].Value = md[i].code;
                dataGrid.Rows[counterCateg].Cells[2].Value = md[i].category;
                dataGrid.Rows[counterCateg].Cells[3].Value = md[i].quantity;
                dataGrid.Rows[counterCateg].Cells[4].Value = md[i].price;
                dataGrid.Rows[counterCateg].Cells[5].Value = md[i].quantity * md[i].price;
                counterCateg++;
                }
            }
            
        }

        private void ToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            int counterPrice = 0;
            float total, maxPrice;
            string maxCat = md[0].category; ;
            total = maxPrice = 0;
            dataGrid.Rows.Clear();

            for (int i = 0; i < md.Length; i++)
            {
                total = 0;
                for (int j = 0; j < md.Length; j++)
                {
                    if (md[i].category == md[j].category)
                        total = total + md[j].quantity * md[j].price;
                }
                    if (maxPrice < total)
                    {
                        maxPrice = total;
                        maxCat = md[i].category;
                    }
            }

            for (int i = 0; i < md.Length; i++)
            {
                total = md[i].quantity * md[i].price;
                if (md[i].category == maxCat)
                {
                    dataGrid.Rows.Add();
                    dataGrid.Rows[counterPrice].Cells[0].Value = counterPrice + 1;
                    dataGrid.Rows[counterPrice].Cells[1].Value = md[i].code;
                    dataGrid.Rows[counterPrice].Cells[2].Value = md[i].category;
                    dataGrid.Rows[counterPrice].Cells[3].Value = md[i].quantity;
                    dataGrid.Rows[counterPrice].Cells[4].Value = md[i].price;
                    dataGrid.Rows[counterPrice].Cells[5].Value = md[i].quantity * md[i].price;
                    counterPrice++;
                }
            }
        }

        private void ToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Owner = this;
            form5.md = new Detail[md.Length];
            form5.md = md;
            form5.ShowDialog();
            
        }

        public bool flaf=false;
        private void ToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            rd=new Detail[md.Length];
            for(int i=0;i<md.Length;i++)
                rd[i] = md[i];
            

            Detail temp;
            temp = new Detail();
            dataGrid.Rows.Clear();
            if (flaf)
            {
                for (int i = 0; i < md.Length - 1; i++)
                {
                    for (int j = 0; j < md.Length - i - 1; j++)
                    {
                        if (rd[j].price < rd[j + 1].price)
                        {
                            temp = rd[j];
                            rd[j] = rd[j + 1];
                            rd[j + 1] = temp;
                        }
                    }
                }
                for (int i = 0; i < md.Length; i++) PrintMD(rd, i);
                flaf = false;
            }
            else {
                for (int i = 0; i < md.Length - 1; i++)
                {
                    for (int j = 0; j < md.Length - i - 1; j++)
                    {
                        if (rd[j].price > rd[j + 1].price)
                        {
                            temp = rd[j];
                            rd[j] = rd[j + 1];
                            rd[j + 1] = temp;
                        }
                    }
                }
                for (int i = 0; i < md.Length; i++) PrintMD(rd, i);
                flaf = true;
            }
        }
    }
}
