using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema4
{
    public partial class Form1 : Form
    {
        List<List<Tuple<double, int>>> matrixA = new List<List<Tuple<double, int>>>();
        List<double> vectorB = new List<double>();
        List<double> diagonala = new List<double>();
        List<double> vectorX = new List<double>();
        double precizie;

        Random rand = new Random();

        char[] separatori = { ',', ' ' };

        public Form1()
        {
            InitializeComponent();
        }

        void createMatrix(List<List<Tuple<double, int>>> matrix)
        {
            int n = 0;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "E:\\Facultate\\CN\\Tema4\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }

            using (TextReader reader = File.OpenText(filePath))
            {
                string line;
                int count = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (count == 0)
                    {
                        n = Int32.Parse(line);
                        for (int i = 0; i < n; i++)
                            matrix.Add(new List<Tuple<double, int>>());
                        count++;
                    }
                    else
                    {
                        if (line != "")
                        {
                            string[] bits = line.Split(separatori);
                            
                            double value;
                            int row, col;
                            if (!double.TryParse(bits[0], out value))
                            {
                                Console.WriteLine("Bad double value");
                                return;
                            }
                            if (bits.Length == 6)
                            {
                                row = Int32.Parse(bits[3]);
                                col = Int32.Parse(bits[5]);
                            }
                            else
                            {
                                row = Int32.Parse(bits[2]);
                                col = Int32.Parse(bits[4]);
                            }
                            

                            Tuple<double, int> tupla = new Tuple<double, int>(value, col);
                            matrix[row].Add(tupla);
                        }
                    }
                }
            }

            double aux;

            for (int i = 0; i < matrix.Count; i++)
            {
                matrix[i] = matrix[i].OrderBy(x => x.Item2).ToList();
                for (int j = 0; j < matrix[i].Count - 1; j++)
                {
                    if (matrix[i][j].Item2 == matrix[i][j + 1].Item2)
                    {
                        aux = matrix[i][j].Item1 + matrix[i][j + 1].Item1;
                        Tuple<double, int> taux = new Tuple<double, int>(aux, matrix[i][j].Item2);
                        matrix[i][j] = taux;
                        matrix[i].RemoveAt(j + 1);
                        j--;
                    }
                }
            }
        }

        void createVector(List<double> vector)
        {
            int n = 0;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "E:\\Facultate\\CN\\Tema4\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }

            using (TextReader reader = File.OpenText(filePath))
            {
                string line;
                int count = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (count == 0)
                    {
                        n = Int32.Parse(line);
                        count++;
                    }
                    else if (line != "")
                    {
                        double value;
                        value = double.Parse(line);
                        vector.Add(value);
                        
                    }
                }
            }
        }

        private void readMatrixButton_Click(object sender, EventArgs e)
        {
            validA.Text = "Valid: ";
            matrixA.Clear();
            createMatrix(matrixA);

            for(int i=0;i<matrixA.Count;i++)
            {
                diagonala.Add((double)0.0);
            }

            int ok = 1;
            for (int i = 0; i < matrixA.Count; i++)
            {
                for (int j = 0; j < matrixA[i].Count; j++)
                {
                    if (matrixA[i][j].Item2 == i)
                    {
                        diagonala[i] = matrixA[i][j].Item1;
                        if (matrixA[i][j].Item1 == 0) 
                        {
                            ok = 0;
                        }
                        
                    } 
                }
            }

            if(ok!=0)
            {
                validA.Text += " DA!";
            }
            else
            {
                validA.Text += " NU!";
            }
        }

        private void citesteVectorB_Click(object sender, EventArgs e)
        {
            vectorB.Clear();
            createVector(vectorB);
        }

        double calculeazaPrecizie(int p)
        {
            int m = 0;
            decimal dec = new decimal(-1 * m);
            double d = (double)dec;
            double prec = Math.Pow(10, d);
            while (prec > 0 && m <= p)
            {
                m++;
                d = -1 * m;
                prec = Math.Pow(10, d);
            }
            return prec * 10;
        }

        //double Norma(List<double> Xc, List<double> Xp)
        //{
        //    //double sum = 0;
        //    //for (int i = 0; i < Xc.Count; i++)
        //    //{
        //    //    sum += Math.Pow(Xc[i] - Xp[i], 2);
        //    //}

        //    //return Math.Sqrt(sum);

        //    double sum = 0;

        //    for (int i = 0; i < Xc.Count; i++)
        //    {
        //        sum += Xc[i] - Xp[i];
        //    }

        //    return Math.Abs(sum);
        //}

        void calculeazaNormaAxB(List<List<Tuple<double, int>>> A, List<double> X, List<double> B)
        {
            double normai = 0;
            for (int i = 0; i < A.Count; i++)
            {
                double sum = 0;
                for (int j = 0; j < A[i].Count; j++)
                {
                    sum += A[i][j].Item1 * X[A[i][j].Item2];
                }
                if (normai < Math.Abs(sum - B[i]))
                {
                    normai = Math.Abs(sum - B[i]);
                }
            }

            Console.WriteLine(normai);
            //List<double> aux = new List<double>();

            //double normai = 0;
            //for (int i = 0; i < A.Count; i++) 
            //{
            //    double sum = 0;
            //    for (int j = 0; j < A[i].Count; j++)
            //    {

            //        sum += A[i][j].Item1 * X[A[i][j].Item2];
            //    }
            //    sum -= B[i];
            //    aux.Add(sum);
            //}

            //for (int i = 0; i < aux.Count; i++) 
            //{
            //    //Console.WriteLine(i+" : "+aux[i]);
            //    if (Double.IsNaN(aux[i]))
            //    {
            //        aux.RemoveAt(i);
            //        i--;
            //    }
            //    else 
            //    {
            //        aux[i] = Math.Abs(aux[i]);
            //        //if (Math.Abs(aux[i]) > normai)
            //        //{
            //        //    normai = Math.Abs(aux[i]);
            //        //}
            //    }
            //}

            //aux.Sort();
            //normai = aux[aux.Count - 1];

            //for (int i = 0; i < aux.Count; i++)
            //{
            //    Console.WriteLine(i + " : " + aux[i]);
            //}

            //Console.WriteLine(normai);
            AxBNorma.Text += normai;
        }

        List<double> calculeazaX(List<double> B, List<List<Tuple<double,int>>> A, List<double> D)
        {
            AxBNorma.Text = "Norma: ";
            List<double> X = new List<double>();
            precizie=calculeazaPrecizie((int)p_val.Value);
            //Console.WriteLine(precizie);

            for (int i = 0; i < B.Count; i++)
            {
                //X.Add((double)rand.Next(2, 2));
                X.Add(0);
            }
            double norma;
            //List<double> X_prev;
            do
            {
                //X_prev = new List<double>(X);
                norma = 0;
                for (int i = 0; i < X.Count; i++)
                {
                    double prima_suma = 0;
                    double a_doua_suma = 0;

                    for (int j = 0; j < A[i].Count; j++)
                    {
                        if (A[i][j].Item2 <= i - 1)
                        {
                            prima_suma += A[i][j].Item1 * X[A[i][j].Item2];
                        } 
                        if(A[i][j].Item2>=i+1)
                        {
                            //a_doua_suma += A[i][j].Item1 * X_prev[A[i][j].Item2];
                            a_doua_suma += A[i][j].Item1 * X[A[i][j].Item2];
                        }
                    }
                    double aux = X[i];
                    X[i] = (B[i] - prima_suma - a_doua_suma) / D[i];
                    norma += Math.Pow(X[i] - aux, 2);
                }
            } while (Math.Sqrt(norma) > precizie);


            for (int i = 0; i < X.Count; i++)
            {
                Console.WriteLine(X[i]);
            }
            return X;

        }

        private void calculeazaXButton_Click(object sender, EventArgs e)
        {
            vectorX=calculeazaX(vectorB, matrixA, diagonala);
            calculeazaNormaAxB(matrixA, vectorX, vectorB);
        }

        
    }
}
