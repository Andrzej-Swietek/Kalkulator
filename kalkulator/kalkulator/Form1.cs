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
        private Control[] choosablePanels;


        public Form1()
        {
            InitializeComponent();
            choosablePanels = new Control[] { panelBasic, panelAdvanced, panelCurrency };
        }

        void SwitchToLayout(Panel panel)
        {
            foreach(var p in choosablePanels)
            {
                p.Visible = false;
            }
            panel.Visible = true;
        }
        void Calculate()
        {
            try
            {
                double resoult = new Calcualtion(textboxValue.Text).NoWezIOblicz();
                textboxValue.Text = resoult.ToString("0."+new string('#', 8));
            }
            catch (Calcualtion.CalculationException ex)
            {
                MessageBox.Show(ex.Message, "Calculator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            int digit = int.Parse((string)((Button)sender).Tag);
            textboxValue.Text += digit;
        }
        private void btnOperation_Click(object sender, EventArgs e)
        {
            string operation = (string)((Button)sender).Tag;
            textboxValue.Text += " " + operation + " ";
        }
        private void btnComma_Click(object sender, EventArgs e)
        {
            textboxValue.Text += ",";
        }
        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            Calculate();
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textboxValue.Text = "";
        }

        private void btnLayoutBasic_Click(object sender, EventArgs e)
        {
            SwitchToLayout(panelBasic);
        }
        private void btnLayoutAdvanced_Click(object sender, EventArgs e)
        {
            SwitchToLayout(panelAdvanced);
        }
        private void btnLayoutCurrency_Click(object sender, EventArgs e)
        {
            SwitchToLayout(panelCurrency);
        }

       
    }
}
