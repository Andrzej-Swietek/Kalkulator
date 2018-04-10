using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kalkulator.Panels
{
    public partial class PanelMatrix : UserControl
    {
        public string OperationMatrix;



        public PanelMatrix()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//A+B
        {
            OperationMatrix = "+";
        }

        private void button2_Click(object sender, EventArgs e)//A-B
        {
            OperationMatrix = "-";
        }

        private void button3_Click(object sender, EventArgs e)//A*B
        {
            OperationMatrix = "*";
        }

        private void button4_Click(object sender, EventArgs e)//skalar
        {
            OperationMatrix = "λ";
            textBoxLambda.Visible = true;
            label_X.Visible = true;
            label2.Visible = false;
            label_Wynik.Visible = true;
            label_Wynik.Visible = true;
            //ustawić razy i textboxa visible na true
        }

        private void button5_Click(object sender, EventArgs e) //T[]
        {
            OperationMatrix = "T";
            label2.Visible = false; // ta z textem macierz B
            label_Wynik.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e) //odwrotna
        {
            OperationMatrix = "Odw";
            label2.Visible = false; // ta z textem macierz B
            label_Wynik.Visible = true;
            label_Wynik.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OperationMatrix = "Diag";
            label2.Visible = false; // ta z textem macierz B
            label_Wynik.Visible = true;
        }
    }
}
