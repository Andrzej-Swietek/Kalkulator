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
    public partial class PanelBasic : UserControl
    {
        public event EventHandler<SymbolButtonClickedEventArgs> SymbolButtonClicked;
        public event EventHandler EvaluateButtonClicked;

        public PanelBasic()
        {
            InitializeComponent();
        }

        private void btnSymbol_Click(object sender, EventArgs e)
        {
            SymbolButtonClicked?.Invoke(this, new SymbolButtonClickedEventArgs((string)((Control)sender).Tag ));
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            EvaluateButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
