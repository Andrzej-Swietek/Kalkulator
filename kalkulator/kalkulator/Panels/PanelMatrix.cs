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
    public partial class PanelMatrix : UserControl
    {
        public string OperationMatrix;
        public float[][] matrixA;
        public float[][] matrixB;
        public float[][] matrixSolution;

        public PanelMatrix()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//A+B
        {
            OperationMatrix = "+";
        }

        private void button2_Click(object sender, EventArgs e)//A-B
        {
            OperationMatrix = "-";
        }

        private void button3_Click(object sender, EventArgs e)//A*B
        {
            OperationMatrix = "*";
        }

        private void button4_Click(object sender, EventArgs e)//skalar
        {
            OperationMatrix = "λ";
            textBoxLambda.Visible = true;
            label_X.Visible = true;
            label2.Visible = false;
            label_Wynik.Visible = true;
            label_Wynik.Visible = true;
            //ustawić razy i textboxa visible na true
        }

        private void button5_Click(object sender, EventArgs e) //T[]
        {
            OperationMatrix = "T";
            label2.Visible = false; // ta z textem macierz B
            label_Wynik.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e) //odwrotna
        {
            OperationMatrix = "Odw";
            label2.Visible = false; // ta z textem macierz B
            label_Wynik.Visible = true;
            label_Wynik.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OperationMatrix = "Diag";
            label2.Visible = false; // ta z textem macierz B
            label_Wynik.Visible = true;
        }
        /*----------------------- EVALUATE MATRIX ----------------------------*/
        private void button6_Click(object sender, EventArgs e)
        {


            //zczytaj z textboxow na pozniej do zrobienia - upchaj do tablic lub wektora [][]
            // !!!!!!!!!!!!!! UWAGA DOPISZ WYNIKI DO TEXTBOXOW !!!!!!!!!!!!!!!!!!!!!!!!!!


            switch(OperationMatrix)
            {
                case ("+"):

                    
                     for(int i=0;i<4;i++)
                     {
                            for (int j=0;j<4;j++)
                            {
                               matrixSolution[i][j] =   matrixA[i][j] + matrixB[i][j];
                            }
                     }
                     
                     /*



                    //Pierwszy wers
                    matrixSolution[0][0] =  matrixA[0][0] + matrixB[0][0];
                    matrixSolution[0][1] = matrixA[0][1] + matrixB[0][1];
                    matrixSolution[0][2] = matrixA[0][2] + matrixB[0][2];
                    matrixSolution[0][3] = matrixA[0][3] + matrixB[0][3];

                    // Drugi wers
                    matrixA[1][0] + matrixB[1][0];
                    matrixA[1][1] + matrixB[1][1];
                    matrixA[1][2] + matrixB[1][2];
                    matrixA[1][3] + matrixB[1][3];

                    //Trzeci Wers
                    matrixA[2][0] + matrixB[2][0];
                    matrixA[2][1] + matrixB[2][1];
                    matrixA[2][2] + matrixB[2][2];
                    matrixA[2][3] + matrixB[2][3];

                    //Czwarty wers

                    matrixA[3][0] + matrixB[3][0];
                    matrixA[3][1] + matrixB[3][1];
                    matrixA[3][2] + matrixB[3][2];
                    matrixA[3][3] + matrixB[3][3];
                    */
                    break;


                case ("-"):
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            matrixSolution[i][j] = matrixA[i][j] - matrixB[i][j];
                        }
                    }

                    break;


                case ("*"):
                    for(int i=0;i<4;i++) //for kolumny
                    {

                            for(int j=0;j<4;j++)// wiersze
                        {
                           // matrixSolution[i][j] = matrixA[i][j] * matrixB[i][j] + (matrixA[i][j+1] * matrixB[i+1][j]) + (matrixA[i][] * matrixB[][]) + matrixA[i][] * matrixB[][];
                        }
                             




                    }



                    break;














            }







        }
    }
}
