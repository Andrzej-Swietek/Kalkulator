namespace kalkulator.Panels
{
    partial class PanelMatrix
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

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.macierzA = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox00a = new System.Windows.Forms.TextBox();
            this.textBox01a = new System.Windows.Forms.TextBox();
            this.textBox02a = new System.Windows.Forms.TextBox();
            this.textBox03a = new System.Windows.Forms.TextBox();
            this.textBox10a = new System.Windows.Forms.TextBox();
            this.textBox11a = new System.Windows.Forms.TextBox();
            this.textBox12a = new System.Windows.Forms.TextBox();
            this.textBox13a = new System.Windows.Forms.TextBox();
            this.textBox20a = new System.Windows.Forms.TextBox();
            this.textBox21a = new System.Windows.Forms.TextBox();
            this.textBox22a = new System.Windows.Forms.TextBox();
            this.textBox23a = new System.Windows.Forms.TextBox();
            this.textBox30a = new System.Windows.Forms.TextBox();
            this.textBox31a = new System.Windows.Forms.TextBox();
            this.textBox32a = new System.Windows.Forms.TextBox();
            this.textBox33a = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label_X = new System.Windows.Forms.Label();
            this.textBoxLambda = new System.Windows.Forms.TextBox();
            this.label_Wynik = new System.Windows.Forms.Label();
            this.macierzA.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Dodawanie";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "Odejmowanie";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 117);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 38);
            this.button3.TabIndex = 2;
            this.button3.Text = "Mnożenie";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(16, 161);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 38);
            this.button4.TabIndex = 3;
            this.button4.Text = "Skalar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox1.Location = new System.Drawing.Point(14, 333);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(138, 29);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Tag = "Det";
            this.checkBox1.Text = "Wyznacznik";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(17, 201);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(134, 38);
            this.button5.TabIndex = 7;
            this.button5.Text = "Macierz Transponowana";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // macierzA
            // 
            this.macierzA.Controls.Add(this.textBox00a);
            this.macierzA.Controls.Add(this.textBox01a);
            this.macierzA.Controls.Add(this.textBox02a);
            this.macierzA.Controls.Add(this.textBox03a);
            this.macierzA.Controls.Add(this.textBox10a);
            this.macierzA.Controls.Add(this.textBox11a);
            this.macierzA.Controls.Add(this.textBox12a);
            this.macierzA.Controls.Add(this.textBox13a);
            this.macierzA.Controls.Add(this.textBox20a);
            this.macierzA.Controls.Add(this.textBox21a);
            this.macierzA.Controls.Add(this.textBox22a);
            this.macierzA.Controls.Add(this.textBox23a);
            this.macierzA.Controls.Add(this.textBox30a);
            this.macierzA.Controls.Add(this.textBox31a);
            this.macierzA.Controls.Add(this.textBox32a);
            this.macierzA.Controls.Add(this.textBox33a);
            this.macierzA.Location = new System.Drawing.Point(189, 46);
            this.macierzA.Name = "macierzA";
            this.macierzA.Size = new System.Drawing.Size(220, 104);
            this.macierzA.TabIndex = 8;
            this.macierzA.Tag = "A";
            // 
            // textBox00a
            // 
            this.textBox00a.Location = new System.Drawing.Point(3, 3);
            this.textBox00a.Name = "textBox00a";
            this.textBox00a.Size = new System.Drawing.Size(47, 20);
            this.textBox00a.TabIndex = 0;
            this.textBox00a.Tag = "00";
            // 
            // textBox01a
            // 
            this.textBox01a.Location = new System.Drawing.Point(56, 3);
            this.textBox01a.Name = "textBox01a";
            this.textBox01a.Size = new System.Drawing.Size(47, 20);
            this.textBox01a.TabIndex = 1;
            this.textBox01a.Tag = "01";
            // 
            // textBox02a
            // 
            this.textBox02a.Location = new System.Drawing.Point(109, 3);
            this.textBox02a.Name = "textBox02a";
            this.textBox02a.Size = new System.Drawing.Size(47, 20);
            this.textBox02a.TabIndex = 2;
            this.textBox02a.Tag = "02";
            // 
            // textBox03a
            // 
            this.textBox03a.Location = new System.Drawing.Point(162, 3);
            this.textBox03a.Name = "textBox03a";
            this.textBox03a.Size = new System.Drawing.Size(47, 20);
            this.textBox03a.TabIndex = 3;
            this.textBox03a.Tag = "03";
            // 
            // textBox10a
            // 
            this.textBox10a.Location = new System.Drawing.Point(3, 29);
            this.textBox10a.Name = "textBox10a";
            this.textBox10a.Size = new System.Drawing.Size(47, 20);
            this.textBox10a.TabIndex = 4;
            this.textBox10a.Tag = "10";
            // 
            // textBox11a
            // 
            this.textBox11a.Location = new System.Drawing.Point(56, 29);
            this.textBox11a.Name = "textBox11a";
            this.textBox11a.Size = new System.Drawing.Size(47, 20);
            this.textBox11a.TabIndex = 5;
            this.textBox11a.Tag = "11";
            // 
            // textBox12a
            // 
            this.textBox12a.Location = new System.Drawing.Point(109, 29);
            this.textBox12a.Name = "textBox12a";
            this.textBox12a.Size = new System.Drawing.Size(47, 20);
            this.textBox12a.TabIndex = 6;
            this.textBox12a.Tag = "12";
            // 
            // textBox13a
            // 
            this.textBox13a.Location = new System.Drawing.Point(162, 29);
            this.textBox13a.Name = "textBox13a";
            this.textBox13a.Size = new System.Drawing.Size(47, 20);
            this.textBox13a.TabIndex = 7;
            this.textBox13a.Tag = "13";
            // 
            // textBox20a
            // 
            this.textBox20a.Location = new System.Drawing.Point(3, 55);
            this.textBox20a.Name = "textBox20a";
            this.textBox20a.Size = new System.Drawing.Size(47, 20);
            this.textBox20a.TabIndex = 8;
            this.textBox20a.Tag = "20";
            // 
            // textBox21a
            // 
            this.textBox21a.Location = new System.Drawing.Point(56, 55);
            this.textBox21a.Name = "textBox21a";
            this.textBox21a.Size = new System.Drawing.Size(47, 20);
            this.textBox21a.TabIndex = 9;
            this.textBox21a.Tag = "21";
            // 
            // textBox22a
            // 
            this.textBox22a.Location = new System.Drawing.Point(109, 55);
            this.textBox22a.Name = "textBox22a";
            this.textBox22a.Size = new System.Drawing.Size(47, 20);
            this.textBox22a.TabIndex = 10;
            this.textBox22a.Tag = "22";
            // 
            // textBox23a
            // 
            this.textBox23a.Location = new System.Drawing.Point(162, 55);
            this.textBox23a.Name = "textBox23a";
            this.textBox23a.Size = new System.Drawing.Size(47, 20);
            this.textBox23a.TabIndex = 11;
            this.textBox23a.Tag = "23";
            // 
            // textBox30a
            // 
            this.textBox30a.Location = new System.Drawing.Point(3, 81);
            this.textBox30a.Name = "textBox30a";
            this.textBox30a.Size = new System.Drawing.Size(47, 20);
            this.textBox30a.TabIndex = 12;
            this.textBox30a.Tag = "30";
            // 
            // textBox31a
            // 
            this.textBox31a.Location = new System.Drawing.Point(56, 81);
            this.textBox31a.Name = "textBox31a";
            this.textBox31a.Size = new System.Drawing.Size(47, 20);
            this.textBox31a.TabIndex = 13;
            this.textBox31a.Tag = "31";
            // 
            // textBox32a
            // 
            this.textBox32a.Location = new System.Drawing.Point(109, 81);
            this.textBox32a.Name = "textBox32a";
            this.textBox32a.Size = new System.Drawing.Size(47, 20);
            this.textBox32a.TabIndex = 14;
            this.textBox32a.Tag = "32";
            // 
            // textBox33a
            // 
            this.textBox33a.Location = new System.Drawing.Point(162, 81);
            this.textBox33a.Name = "textBox33a";
            this.textBox33a.Size = new System.Drawing.Size(47, 20);
            this.textBox33a.TabIndex = 15;
            this.textBox33a.Tag = "33";
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button6.Location = new System.Drawing.Point(412, 155);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(126, 58);
            this.button6.TabIndex = 10;
            this.button6.Text = "Przelicz";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.textBox17);
            this.flowLayoutPanel2.Controls.Add(this.textBox18);
            this.flowLayoutPanel2.Controls.Add(this.textBox19);
            this.flowLayoutPanel2.Controls.Add(this.textBox20);
            this.flowLayoutPanel2.Controls.Add(this.textBox21);
            this.flowLayoutPanel2.Controls.Add(this.textBox22);
            this.flowLayoutPanel2.Controls.Add(this.textBox23);
            this.flowLayoutPanel2.Controls.Add(this.textBox24);
            this.flowLayoutPanel2.Controls.Add(this.textBox25);
            this.flowLayoutPanel2.Controls.Add(this.textBox26);
            this.flowLayoutPanel2.Controls.Add(this.textBox27);
            this.flowLayoutPanel2.Controls.Add(this.textBox28);
            this.flowLayoutPanel2.Controls.Add(this.textBox29);
            this.flowLayoutPanel2.Controls.Add(this.textBox30);
            this.flowLayoutPanel2.Controls.Add(this.textBox31);
            this.flowLayoutPanel2.Controls.Add(this.textBox32);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(189, 216);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(220, 104);
            this.flowLayoutPanel2.TabIndex = 11;
            this.flowLayoutPanel2.Tag = "B";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(3, 3);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(47, 20);
            this.textBox17.TabIndex = 0;
            this.textBox17.Tag = "00b";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(56, 3);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(47, 20);
            this.textBox18.TabIndex = 1;
            this.textBox18.Tag = "01b";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(109, 3);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(47, 20);
            this.textBox19.TabIndex = 2;
            this.textBox19.Tag = "02b";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(162, 3);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(47, 20);
            this.textBox20.TabIndex = 3;
            this.textBox20.Tag = "03b";
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(3, 29);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(47, 20);
            this.textBox21.TabIndex = 4;
            this.textBox21.Tag = "10b";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(56, 29);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(47, 20);
            this.textBox22.TabIndex = 5;
            this.textBox22.Tag = "11b";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(109, 29);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(47, 20);
            this.textBox23.TabIndex = 6;
            this.textBox23.Tag = "12b";
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(162, 29);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(47, 20);
            this.textBox24.TabIndex = 7;
            this.textBox24.Tag = "13b";
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(3, 55);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(47, 20);
            this.textBox25.TabIndex = 8;
            this.textBox25.Tag = "20b";
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(56, 55);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(47, 20);
            this.textBox26.TabIndex = 9;
            this.textBox26.Tag = "21b";
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(109, 55);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(47, 20);
            this.textBox27.TabIndex = 10;
            this.textBox27.Tag = "22b";
            // 
            // textBox28
            // 
            this.textBox28.Location = new System.Drawing.Point(162, 55);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(47, 20);
            this.textBox28.TabIndex = 11;
            this.textBox28.Tag = "23b";
            // 
            // textBox29
            // 
            this.textBox29.Location = new System.Drawing.Point(3, 81);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(47, 20);
            this.textBox29.TabIndex = 12;
            this.textBox29.Tag = "30b";
            // 
            // textBox30
            // 
            this.textBox30.Location = new System.Drawing.Point(56, 81);
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new System.Drawing.Size(47, 20);
            this.textBox30.TabIndex = 13;
            this.textBox30.Tag = "31b";
            // 
            // textBox31
            // 
            this.textBox31.Location = new System.Drawing.Point(109, 81);
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new System.Drawing.Size(47, 20);
            this.textBox31.TabIndex = 14;
            this.textBox31.Tag = "32b";
            // 
            // textBox32
            // 
            this.textBox32.Location = new System.Drawing.Point(162, 81);
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(47, 20);
            this.textBox32.TabIndex = 15;
            this.textBox32.Tag = "33b";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(240, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Macierz A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(240, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Macierz B";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(17, 245);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(134, 38);
            this.button7.TabIndex = 14;
            this.button7.Text = "Macierz Odwrotna";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(18, 289);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(134, 38);
            this.button8.TabIndex = 15;
            this.button8.Text = "Macierz Diagonalna";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label_X
            // 
            this.label_X.AutoSize = true;
            this.label_X.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_X.Location = new System.Drawing.Point(415, 88);
            this.label_X.Name = "label_X";
            this.label_X.Size = new System.Drawing.Size(26, 25);
            this.label_X.TabIndex = 16;
            this.label_X.Tag = "razy";
            this.label_X.Text = "X";
            this.label_X.Visible = false;
            // 
            // textBoxLambda
            // 
            this.textBoxLambda.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxLambda.Location = new System.Drawing.Point(447, 83);
            this.textBoxLambda.Name = "textBoxLambda";
            this.textBoxLambda.Size = new System.Drawing.Size(64, 38);
            this.textBoxLambda.TabIndex = 17;
            this.textBoxLambda.Tag = "lambda";
            this.textBoxLambda.Visible = false;
            // 
            // label_Wynik
            // 
            this.label_Wynik.AutoSize = true;
            this.label_Wynik.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Wynik.Location = new System.Drawing.Point(187, 188);
            this.label_Wynik.Name = "label_Wynik";
            this.label_Wynik.Size = new System.Drawing.Size(82, 25);
            this.label_Wynik.TabIndex = 18;
            this.label_Wynik.Text = "Wynik";
            this.label_Wynik.Visible = false;
            // 
            // PanelMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_Wynik);
            this.Controls.Add(this.textBoxLambda);
            this.Controls.Add(this.label_X);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.macierzA);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "PanelMatrix";
            this.Size = new System.Drawing.Size(553, 373);
            this.macierzA.ResumeLayout(false);
            this.macierzA.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.FlowLayoutPanel macierzA;
        private System.Windows.Forms.TextBox textBox00a;
        private System.Windows.Forms.TextBox textBox01a;
        private System.Windows.Forms.TextBox textBox02a;
        private System.Windows.Forms.TextBox textBox03a;
        private System.Windows.Forms.TextBox textBox10a;
        private System.Windows.Forms.TextBox textBox11a;
        private System.Windows.Forms.TextBox textBox12a;
        private System.Windows.Forms.TextBox textBox13a;
        private System.Windows.Forms.TextBox textBox20a;
        private System.Windows.Forms.TextBox textBox21a;
        private System.Windows.Forms.TextBox textBox22a;
        private System.Windows.Forms.TextBox textBox23a;
        private System.Windows.Forms.TextBox textBox30a;
        private System.Windows.Forms.TextBox textBox31a;
        private System.Windows.Forms.TextBox textBox32a;
        private System.Windows.Forms.TextBox textBox33a;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.TextBox textBox27;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.TextBox textBox29;
        private System.Windows.Forms.TextBox textBox30;
        private System.Windows.Forms.TextBox textBox31;
        private System.Windows.Forms.TextBox textBox32;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label_X;
        private System.Windows.Forms.TextBox textBoxLambda;
        private System.Windows.Forms.Label label_Wynik;
    }
}
