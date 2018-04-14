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
    public partial class PanelFunctionDraw : UserControl
    {
        public string FunctionString { get; set; }
        
        public PanelFunctionDraw()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            SetFunction();
        }

        public void SetFunction()
        {
            Dictionary<char,double> calcSymbolDir = new Dictionary<char, double>();
            Calcualtion calc = new Calcualtion(FunctionString);
            calc.PrepareCalculation();

            functionDrawerBox.f = (x) => 
            {
                calcSymbolDir['x'] = x;
                return calc.Calculate(calcSymbolDir);
            };
            functionDrawerBox.Invalidate();
        }
    }
}
