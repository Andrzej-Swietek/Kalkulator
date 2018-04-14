namespace kalkulator.Panels
{
    partial class PanelFunctionDraw
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
            this.functionDrawerBox = new kalkulator.Panels.FunctionDrawerBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // functionDrawerBox
            // 
            this.functionDrawerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.functionDrawerBox.Location = new System.Drawing.Point(38, 22);
            this.functionDrawerBox.Name = "functionDrawerBox";
            this.functionDrawerBox.Size = new System.Drawing.Size(413, 323);
            this.functionDrawerBox.TabIndex = 0;
            // 
            // btnDraw
            // 
            this.btnDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDraw.Location = new System.Drawing.Point(480, 22);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(125, 42);
            this.btnDraw.TabIndex = 1;
            this.btnDraw.Text = "Rysuj";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // PanelFunctionDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.functionDrawerBox);
            this.Name = "PanelFunctionDraw";
            this.Size = new System.Drawing.Size(720, 380);
            this.ResumeLayout(false);

        }

        #endregion

        private FunctionDrawerBox functionDrawerBox;
        private System.Windows.Forms.Button btnDraw;
    }
}
