namespace kalkulator
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLayoutBasic = new System.Windows.Forms.Button();
            this.btnLayoutAdvanced = new System.Windows.Forms.Button();
            this.btnLayoutCurrency = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textboxValue = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.panelBasic = new kalkulator.Panels.PanelBasic();
            this.panelAdvanced = new kalkulator.Panels.PanelAdvanced();
            this.panelCurrencyConverter = new kalkulator.Panels.PanelCurrencyConverter();
            this.button1 = new System.Windows.Forms.Button();
            this.panelMatrix = new kalkulator.Panels.PanelMatrix();
            this.SuspendLayout();
            // 
            // btnLayoutBasic
            // 
            this.btnLayoutBasic.Location = new System.Drawing.Point(12, 12);
            this.btnLayoutBasic.Name = "btnLayoutBasic";
            this.btnLayoutBasic.Size = new System.Drawing.Size(164, 39);
            this.btnLayoutBasic.TabIndex = 0;
            this.btnLayoutBasic.Text = "Podstawowy";
            this.btnLayoutBasic.UseVisualStyleBackColor = true;
            this.btnLayoutBasic.Click += new System.EventHandler(this.btnLayoutBasic_Click);
            // 
            // btnLayoutAdvanced
            // 
            this.btnLayoutAdvanced.Location = new System.Drawing.Point(182, 12);
            this.btnLayoutAdvanced.Name = "btnLayoutAdvanced";
            this.btnLayoutAdvanced.Size = new System.Drawing.Size(164, 39);
            this.btnLayoutAdvanced.TabIndex = 1;
            this.btnLayoutAdvanced.Text = "Zaawansowany";
            this.btnLayoutAdvanced.UseVisualStyleBackColor = true;
            this.btnLayoutAdvanced.Click += new System.EventHandler(this.btnLayoutAdvanced_Click);
            // 
            // btnLayoutCurrency
            // 
            this.btnLayoutCurrency.Location = new System.Drawing.Point(352, 12);
            this.btnLayoutCurrency.Name = "btnLayoutCurrency";
            this.btnLayoutCurrency.Size = new System.Drawing.Size(164, 39);
            this.btnLayoutCurrency.TabIndex = 2;
            this.btnLayoutCurrency.Text = "Przelicznik";
            this.btnLayoutCurrency.UseVisualStyleBackColor = true;
            this.btnLayoutCurrency.Click += new System.EventHandler(this.btnLayoutCurrency_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(522, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(164, 39);
            this.button4.TabIndex = 3;
            this.button4.Tag = "Macierze";
            this.button4.Text = "Mcierze";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textboxValue
            // 
            this.textboxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textboxValue.Location = new System.Drawing.Point(13, 58);
            this.textboxValue.Name = "textboxValue";
            this.textboxValue.Size = new System.Drawing.Size(503, 40);
            this.textboxValue.TabIndex = 12;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(522, 58);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(87, 39);
            this.buttonClear.TabIndex = 15;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // panelBasic
            // 
            this.panelBasic.Location = new System.Drawing.Point(13, 104);
            this.panelBasic.Name = "panelBasic";
            this.panelBasic.Size = new System.Drawing.Size(650, 345);
            this.panelBasic.TabIndex = 16;
            // 
            // panelAdvanced
            // 
            this.panelAdvanced.Location = new System.Drawing.Point(12, 103);
            this.panelAdvanced.Name = "panelAdvanced";
            this.panelAdvanced.Size = new System.Drawing.Size(694, 352);
            this.panelAdvanced.TabIndex = 17;
            // 
            // panelCurrencyConverter
            // 
            this.panelCurrencyConverter.Location = new System.Drawing.Point(12, 103);
            this.panelCurrencyConverter.Name = "panelCurrencyConverter";
            this.panelCurrencyConverter.Size = new System.Drawing.Size(674, 357);
            this.panelCurrencyConverter.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(692, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 39);
            this.button1.TabIndex = 19;
            this.button1.Text = "Inne";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panelMatrix
            // 
            this.panelMatrix.Location = new System.Drawing.Point(13, 104);
            this.panelMatrix.Name = "panelMatrix";
            this.panelMatrix.Size = new System.Drawing.Size(553, 373);
            this.panelMatrix.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 520);
            this.Controls.Add(this.panelMatrix);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelCurrencyConverter);
            this.Controls.Add(this.panelAdvanced);
            this.Controls.Add(this.panelBasic);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.textboxValue);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnLayoutCurrency);
            this.Controls.Add(this.btnLayoutAdvanced);
            this.Controls.Add(this.btnLayoutBasic);
            this.Name = "Form1";
            this.Text = "KALKULATOR EXTREME";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLayoutBasic;
        private System.Windows.Forms.Button btnLayoutAdvanced;
        private System.Windows.Forms.Button btnLayoutCurrency;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textboxValue;
        private System.Windows.Forms.Button buttonClear;
        private Panels.PanelBasic panelBasic;
        private Panels.PanelAdvanced panelAdvanced;
        private Panels.PanelCurrencyConverter panelCurrencyConverter;
        private System.Windows.Forms.Button button1;
        private Panels.PanelMatrix panelMatrix;
    }
}

