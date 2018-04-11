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
    public partial class PanelCurrencyConverter : UserControl
    {
        public EventHandler ButtonConvertCurrenciesClicked;

        public PanelCurrencyConverter()
        {
            InitializeComponent();
        }

        private void btnConvertCurrencies_Click(object sender, EventArgs e)
        {
            ButtonConvertCurrenciesClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
