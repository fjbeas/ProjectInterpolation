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
        public string checkb;
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
            
            runExecute();
            Form1.ActiveForm.Size = new Size(Form1.ActiveForm.Size.Width, 580);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void runExecute()
        {
            //Revisando checkboxes
            InterpolatingData data = new InterpolatingData();
            data.op1 = (checkBox1.Checked == true) ? "lagrange" : "N/A";
            data.op2 = (checkBox2.Checked == true) ? "cubic" : "N/A";
            checkb = (checkBox3.Checked == true) ? "graficar" : "N/A";
            data.num = textBox1.Text;

            //Guardando ruta*/
            filepath = openFileDialog1.FileName;

            //Leer datos archivo
            data.ReadDataPoints(filepath);

            //Estableciendo conexion 
            Client_A CallServer = new Client_A();
            CallServer.data = data.result;
            CallServer.ClientCon();

            //Preparando resultados
            data.dataResult = CallServer.data;

            data.PrepareResults();

            //ETAPA DE LA GRAFICA
            if (data.op1 == "lagrange" && data.op2 == "no" && checkb == "graficar")
            {
                MessageBox.Show("No hay grafica disponible para el metodo lagrange");
            }

            label2.Text = "Lgr f(" + data.num + ") =" + data.lgr;
            label5.Text = "CS f(" + data.num + ") =" + data.cs;
            button1.Visible = false;

            if (checkb == "graficar" && data.op2 == "cubic")
            {
                GnuPlot.WriteLine("set term png");
                GnuPlot.WriteLine(@"set output 'c:\users\franciscojavier\desktop\interpolation.png'");
                data.range();
                GnuPlot.WriteLine("set xrange ["+data.r1+":"+data.r2+"]");
               // GnuPlot.WriteLine("");
                GnuPlot.Plot(data.ec);
                GnuPlot.WriteLine("quit");
                System.Threading.Thread.Sleep(500);
                filepath = (@"C:\Users\FranciscoJavier\Desktop\interpolation.png");
                this.pictureBox1.Image = Image.FromFile(filepath);
            }

            MessageBox.Show("La ecuación es: " + data.ec);

        }
    }
}
