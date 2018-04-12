namespace kalkulator.Panels
{
    partial class PanelCurrencyConverter
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConvertCurrencies = new System.Windows.Forms.Button();
            this.Wynik = new System.Windows.Forms.Label();
            this.checkboxCurrTo5 = new System.Windows.Forms.CheckBox();
            this.checkboxCurrTo4 = new System.Windows.Forms.CheckBox();
            this.checkboxCurrTo3 = new System.Windows.Forms.CheckBox();
            this.checkboxCurrTo2 = new System.Windows.Forms.CheckBox();
            this.checkboxCurrTo1 = new System.Windows.Forms.CheckBox();
            this.checkboxCurrTo0 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkboxCurrFrom5 = new System.Windows.Forms.CheckBox();
            this.checkboxCurrFrom4 = new System.Windows.Forms.CheckBox();
            this.checkboxCurrFrom3 = new System.Windows.Forms.CheckBox();
            this.checkboxCurrFrom2 = new System.Windows.Forms.CheckBox();
            this.checkboxCurrFrom1 = new System.Windows.Forms.CheckBox();
            this.checkboxCurrFrom0 = new System.Windows.Forms.CheckBox();
            this.textboxCurrencyOutput = new System.Windows.Forms.TextBox();
            this.numpad = new kalkulator.Panels.NumpadBasic();
            this.panelCurrencyFrom = new System.Windows.Forms.Panel();
            this.panelCurrencyTo = new System.Windows.Forms.Panel();
            this.panelCurrencyFrom.SuspendLayout();
            this.panelCurrencyTo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConvertCurrencies
            // 
            this.btnConvertCurrencies.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnConvertCurrencies.Location = new System.Drawing.Point(394, 261);
            this.btnConvertCurrencies.Name = "btnConvertCurrencies";
            this.btnConvertCurrencies.Size = new System.Drawing.Size(192, 43);
            this.btnConvertCurrencies.TabIndex = 27;
            this.btnConvertCurrencies.Text = "Przelicz";
            this.btnConvertCurrencies.UseVisualStyleBackColor = true;
            this.btnConvertCurrencies.Click += new System.EventHandler(this.btnConvertCurrencies_Click);
            // 
            // Wynik
            // 
            this.Wynik.AutoSize = true;
            this.Wynik.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Wynik.Location = new System.Drawing.Point(277, 6);
            this.Wynik.Name = "Wynik";
            this.Wynik.Size = new System.Drawing.Size(88, 31);
            this.Wynik.TabIndex = 26;
            this.Wynik.Text = "Wynik";
            // 
            // checkboxCurrTo5
            // 
            this.checkboxCurrTo5.AutoSize = true;
            this.checkboxCurrTo5.Location = new System.Drawing.Point(3, 115);
            this.checkboxCurrTo5.Name = "checkboxCurrTo5";
            this.checkboxCurrTo5.Size = new System.Drawing.Size(86, 17);
            this.checkboxCurrTo5.TabIndex = 25;
            this.checkboxCurrTo5.Tag = "CNY";
            this.checkboxCurrTo5.Text = "Juan Chiński";
            this.checkboxCurrTo5.UseVisualStyleBackColor = true;
            // 
            // checkboxCurrTo4
            // 
            this.checkboxCurrTo4.AutoSize = true;
            this.checkboxCurrTo4.Location = new System.Drawing.Point(3, 92);
            this.checkboxCurrTo4.Name = "checkboxCurrTo4";
            this.checkboxCurrTo4.Size = new System.Drawing.Size(114, 17);
            this.checkboxCurrTo4.TabIndex = 24;
            this.checkboxCurrTo4.Tag = "USD";
            this.checkboxCurrTo4.Text = "Dolar Amerykański";
            this.checkboxCurrTo4.UseVisualStyleBackColor = true;
            // 
            // checkboxCurrTo3
            // 
            this.checkboxCurrTo3.AutoSize = true;
            this.checkboxCurrTo3.Location = new System.Drawing.Point(3, 69);
            this.checkboxCurrTo3.Name = "checkboxCurrTo3";
            this.checkboxCurrTo3.Size = new System.Drawing.Size(112, 17);
            this.checkboxCurrTo3.TabIndex = 23;
            this.checkboxCurrTo3.Tag = "CHF";
            this.checkboxCurrTo3.Text = "Frank Szwajcarski";
            this.checkboxCurrTo3.UseVisualStyleBackColor = true;
            // 
            // checkboxCurrTo2
            // 
            this.checkboxCurrTo2.AutoSize = true;
            this.checkboxCurrTo2.Location = new System.Drawing.Point(3, 46);
            this.checkboxCurrTo2.Name = "checkboxCurrTo2";
            this.checkboxCurrTo2.Size = new System.Drawing.Size(51, 17);
            this.checkboxCurrTo2.TabIndex = 22;
            this.checkboxCurrTo2.Tag = "PLN";
            this.checkboxCurrTo2.Text = "Złoty";
            this.checkboxCurrTo2.UseVisualStyleBackColor = true;
            // 
            // checkboxCurrTo1
            // 
            this.checkboxCurrTo1.AutoSize = true;
            this.checkboxCurrTo1.Location = new System.Drawing.Point(3, 23);
            this.checkboxCurrTo1.Name = "checkboxCurrTo1";
            this.checkboxCurrTo1.Size = new System.Drawing.Size(48, 17);
            this.checkboxCurrTo1.TabIndex = 21;
            this.checkboxCurrTo1.Tag = "EUR";
            this.checkboxCurrTo1.Text = "Euro";
            this.checkboxCurrTo1.UseVisualStyleBackColor = true;
            // 
            // checkboxCurrTo0
            // 
            this.checkboxCurrTo0.AutoSize = true;
            this.checkboxCurrTo0.Location = new System.Drawing.Point(3, 0);
            this.checkboxCurrTo0.Name = "checkboxCurrTo0";
            this.checkboxCurrTo0.Size = new System.Drawing.Size(47, 17);
            this.checkboxCurrTo0.TabIndex = 20;
            this.checkboxCurrTo0.Tag = "GBF";
            this.checkboxCurrTo0.Text = "Funt";
            this.checkboxCurrTo0.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(547, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Docelowa Jednostka";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Obecna Jednostka";
            // 
            // checkboxCurrFrom5
            // 
            this.checkboxCurrFrom5.AutoSize = true;
            this.checkboxCurrFrom5.Location = new System.Drawing.Point(3, 115);
            this.checkboxCurrFrom5.Name = "checkboxCurrFrom5";
            this.checkboxCurrFrom5.Size = new System.Drawing.Size(86, 17);
            this.checkboxCurrFrom5.TabIndex = 11;
            this.checkboxCurrFrom5.Tag = "CNY";
            this.checkboxCurrFrom5.Text = "Juan Chiński";
            this.checkboxCurrFrom5.UseVisualStyleBackColor = true;
            // 
            // checkboxCurrFrom4
            // 
            this.checkboxCurrFrom4.AutoSize = true;
            this.checkboxCurrFrom4.Location = new System.Drawing.Point(3, 92);
            this.checkboxCurrFrom4.Name = "checkboxCurrFrom4";
            this.checkboxCurrFrom4.Size = new System.Drawing.Size(114, 17);
            this.checkboxCurrFrom4.TabIndex = 10;
            this.checkboxCurrFrom4.Tag = "USD";
            this.checkboxCurrFrom4.Text = "Dolar Amerykański";
            this.checkboxCurrFrom4.UseVisualStyleBackColor = true;
            // 
            // checkboxCurrFrom3
            // 
            this.checkboxCurrFrom3.AutoSize = true;
            this.checkboxCurrFrom3.Location = new System.Drawing.Point(3, 69);
            this.checkboxCurrFrom3.Name = "checkboxCurrFrom3";
            this.checkboxCurrFrom3.Size = new System.Drawing.Size(112, 17);
            this.checkboxCurrFrom3.TabIndex = 9;
            this.checkboxCurrFrom3.Tag = "CHF";
            this.checkboxCurrFrom3.Text = "Frank Szwajcarski";
            this.checkboxCurrFrom3.UseVisualStyleBackColor = true;
            // 
            // checkboxCurrFrom2
            // 
            this.checkboxCurrFrom2.AutoSize = true;
            this.checkboxCurrFrom2.Location = new System.Drawing.Point(3, 46);
            this.checkboxCurrFrom2.Name = "checkboxCurrFrom2";
            this.checkboxCurrFrom2.Size = new System.Drawing.Size(51, 17);
            this.checkboxCurrFrom2.TabIndex = 8;
            this.checkboxCurrFrom2.Tag = "PLN";
            this.checkboxCurrFrom2.Text = "Złoty";
            this.checkboxCurrFrom2.UseVisualStyleBackColor = true;
            // 
            // checkboxCurrFrom1
            // 
            this.checkboxCurrFrom1.AutoSize = true;
            this.checkboxCurrFrom1.Location = new System.Drawing.Point(3, 23);
            this.checkboxCurrFrom1.Name = "checkboxCurrFrom1";
            this.checkboxCurrFrom1.Size = new System.Drawing.Size(48, 17);
            this.checkboxCurrFrom1.TabIndex = 7;
            this.checkboxCurrFrom1.Tag = "EUR";
            this.checkboxCurrFrom1.Text = "Euro";
            this.checkboxCurrFrom1.UseVisualStyleBackColor = true;
            // 
            // checkboxCurrFrom0
            // 
            this.checkboxCurrFrom0.AutoSize = true;
            this.checkboxCurrFrom0.Location = new System.Drawing.Point(3, 0);
            this.checkboxCurrFrom0.Name = "checkboxCurrFrom0";
            this.checkboxCurrFrom0.Size = new System.Drawing.Size(47, 17);
            this.checkboxCurrFrom0.TabIndex = 6;
            this.checkboxCurrFrom0.Tag = "GBP";
            this.checkboxCurrFrom0.Text = "Funt";
            this.checkboxCurrFrom0.UseVisualStyleBackColor = true;
            // 
            // textboxCurrencyOutput
            // 
            this.textboxCurrencyOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textboxCurrencyOutput.Location = new System.Drawing.Point(381, 5);
            this.textboxCurrencyOutput.Name = "textboxCurrencyOutput";
            this.textboxCurrencyOutput.Size = new System.Drawing.Size(252, 38);
            this.textboxCurrencyOutput.TabIndex = 0;
            // 
            // numpad
            // 
            this.numpad.Location = new System.Drawing.Point(0, 0);
            this.numpad.Name = "numpad";
            this.numpad.Size = new System.Drawing.Size(267, 350);
            this.numpad.TabIndex = 28;
            // 
            // panelCurrencyFrom
            // 
            this.panelCurrencyFrom.Controls.Add(this.checkboxCurrFrom0);
            this.panelCurrencyFrom.Controls.Add(this.checkboxCurrFrom5);
            this.panelCurrencyFrom.Controls.Add(this.checkboxCurrFrom4);
            this.panelCurrencyFrom.Controls.Add(this.checkboxCurrFrom3);
            this.panelCurrencyFrom.Controls.Add(this.checkboxCurrFrom2);
            this.panelCurrencyFrom.Controls.Add(this.checkboxCurrFrom1);
            this.panelCurrencyFrom.Location = new System.Drawing.Point(332, 104);
            this.panelCurrencyFrom.Name = "panelCurrencyFrom";
            this.panelCurrencyFrom.Size = new System.Drawing.Size(154, 151);
            this.panelCurrencyFrom.TabIndex = 29;
            // 
            // panelCurrencyTo
            // 
            this.panelCurrencyTo.Controls.Add(this.checkboxCurrTo0);
            this.panelCurrencyTo.Controls.Add(this.checkboxCurrTo1);
            this.panelCurrencyTo.Controls.Add(this.checkboxCurrTo2);
            this.panelCurrencyTo.Controls.Add(this.checkboxCurrTo3);
            this.panelCurrencyTo.Controls.Add(this.checkboxCurrTo4);
            this.panelCurrencyTo.Controls.Add(this.checkboxCurrTo5);
            this.panelCurrencyTo.Location = new System.Drawing.Point(518, 104);
            this.panelCurrencyTo.Name = "panelCurrencyTo";
            this.panelCurrencyTo.Size = new System.Drawing.Size(153, 151);
            this.panelCurrencyTo.TabIndex = 30;
            // 
            // PanelCurrencyConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCurrencyTo);
            this.Controls.Add(this.panelCurrencyFrom);
            this.Controls.Add(this.numpad);
            this.Controls.Add(this.btnConvertCurrencies);
            this.Controls.Add(this.Wynik);
            this.Controls.Add(this.textboxCurrencyOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PanelCurrencyConverter";
            this.Size = new System.Drawing.Size(674, 357);
            this.panelCurrencyFrom.ResumeLayout(false);
            this.panelCurrencyFrom.PerformLayout();
            this.panelCurrencyTo.ResumeLayout(false);
            this.panelCurrencyTo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConvertCurrencies;
        private System.Windows.Forms.Label Wynik;
        private System.Windows.Forms.CheckBox checkboxCurrTo4;
        private System.Windows.Forms.CheckBox checkboxCurrTo3;
        private System.Windows.Forms.CheckBox checkboxCurrTo2;
        private System.Windows.Forms.CheckBox checkboxCurrTo1;
        private System.Windows.Forms.CheckBox checkboxCurrTo0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkboxCurrFrom5;
        private System.Windows.Forms.CheckBox checkboxCurrFrom4;
        private System.Windows.Forms.CheckBox checkboxCurrFrom3;
        private System.Windows.Forms.CheckBox checkboxCurrFrom2;
        private System.Windows.Forms.CheckBox checkboxCurrFrom1;
        private System.Windows.Forms.CheckBox checkboxCurrFrom0;
        public NumpadBasic numpad;
        public System.Windows.Forms.Panel panelCurrencyFrom;
        public System.Windows.Forms.CheckBox checkboxCurrTo5;
        public System.Windows.Forms.Panel panelCurrencyTo;
        public System.Windows.Forms.TextBox textboxCurrencyOutput;
    }
}
