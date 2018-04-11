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
        public double[,] matrixA;
        public double[,] matrixB;
        public double[,] matrixSolution;
        public double valueLambda = 0;
        int size = 4;
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
            valueLambda = double.Parse(textBoxLambda.Text);//zmiana
            
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
                               matrixSolution[i,j] =   matrixA[i,j] + matrixB[i,j];
                            }
                     }
                     break;


                case ("-"):
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            matrixSolution[i,j] = matrixA[i,j] - matrixB[i,j];
                        }
                    }

                    break;


                case ("*"):
                    for (int i = 0; i < 4; i++) //for kolumny
                    {

                        for (int j = 0; j < 4; j++)// wiersze
                        {
                            matrixSolution[i, j] = 0;
                            for (int k = 0; k < 4; k++)
                            {
                                matrixSolution[i, j] += matrixA[k, i] * matrixB[j, k];
                            }
                            // matrixSolution[i][j] = matrixA[i][j] * matrixB[i][j] + (matrixA[i][j+1] * matrixB[i+1][j]) + (matrixA[i][] * matrixB[][]) + matrixA[i][] * matrixB[][];
                        }
                    }        
                    break;



                case ("λ"):
                    for (int i=0;i<4;i++)
                    {
                        for(int j=0;j<4;j++)
                        {
                            matrixSolution[i,j] = matrixA[i,j] * valueLambda;
                        }
                    }
                    break;

                case ("T"):
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            double tmp = matrixA[i, j];
                            matrixSolution[j, i] = tmp;
                        }

                    }
                    break;


                    














            }







        }
    }
}
