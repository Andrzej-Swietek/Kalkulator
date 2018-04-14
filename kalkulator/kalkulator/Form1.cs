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
        Control currentPanel;
        CurrencyManager currencyManager;

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
            panelCurrencyConverter.ButtonConvertCurrenciesClicked += CurrencyConvertButtonClicked;

            choosablePanels = new Control[] { panelBasic, panelAdvanced, panelCurrencyConverter, panelMatrix, panelFunctionDraw };
            currencyManager = new CurrencyManager();
            currencyManager.ReadDataFromFile();

            SwitchToLayout(panelBasic);
        }

        void SwitchToLayout(Control panel)
        {
            foreach(var p in choosablePanels)
            {
                p.Visible = false;
            }
            panel.Visible = true;
            currentPanel = panel;
        }
        void Calculate()
        {
            string text = textboxValue.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {
                try
                {
                    double resoult = new Calcualtion(textboxValue.Text).CalculateNew();
                    textboxValue.Text = resoult.ToString("0." + new string('#', 8));
                }
                catch (Calcualtion.CalculationException ex)
                {
                    MessageBox.Show(ex.Message, "Calculator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        async void ConvertCurrency()
        {
            if (!string.IsNullOrWhiteSpace(textboxValue.Text))
            {
                double amount;
                
                CheckBox fromBox = panelCurrencyConverter.panelCurrencyFrom.Controls.
                    OfType<CheckBox>().SingleOrDefault(c => c.Checked);
                CheckBox toBox = panelCurrencyConverter.panelCurrencyTo.Controls.
                    OfType<CheckBox>().SingleOrDefault(c => c.Checked);

                if (fromBox == null || toBox == null) return;

                string from = (string)fromBox.Tag;
                string to = (string)toBox.Tag;

                try
                {
                    amount = new Calcualtion(textboxValue.Text).CalculateNew();
                    double resoult = await currencyManager.Convert(from, to, amount);
                    panelCurrencyConverter.textboxCurrencyOutput.Text = resoult.ToString("0." + new string('#', 8));
                }
                catch (Calcualtion.CalculationException ex)
                {
                    MessageBox.Show(ex.Message, "Calculator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (CurrencyManager.CurrencyConvertException ex)
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
            textboxValue.Text += e.symbol;
        }
        private void EvaluateButtonClicked(object sender, EventArgs e)
        {
            Calculate();
        }
        private void CurrencyConvertButtonClicked(object sedner, EventArgs e)
        {
            ConvertCurrency();
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
        private void button4_Click(object sender, EventArgs e)
        {
            SwitchToLayout(panelMatrix);
        }
        private void btnLayoutFunctionDraw_Click(object sender, EventArgs e)
        {
            SwitchToLayout(panelFunctionDraw);
        }

        private void textboxValue_TextChanged(object sender, EventArgs e)
        {
            panelFunctionDraw.FunctionString = textboxValue.Text;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                this.Focus();
                if (currentPanel is PanelBasic || currentPanel is PanelAdvanced)
                {
                    Calculate();
                }
                else if (currentPanel is PanelCurrencyConverter)
                {
                    ConvertCurrency();
                }
                else if (currentPanel is PanelFunctionDraw)
                {
                    panelFunctionDraw.DoPaint();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
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
