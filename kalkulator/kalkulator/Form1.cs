using kalkulator.Panels;
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
            panelBasic.numpad.NumberButtonClicked += NumberButtonClicked;
            panelBasic.numpad.CommaButtonClicked += (s, e) => SymbolButtonClicked(s, new SymbolButtonClickedEventArgs(","));
            panelBasic.SymbolButtonClicked += SymbolButtonClicked;
            panelBasic.EvaluateButtonClicked += EvaluateButtonClicked;
            panelAdvanced.numpad.NumberButtonClicked += NumberButtonClicked;
            panelAdvanced.numpad.CommaButtonClicked += (s, e) => SymbolButtonClicked(s, new SymbolButtonClickedEventArgs(","));
            panelAdvanced.SymbolButtonClicked += SymbolButtonClicked;
            panelAdvanced.EvaluateButtonClicked += EvaluateButtonClicked;
            panelCurrencyConverter.numpad.NumberButtonClicked += NumberButtonClicked;
            panelCurrencyConverter.numpad.CommaButtonClicked += (s, e) => SymbolButtonClicked(s, new SymbolButtonClickedEventArgs(","));

            choosablePanels = new Control[] { panelBasic, panelAdvanced, panelCurrencyConverter };
        }

        void SwitchToLayout(Control panel)
        {
            foreach(var p in choosablePanels)
            {
                p.Visible = false;
            }
            panel.Visible = true;
        }
        void Calculate()
        {
            string text = textboxValue.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {
                try
                {
                    double resoult = new Calcualtion(textboxValue.Text).NoWezIOblicz();
                    textboxValue.Text = resoult.ToString("0." + new string('#', 8));
                }
                catch (Calcualtion.CalculationException ex)
                {
                    MessageBox.Show(ex.Message, "Calculator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private void NumberButtonClicked(object sender, NumberButtonClickedEventArgs e)
        {
            textboxValue.Text += e.digit;
        }
        private void SymbolButtonClicked(object sender, SymbolButtonClickedEventArgs e)
        {
            textboxValue.Text += " " + e.symbol + " ";
        }
        private void EvaluateButtonClicked(object sender, EventArgs e)
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
            SwitchToLayout(panelCurrencyConverter);
        }


    }

    public class NumberButtonClickedEventArgs : EventArgs
    {
        public int digit;
        public NumberButtonClickedEventArgs(int digit) : base()
        {
            this.digit = digit;
        }
    }
    public class SymbolButtonClickedEventArgs : EventArgs
    {
        public string symbol;
        public SymbolButtonClickedEventArgs(string symbol) : base()
        {
            this.symbol = symbol;
        }
    }
}
