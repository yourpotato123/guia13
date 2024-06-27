using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_15_Ejercicio_2
{
    public partial class Form1 : Form
    {
        const int MAX = 1000;
        static int[] codigopostal = new int[MAX];
        static int[] gramos = new int[MAX];
        static int[] empresa = new int[MAX];
        static int pedido = 0;
        static double[] costobase = new double[MAX];
        static double[] costoiva = new double[MAX];
        static double[] costototal = new double[MAX];

        static void Agregar()
        {
            Form2 ventanita = new Form2();
            codigopostal[pedido] = Convert.ToInt32(ventanita.tbCodigo.Text);
            gramos[pedido] = Convert.ToInt32(ventanita.tbPeso.Text);
            empresa[pedido] = Convert.ToInt32(ventanita.cbEmpresa.Text);
            CalcularCosto();
            MessageBox.Show($"BASE:${costobase[pedido]}.F2 IVA:${costoiva[pedido]}.F2 Total:${costototal[pedido]}.F2");
            pedido++;
        }
        static void CalcularCosto()
        {
            Form2 ventanota = new Form2();
            double tarifa = 0.5;
            if (ventanota.cbCertificada.Checked) tarifa = 1;
            costobase[pedido] = gramos[pedido]*tarifa;
            costoiva[pedido]= 0.21* costobase[pedido];
            costototal[pedido] = costobase[pedido] + costoiva[pedido];
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 ventana2 = new Form2();
            while (ventana2.ShowDialog() == DialogResult.OK)
            {
                Agregar();
            }
            Dispose();


        }
    }
}
