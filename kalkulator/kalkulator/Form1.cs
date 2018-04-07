using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kalkulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        //gdy dowolny przycisk numeryczny zostanie ciśnięty wykonaj tą funkcje
        //
        void onClick_btnNum(object sender, EventArgs args)
        {
            int digit = int.Parse((string)((Button)sender).Tag);
            textboxValue.Text += digit;
        }


        void onClick_btnZnak(object sender, EventArgs args)
        {
            string operation = (string)((Button)sender).Tag;
            textboxValue.Text += " "+ operation + " ";
        }

        private void btnEvaluate_Click(object sender, EventArgs e) //oblicz
        {
            try
            {
                float resoult = new Obliczenie(textboxValue.Text).NoWezIOblicz();
                textboxValue.Text = resoult.ToString();
            }
            catch(Obliczenie.CalculationException ex)
            {
                MessageBox.Show(ex.Message, "Calculator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e) //button zaawansowane
        {
            panelBasic.Visible = false;
            panelAdvanced.Visible = true;
            //panelPrzelicznik.Visible = false;
           
        }

        private void btn_basic_Click(object sender, EventArgs e) //button podstawowe
        {
            panelBasic.Visible = true;
            panelAdvanced.Visible = false;
        }

        
    }
}
