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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLayoutBasic = new System.Windows.Forms.Button();
            this.btnLayoutAdvanced = new System.Windows.Forms.Button();
            this.btnLayoutCurrency = new System.Windows.Forms.Button();
            this.btnLayoutMatrix = new System.Windows.Forms.Button();
            this.textboxValue = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.btnLayoutFunctionDraw = new System.Windows.Forms.Button();
            this.panelFunctionDraw = new kalkulator.Panels.PanelFunctionDraw();
            this.panelMatrix = new kalkulator.Panels.PanelMatrix();
            this.panelCurrencyConverter = new kalkulator.Panels.PanelCurrencyConverter();
            this.panelAdvanced = new kalkulator.Panels.PanelAdvanced();
            this.panelBasic = new kalkulator.Panels.PanelBasic();
            this.panelNubmerSystems = new System.Windows.Forms.Panel();
            this.radioNumSystem16 = new System.Windows.Forms.RadioButton();
            this.radioNumSystem10 = new System.Windows.Forms.RadioButton();
            this.radioNumSystem8 = new System.Windows.Forms.RadioButton();
            this.radioNumSystem2 = new System.Windows.Forms.RadioButton();
            this.panelNubmerSystems.SuspendLayout();
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
            // btnLayoutMatrix
            // 
            this.btnLayoutMatrix.Location = new System.Drawing.Point(522, 12);
            this.btnLayoutMatrix.Name = "btnLayoutMatrix";
            this.btnLayoutMatrix.Size = new System.Drawing.Size(164, 39);
            this.btnLayoutMatrix.TabIndex = 3;
            this.btnLayoutMatrix.Tag = "Macierze";
            this.btnLayoutMatrix.Text = "Mcierze";
            this.btnLayoutMatrix.UseVisualStyleBackColor = true;
            this.btnLayoutMatrix.Click += new System.EventHandler(this.button4_Click);
            // 
            // textboxValue
            // 
            this.textboxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textboxValue.Location = new System.Drawing.Point(13, 58);
            this.textboxValue.Name = "textboxValue";
            this.textboxValue.Size = new System.Drawing.Size(503, 40);
            this.textboxValue.TabIndex = 12;
            this.textboxValue.TextChanged += new System.EventHandler(this.textboxValue_TextChanged);
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
            // btnLayoutFunctionDraw
            // 
            this.btnLayoutFunctionDraw.Location = new System.Drawing.Point(692, 12);
            this.btnLayoutFunctionDraw.Name = "btnLayoutFunctionDraw";
            this.btnLayoutFunctionDraw.Size = new System.Drawing.Size(164, 39);
            this.btnLayoutFunctionDraw.TabIndex = 19;
            this.btnLayoutFunctionDraw.Text = "Funkcje";
            this.btnLayoutFunctionDraw.UseVisualStyleBackColor = true;
            this.btnLayoutFunctionDraw.Click += new System.EventHandler(this.btnLayoutFunctionDraw_Click);
            // 
            // panelFunctionDraw
            // 
            this.panelFunctionDraw.FunctionString = null;
            this.panelFunctionDraw.Location = new System.Drawing.Point(13, 104);
            this.panelFunctionDraw.Name = "panelFunctionDraw";
            this.panelFunctionDraw.Size = new System.Drawing.Size(777, 392);
            this.panelFunctionDraw.TabIndex = 21;
            // 
            // panelMatrix
            // 
            this.panelMatrix.Location = new System.Drawing.Point(13, 104);
            this.panelMatrix.Name = "panelMatrix";
            this.panelMatrix.Size = new System.Drawing.Size(843, 373);
            this.panelMatrix.TabIndex = 20;
            this.panelMatrix.Tag = "Wynik";
            // 
            // panelCurrencyConverter
            // 
            this.panelCurrencyConverter.Location = new System.Drawing.Point(12, 103);
            this.panelCurrencyConverter.Name = "panelCurrencyConverter";
            this.panelCurrencyConverter.Size = new System.Drawing.Size(674, 357);
            this.panelCurrencyConverter.TabIndex = 18;
            // 
            // panelAdvanced
            // 
            this.panelAdvanced.Location = new System.Drawing.Point(12, 103);
            this.panelAdvanced.Name = "panelAdvanced";
            this.panelAdvanced.Size = new System.Drawing.Size(694, 352);
            this.panelAdvanced.TabIndex = 17;
            // 
            // panelBasic
            // 
            this.panelBasic.Location = new System.Drawing.Point(12, 104);
            this.panelBasic.Name = "panelBasic";
            this.panelBasic.Size = new System.Drawing.Size(650, 345);
            this.panelBasic.TabIndex = 16;
            // 
            // panelNubmerSystems
            // 
            this.panelNubmerSystems.Controls.Add(this.radioNumSystem16);
            this.panelNubmerSystems.Controls.Add(this.radioNumSystem10);
            this.panelNubmerSystems.Controls.Add(this.radioNumSystem8);
            this.panelNubmerSystems.Controls.Add(this.radioNumSystem2);
            this.panelNubmerSystems.Location = new System.Drawing.Point(707, 58);
            this.panelNubmerSystems.Name = "panelNubmerSystems";
            this.panelNubmerSystems.Size = new System.Drawing.Size(149, 102);
            this.panelNubmerSystems.TabIndex = 22;
            // 
            // radioNumSystem16
            // 
            this.radioNumSystem16.AutoSize = true;
            this.radioNumSystem16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioNumSystem16.Location = new System.Drawing.Point(3, 72);
            this.radioNumSystem16.Name = "radioNumSystem16";
            this.radioNumSystem16.Size = new System.Drawing.Size(50, 20);
            this.radioNumSystem16.TabIndex = 3;
            this.radioNumSystem16.Tag = "16";
            this.radioNumSystem16.Text = "hex";
            this.radioNumSystem16.UseVisualStyleBackColor = true;
            this.radioNumSystem16.CheckedChanged += new System.EventHandler(this.radioNumberSystem_CheckedChanged);
            // 
            // radioNumSystem10
            // 
            this.radioNumSystem10.AutoSize = true;
            this.radioNumSystem10.Checked = true;
            this.radioNumSystem10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioNumSystem10.Location = new System.Drawing.Point(3, 49);
            this.radioNumSystem10.Name = "radioNumSystem10";
            this.radioNumSystem10.Size = new System.Drawing.Size(52, 20);
            this.radioNumSystem10.TabIndex = 2;
            this.radioNumSystem10.TabStop = true;
            this.radioNumSystem10.Tag = "10";
            this.radioNumSystem10.Text = "dec";
            this.radioNumSystem10.UseVisualStyleBackColor = true;
            this.radioNumSystem10.CheckedChanged += new System.EventHandler(this.radioNumberSystem_CheckedChanged);
            // 
            // radioNumSystem8
            // 
            this.radioNumSystem8.AutoSize = true;
            this.radioNumSystem8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioNumSystem8.Location = new System.Drawing.Point(3, 26);
            this.radioNumSystem8.Name = "radioNumSystem8";
            this.radioNumSystem8.Size = new System.Drawing.Size(47, 20);
            this.radioNumSystem8.TabIndex = 1;
            this.radioNumSystem8.Tag = "8";
            this.radioNumSystem8.Text = "oct";
            this.radioNumSystem8.UseVisualStyleBackColor = true;
            this.radioNumSystem8.CheckedChanged += new System.EventHandler(this.radioNumberSystem_CheckedChanged);
            // 
            // radioNumSystem2
            // 
            this.radioNumSystem2.AutoSize = true;
            this.radioNumSystem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioNumSystem2.Location = new System.Drawing.Point(3, 3);
            this.radioNumSystem2.Name = "radioNumSystem2";
            this.radioNumSystem2.Size = new System.Drawing.Size(47, 20);
            this.radioNumSystem2.TabIndex = 0;
            this.radioNumSystem2.Tag = "2";
            this.radioNumSystem2.Text = "bin";
            this.radioNumSystem2.UseVisualStyleBackColor = true;
            this.radioNumSystem2.CheckedChanged += new System.EventHandler(this.radioNumberSystem_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 520);
            this.Controls.Add(this.panelNubmerSystems);
            this.Controls.Add(this.panelBasic);
            this.Controls.Add(this.panelFunctionDraw);
            this.Controls.Add(this.panelMatrix);
            this.Controls.Add(this.btnLayoutFunctionDraw);
            this.Controls.Add(this.panelCurrencyConverter);
            this.Controls.Add(this.panelAdvanced);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.textboxValue);
            this.Controls.Add(this.btnLayoutMatrix);
            this.Controls.Add(this.btnLayoutCurrency);
            this.Controls.Add(this.btnLayoutAdvanced);
            this.Controls.Add(this.btnLayoutBasic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "KALKULATOR EXTREME";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panelNubmerSystems.ResumeLayout(false);
            this.panelNubmerSystems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLayoutBasic;
        private System.Windows.Forms.Button btnLayoutAdvanced;
        private System.Windows.Forms.Button btnLayoutCurrency;
        private System.Windows.Forms.Button btnLayoutMatrix;
        private System.Windows.Forms.TextBox textboxValue;
        private System.Windows.Forms.Button buttonClear;
        private Panels.PanelBasic panelBasic;
        private Panels.PanelAdvanced panelAdvanced;
        private Panels.PanelCurrencyConverter panelCurrencyConverter;
        private System.Windows.Forms.Button btnLayoutFunctionDraw;
        private Panels.PanelMatrix panelMatrix;
        private Panels.PanelFunctionDraw panelFunctionDraw;
        private System.Windows.Forms.Panel panelNubmerSystems;
        private System.Windows.Forms.RadioButton radioNumSystem16;
        private System.Windows.Forms.RadioButton radioNumSystem10;
        private System.Windows.Forms.RadioButton radioNumSystem8;
        private System.Windows.Forms.RadioButton radioNumSystem2;
    }
}

