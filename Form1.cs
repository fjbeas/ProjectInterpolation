using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AwokeKnowing.GnuplotCSharp;

namespace Project_Interpolation
{
    public partial class Form1 : Form
    {
        public string checkb1, checkb2, checkb3;
        public string filepath, num;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string[] array1;
            //Revisando checkboxes
            checkb1 = (checkBox1.Checked == true) ? "lagrange" : "no";
            checkb2 = (checkBox1.Checked == true) ? "cubic" : "no";
            checkb3 = (checkBox1.Checked == true) ? "graficar" : "no";
            

           //Guardando ruta
            filepath = openFileDialog1.FileName;

           //Leer datos archivo
          
            InterpolatingData data = new InterpolatingData();
            data.ReadDataPoints(filepath);

          
           // Client CallServer= new Client(); 
           // CallServer.Execute();   

            MessageBox.Show(data.result); // VERIFICANDO LO QUE SE ENVIA AL SERVER

            /* GnuPlot Code
            GnuPlot.WriteLine("set term png");
            GnuPlot.WriteLine(@"set output 'c:\users\franciscojavier\desktop\interpolation.png'");
            GnuPlot.Plot(spl.formula);
            button1.Visible = false;
            this.pictureBox1.Image = Image.FromFile("c:\users\franciscojavier\desktop\interpolation.png");*/



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            num = textBox1.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
