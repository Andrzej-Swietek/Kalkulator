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
        double det;
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
            matrixA = new double[4, 4];
            matrixB = new double[4, 4];
            matrixSolution = new double[4, 4];

            foreach (var t in macierzA.Controls.OfType<TextBox>())//wczytywanie
            {
                int x = int.Parse(((string)t.Tag).Substring(0, 1));
                int y = int.Parse(((string)t.Tag).Substring(1, 1));
                matrixA[x, y] = double.Parse(t.Text);
            }


            if(checkBox1.Checked ==true)
            {
                det =   1 * matrixA[0,0] * ((matrixA[1,1] * matrixA[2,2] * matrixA[3,3]) + (matrixA[1,2] * matrixA[2,3] * matrixA[3,1]) + (matrixA[1,3] * matrixA[2,1] * matrixA[3,2]) - (matrixA[3,1] * matrixA[2,2] * matrixA[1,3]) - (matrixA[3,2] * matrixA[2,3] * matrixA[1,1]) - (matrixA[3,3] * matrixA[2,1] * matrixA[1,2])) +
                               (-1) * matrixA[1,0] * ((matrixA[0,1] * matrixA[2,2] * matrixA[3,3]) + (matrixA[0,2] * matrixA[2,3] * matrixA[3,1]) + (matrixA[0,3] * matrixA[2,1] * matrixA[3,2]) - (matrixA[3,1] * matrixA[2,2] * matrixA[0,3]) - (matrixA[3,2] * matrixA[2,3] * matrixA[0,1]) -  (matrixA[2,1] * matrixA[0,2] * matrixA[3,3])) +
                                1*matrixA[2,0] * (  (matrixA[0,1] * matrixA[1,2] * matrixA[3,3]) + (matrixA[0,2] * matrixA[1,3] * matrixA[3,1]) + (matrixA[0,3] * matrixA[1,1] * matrixA[3,2]) - (matrixA[0,3] * matrixA[1,2] * matrixA[3,1]) - (matrixA[3,2] * matrixA[1,3] * matrixA[0,1]) -  (matrixA[3,3] * matrixA[1,1] * matrixA[0,2]))  +
                                (-1) * matrixA[3,0] * ((matrixA[0,1] * matrixA[1,2] * matrixA[2,3]) + (matrixA[0,2] * matrixA[1,3] * matrixA[2,1]) + (matrixA[0,3] * matrixA[1,1] * matrixA[2,2]) - (matrixA[2,1] * matrixA[1,2] * matrixA[0,3]) - (matrixA[2,2] * matrixA[1,3] * matrixA[0,1]) -  (matrixA[2,3] * matrixA[1,1] * matrixA[1,2]));


if (det == 0)
    {
            det = (matrixA[0,0] * matrixA[1,1] * matrixA[2,2]) + (matrixA[0,1] * matrixA[1,2] * matrixA[2,0]) + (matrixA[0,2] * matrixA[1,0] * matrixA[2,1]) - (matrixA[2,0] * matrixA[1,1] * matrixA[0,2]) - (matrixA[2,1] * matrixA[1,2] * matrixA[0,0]) - (matrixA[2,2] * matrixA[1,0] * matrixA[0,1]);

        if (det==0)
            {
              det = matrixA[0,0] * matrixA[1,1] - matrixA[1,0] * matrixA[0,1];

                    if(det==0)
                    {
                        det= matrixA[0,0];
                       
                        
                    }
            }
    }
            }// wyznacznik




            switch (OperationMatrix)
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
                    valueLambda = double.Parse(textBoxLambda.Text);//zmiana
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



                case ("Diag"):
                    for (int i = 0; i <4 ; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            matrixSolution[i, j] = 1 / matrixA[i,j];
                        }
                    }
                    break;

                case ("Odw"):

                    break;

            }


            foreach (var t in macierzWynik.Controls.OfType<TextBox>())//wyswietlanie
            {
                int x = int.Parse(((string)t.Tag).Substring(0, 1));
                int y = int.Parse(((string)t.Tag).Substring(1, 1));
                t.Text = matrixSolution[x, y].ToString();
            }

        }
    }
}
