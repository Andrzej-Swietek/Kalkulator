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

            foreach (var t in macierzA.Controls.OfType<TextBox>())//wczytywanie A
            {
                int x = int.Parse(((string)t.Tag).Substring(0, 1));
                int y = int.Parse(((string)t.Tag).Substring(1, 1));
                matrixA[x,y] = string.IsNullOrWhiteSpace(t.Text) ? 0 : new Calcualtion(t.Text).CalculateNew();
            }


            foreach (var t in macierzB.Controls.OfType<TextBox>())//wczytywanie B
            {
                int x = int.Parse(((string)t.Tag).Substring(0, 1));
                int y = int.Parse(((string)t.Tag).Substring(1, 1));
                matrixB[x, y] = string.IsNullOrWhiteSpace(t.Text) ? 0 : new Calcualtion(t.Text).CalculateNew();
            }


            if (checkBox1.Checked ==true || OperationMatrix =="Obw")
            {
                textBoxDet.Visible = true;
                labelDet.Visible = true;
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

                textBoxDet.Text += " det = ";
                textBoxDet.Text += det.ToString();  //wyswietlanie wyznacznika
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

                    //wers 1
                    matrixSolution[0, 0] = matrixA[1, 1] * matrixA[2,2] * matrixA[3,3] + matrixA[1,2] * matrixA[2,3] * matrixA[3,1] + matrixA[1,3] * matrixA[2,1] * matrixA[3,2] - matrixA[1,1] * matrixA[2,3] * matrixA[3,2] - matrixA[1,2] * matrixA[2,1] * matrixA[3,3] - matrixA[1,3] * matrixA[2,2] * matrixA[3,1];
                    // matrixSolution[0,0]= matrixA[1,1] * matrixA[2,2] * matrixA[3,3] + matrixA[1,2] * matrixA[2,3] * matrixA[3,1] + matrixA[1,3] * matrixA[2,1] * matrixA[3,2] - matrixA[1,1] * matrixA[2,3] * matrixA[3,2] − matrixA[1,2] * matrixA[2,1] * matrixA[3,3] − matrixA[1,3] * matrixA[2,2] * matrixA[3,1];
                    //a22a33a44                                                         +a23a34a42                                  +a24a32a43                                  −a22a34a43                                      −a23a32a44                                  −a24a33a42
                    // matrixSolution[0,1] = matrixA[0,1] * matrixA[2,3] * matrixA[3,2] + matrixA[0,2] * matrixA[2,1] * matrixA[3,3] + matrixA[0,3] * matrixA[2,2] * matrixA[3,1] − matrixA[0,1] * matrixA[2,2] * matrixA[3,3] − matrixA[0,2] * matrixA[2,3] * matrixA[3,1] − matrixA[0,3] * matrixA[2,1] * matrixA[3,2];
                    matrixSolution[0, 1] = matrixA[0, 1] * matrixA[2,3] * matrixA[3,2] + matrixA[0,2] * matrixA[2,1] * matrixA[3,3] + matrixA[0,3] * matrixA[2,2] * matrixA[3,1] - matrixA[0,1] * matrixA[2,2] * matrixA[3,3] - matrixA[0,2] * matrixA[2,3] * matrixA[2,0] - matrixA[0,3] * matrixA[2,1] * matrixA[3,2];
                    //a12a34a43                                                         +a13a32a44                                      +a14a33a42                                  −a12a33a44                                  −a13a34a42                                      -a14a32a43
                    //matrixSolution[0,2] = matrixA[0,1] * matrixA[1,2] * matrixA[3,3] + matrixA[0,2] * matrixA[1,3] * matrixA[3,1] + matrixA[0,3] * matrixA[1,1] * matrixA[3,2] − matrixA[0,1] * matrixA[1,3] * matrixA[3,2] − matrixA[0,2] * matrixA[2,2] * matrixA[3,3] − matrixA[0,3] * matrixA[1,2] * matrixA[3,1];
                    matrixSolution[0, 2] = matrixA[0, 1] * matrixA[1,2] * matrixA[3,3] + matrixA[0,2] * matrixA[1,3] * matrixA[3,1] + matrixA[0,3] * matrixA[1,1] * matrixA[3,2] - matrixA[0,1] * matrixA[1,3] * matrixA[3,2] - matrixA[0,2] * matrixA[2,2] * matrixA[3,3] - matrixA[0,3] * matrixA[1,2] * matrixA[3,1];
                    // a12a23a44                                                        +a13a24a42                                    +a14a22a43                                    −a12a24a43                                  −a13a22a44                                  −a14a23a42
                    //matrixSolution[0, 3] = matrixA[0,1] * matrixA[1,3] * matrixA[2,2] + matrixA[0,2] * matrixA[1,1] * matrixA[2,3] + matrixA[0,3] * matrixA[1,2] * matrixA[2,1] − matrixA[0,1] * matrixA[1,2] * matrixA[2,3] − matrixA[0,2] * matrixA[1,3] * matrixA[2,1] − matrixA[0,3] * matrixA[1,1] * matrixA[2,2];
                    matrixSolution[0, 3] = matrixA[0, 1] * matrixA[1,3] * matrixA[2,2] + matrixA[0,2] * matrixA[1,1] * matrixA[2,3] + matrixA[0,3] * matrixA[1,2] * matrixA[2,1] - matrixA[0,1] * matrixA[1,2] * matrixA[2,3] - matrixA[0,2] * matrixA[1,3] * matrixA[2,1] - matrixA[0,3] * matrixA[1,1] * matrixA[2,2];
                    //a12a24a33                                                         +a13a22a34                                      +a14a23a32                                  −a12a23a34                                  −a13a24a32                                  −a14a22a33

                    //wers 2
                    matrixSolution[1,0]= matrixA[1,0] * matrixA[2,3] * matrixA[3,2] + matrixA[1,2] * matrixA[2,0] * matrixA[3,3] + matrixA[1,3] * matrixA[2,2] * matrixA[3,0] - matrixA[1,0] * matrixA[2,2] * matrixA[3,3] - matrixA[1,2] * matrixA[2,3] * matrixA[3,0] - matrixA[1,3] * matrixA[2,0] * matrixA[3,2];

                    //                          a21             a34             a43  +      a23             a31          a44          +a24           a33                a41    |||      −a21        a33         a44           −      a23           a34          a41             −a24            a31             a43

                    matrixSolution[1,1]= matrixA[0,0] * matrixA[2,2] * matrixA[3,3] + matrixA[0,2] * matrixA[2,3] * matrixA[3,0] + matrixA[0,3] * matrixA[2,0] * matrixA[3,2] - matrixA[0,0] * matrixA[2,3] * matrixA[3,2] - matrixA[0,2] * matrixA[2,0] * matrixA[3,3] - matrixA[0,3] * matrixA[2,2] * matrixA[3,0];
                    //                          a11             a33             a44     +   a13              a34           a41  +       a14           a31               a43    |||      −a11        a34         a43         −        a13            a31         a44             −a14            a33             a41

                    matrixSolution[1,2]= matrixA[0,0] * matrixA[1,3] * matrixA[3,2] + matrixA[0,2] * matrixA[1,0] * matrixA[3,3] + matrixA[0,3] * matrixA[1,2] * matrixA[3,0] - matrixA[0,0] * matrixA[1,2] * matrixA[3,3] - matrixA[0,2] * matrixA[1,3] * matrixA[3,0] - matrixA[0,3] * matrixA[1,0] * matrixA[3,2];
                    //                          a11             a24             a43     +   a13             a21             a44 +       a14             a23             a41    |||      −a11        a23         a44         −       a13             a24         a41             −a14            a21             a43

                    matrixSolution[1,3]= matrixA[0,0] * matrixA[1,2] * matrixA[2,3] + matrixA[0,2] * matrixA[1,3] * matrixA[2,0] + matrixA[0,3] * matrixA[1,0] * matrixA[2,2] - matrixA[0,0] * matrixA[1,3] * matrixA[2,2] - matrixA[0,2] * matrixA[1,0] * matrixA[2,3] - matrixA[0,3] * matrixA[1,2] * matrixA[2,0];

                    //wers 3
                    matrixSolution[2, 0] = matrixA[1,0] * matrixA[2,1] * matrixA[3,3] + matrixA[1,1] * matrixA[2,3] * matrixA[3,0] + matrixA[1,3] * matrixA[2,0] * matrixA[3,1] - matrixA[1,0] * matrixA[2,3] * matrixA[3,1] - matrixA[1,1] * matrixA[2,0] * matrixA[2,2] - (matrixA[1,3] * matrixA[2,1] * matrixA[3,0]);
                    //a21a32a44                                                         +a22a34a41                                  +a24a31a42                                  −a21a34a42                                      −a22a31a44                                  −a24a32a41                                                                                                                                                                                                      
                    matrixSolution[2, 1] = matrixA[0,0] * matrixA[2,3] * matrixA[3,1] + matrixA[0,1] * matrixA[2,0] * matrixA[3,3] + matrixA[0,3] * matrixA[2,1] * matrixA[3,0] - matrixA[0,0] * matrixA[2,1] * matrixA[3,3] - matrixA[0,1] * matrixA[2,3] * matrixA[3,0] - matrixA[0,3] * matrixA[2,0] * matrixA[3,1];
                    // a11a34a42                                                    +a12a31a44                                      +a14a32a41                                                  −a11a32a44                                  −a12a34a41                          −a14a31a42
                    matrixSolution[2, 2] = matrixA[0, 0] * matrixA[1,1] * matrixA[3,3] + matrixA[0,1] * matrixA[1,3] * matrixA[3,0] + matrixA[0,3] * matrixA[1,0] * matrixA[3,1] - matrixA[0,0] * matrixA[1,3] * matrixA[3,1] - matrixA[0,1] * matrixA[1,0] * matrixA[3,3] - matrixA[0,3] * matrixA[1,1] * matrixA[3,0];
                    // a11a22a44                                                        +a12a24a41                                  +a14a21a42                                      −a11a24a42                                  −a12a21a44                                  −a14a22a41
                    matrixSolution[2, 3] = matrixA[0, 0] * matrixA[1,3] * matrixA[2,1] + matrixA[0,1] * matrixA[1,0] * matrixA[2,3] + matrixA[0,3] * matrixA[1,1] * matrixA[2,0] - matrixA[0,0] * matrixA[1,1] * matrixA[2,3] - matrixA[0,1] * matrixA[1,3] * matrixA[2,0] - matrixA[0,3] * matrixA[1,0] * matrixA[2,1];
                    //a11a24a32                                                         +a12a21a34                                  +a14a22a31                                      −a11a22a34                                  −a12a24a31                                  −a14a21a32

                    // wers 4
                    matrixSolution[3, 0] = matrixA[1, 0] * matrixA[2,2] * matrixA[3,1] + matrixA[1,1] * matrixA[2,0] * matrixA[3,2] + matrixA[1,2] * matrixA[2,1] * matrixA[3,0] - matrixA[1,0] * matrixA[2,1] * matrixA[3,2] - matrixA[1,1] * matrixA[2,2] * matrixA[3,0] - matrixA[1,2] * matrixA[2,0] * matrixA[3,1];
                    //a21a33a42                                                         +a22a31a43                                  +a23a32a41                                      −a21a32a43                                  −a22a33a41                                  −a23a31a42
                    matrixSolution[3, 1] = matrixA[0, 0] * matrixA[2,1] * matrixA[3,2] + matrixA[0,1] * matrixA[2,2] * matrixA[3,0] + matrixA[0,2] * matrixA[2,0] * matrixA[3,1] - matrixA[0,0] * matrixA[2,2] * matrixA[3,1] - matrixA[0,1] * matrixA[2,0] * matrixA[3,2] - matrixA[0,2] * matrixA[2,1] * matrixA[3,0];
                    //a11a32a43                                                         +a12a33a41                                  +a13a31a42                                      −a11a33a42                                  −a12a31a43                                  −a13a32a41
                    matrixSolution[3, 2] = matrixA[0, 0] * matrixA[1,2] * matrixA[3,1] + matrixA[0,1] * matrixA[1,0] * matrixA[3,2] + matrixA[0,2] * matrixA[1,1] * matrixA[3,0] - matrixA[0,0] * matrixA[1,1] * matrixA[3,2] - matrixA[0,1] * matrixA[1,2] * matrixA[3,0] - matrixA[0,2] * matrixA[1,0] * matrixA[3,1];
                    // a11a23a42                                                        +a12a21a43                                  +a13a22a41                                      −a11a22a43                                  −a12a23a41                                  −a13a21a42
                    matrixSolution[3, 3] = matrixA[0, 0] * matrixA[1,1] * matrixA[2,2] + matrixA[0,1] * matrixA[1,2] * matrixA[2,0] + matrixA[0,2] * matrixA[1,0] * matrixA[2,1] - matrixA[0,0] * matrixA[1,2] * matrixA[2,1] - matrixA[0,1] * matrixA[1,0] * matrixA[2,2] - matrixA[0,2] * matrixA[1,1] * matrixA[2,0];
                    //a11a22a33                                                         +a12a23a31                                  +a13a21a32                                      −a11a23a32                                  −a12a21a33                                  −a13a22a31

                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            double tmp = matrixA[i, j];
                            matrixSolution[j, i] = tmp;
                        }

                    }

                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            matrixSolution[i, j] =matrixSolution[i,j] * (1/det);
                        }
                    }

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
