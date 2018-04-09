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
    public partial class NumpadBasic : UserControl
    {     
        public event EventHandler<NumberButtonClickedEventArgs> NumberButtonClicked;
        public event EventHandler CommaButtonClicked;

        public NumpadBasic()
        {
            InitializeComponent();
        }


        private void btnComma_Click(object sender, EventArgs e)
        {
            CommaButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            NumberButtonClicked?.Invoke(this, new NumberButtonClickedEventArgs(int.Parse((string)((Button)sender).Tag)));
        }
    }
}
