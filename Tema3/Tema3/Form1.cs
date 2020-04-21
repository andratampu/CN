using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema3
{
    public partial class Form1 : Form
    {
        List<List<Tuple<double, int>>> matrixA = new List<List<Tuple<double, int>>>();
        List<List<Tuple<double, int>>> matrixB = new List<List<Tuple<double, int>>>();

        List<List<Tuple<double, int>>> matrixAplusB = new List<List<Tuple<double, int>>>();
        List<List<Tuple<double, int>>> matrixAoriB = new List<List<Tuple<double, int>>>();

        char[] separatori = { ' ', ',' };

        public double precizie()
        {
            int m = 0;
            decimal dec = new decimal(-1 * m);
            double d = (double)dec;
            double u = Math.Pow(10, d);
            while (u > 0 && u + 1 != 1)
            {
                m++;
                d = -1 * m;
                u = Math.Pow(10, d);
            }

            return u;
        }

        bool createMatrix(List<List<Tuple<double, int>>> matrix, char tip)
        {
            int n = 0;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "E:\\Facultate\\CN\\Tema3\\";
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
                                return false;
                            }

                            row = Int32.Parse(bits[2]);
                            col = Int32.Parse(bits[4]);

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
            int ok = 1;
            for (int i = 0; i < matrix.Count; i++)
            {
                matrix[i] = matrix[i].OrderBy(x => x.Item2).ToList();
                if ((matrix[i].Count > 10 && tip == 'A') || (matrix[i].Count > 20 && tip == 'B'))
                {
                    ok = 0;
                }
            }
            if (ok == 1)
                return true;
            else
                return false;
        }

        List<List<Tuple<double, int>>> addMatrices(List<List<Tuple<double, int>>> matrix1, List<List<Tuple<double, int>>> matrix2)
        {
            List<List<Tuple<double, int>>> matrix = new List<List<Tuple<double, int>>>();
            int i = 0;

            while (i < matrix1.Count) 
            {
                matrix.Add(new List<Tuple<double, int>>());

                int j = 0, p = 0, max1 = matrix1[i].Count, max2 = matrix2[i].Count;
                int min = Math.Min(max1, max2);
                int max = Math.Max(max1, max2);

                if (max1 > 0 && max2 > 0)
                {
                    while (j + p < matrix1[i].Count + matrix2[i].Count) 
                    {
                        if (p >= matrix2[i].Count) 
                        {
                            matrix[i].Add(new Tuple<double, int>(matrix1[i][j].Item1, matrix1[i][j].Item2));
                            j++;
                        }
                        else if (j >= matrix1[i].Count)
                        {
                            matrix[i].Add(new Tuple<double, int>(matrix2[i][p].Item1, matrix2[i][p].Item2));
                            p++;
                        }
                        else if (matrix1[i][j].Item2 == matrix2[i][p].Item2)
                        {
                            matrix[i].Add(new Tuple<double, int>(matrix1[i][j].Item1 + matrix2[i][p].Item1, matrix1[i][j].Item2));
                            j++;p++;
                        }
                        else if (matrix1[i][j].Item2 > matrix2[i][p].Item2)
                        {
                            matrix[i].Add(new Tuple<double, int>(matrix2[i][p].Item1, matrix2[i][p].Item2));
                            p++;
                        }
                        else if (matrix1[i][j].Item2 < matrix2[i][p].Item2)
                        {
                            matrix[i].Add(new Tuple<double, int>(matrix1[i][j].Item1, matrix1[i][j].Item2));
                            j++;
                        }
                    }
                }
                i++;
            }

            for (i = 0; i < matrix.Count; i++) 
            {
                matrix[i] = matrix[i].OrderBy(x => x.Item2).ToList();
            }
            Console.WriteLine("================ADUNARE====================");

            for (i = 0; i < matrix.Count; i++)
            {
                Console.WriteLine(i);
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    Console.WriteLine(matrix[i][j].Item2 + " : " + matrix[i][j].Item1);
                }
            }

            return matrix;
        }

        List<List<Tuple<double, int>>> multiplyMatrices(List<List<Tuple<double, int>>> matrix1, List<List<Tuple<double, int>>> matrix2)
        {
            List<List<Tuple<double, int>>> matrix = new List<List<Tuple<double, int>>>(matrix1.Count);

            for (int i = 0; i < matrix1.Count; i++)
            {
                matrix.Add(new List<Tuple<double, int>>());
            }

            for (int i = 0; i < matrix1.Count; i++) 
            {
                for (int j = 0; j < matrix1[i].Count; j++)
                {
                    for (int k = 0; k < matrix2[matrix1[i][j].Item2].Count; k++)
                    {
                        matrix[i].Add(new Tuple<double, int>(matrix1[i][j].Item1 * matrix2[matrix1[i][j].Item2][k].Item1, matrix2[matrix1[i][j].Item2][k].Item2));
                    }
                }
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                matrix[i] = matrix[i].OrderBy(x => x.Item2).ToList();
                for (int j = 0; j < matrix[i].Count - 1; j++)
                {
                    if (matrix[i][j].Item2 == matrix[i][j + 1].Item2)
                    {
                        double aux = matrix[i][j].Item1 + matrix[i][j + 1].Item1;
                        Tuple<double, int> taux = new Tuple<double, int>(aux, matrix[i][j].Item2);
                        matrix[i][j] = taux;
                        matrix[i].RemoveAt(j + 1);
                        j--;
                    }
                }
            }

            Console.WriteLine("===========INMULTIRE==================");

            for (int i = 0; i < matrix.Count; i++)
            {
                Console.WriteLine(i);
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    Console.WriteLine(matrix[i][j].Item2 + " : " + matrix[i][j].Item1);
                }
            }

            return matrix;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void readA_Click(object sender, EventArgs e)
        {
            matrixA.Clear();
            bool valid = createMatrix(matrixA, 'A');

            if (valid)
                validA.Text += " DA";
            else
                validA.Text += " NU";
        }

        private void readB_Click(object sender, EventArgs e)
        {
            matrixB.Clear();
            bool valid = createMatrix(matrixB, 'A');

            if (valid)
                validB.Text += " DA";
            else
                validB.Text += " NU";
        }

        private void readAplusB_Click(object sender, EventArgs e)
        {
            matrixAplusB.Clear();
            bool valid = createMatrix(matrixAplusB, 'B');

            if (valid)
                validAplusB.Text += " DA";
            else
                validAplusB.Text += " NU";
        }

        private void readAoriB_Click(object sender, EventArgs e)
        {
            matrixAoriB.Clear();
            bool valid = createMatrix(matrixAoriB, 'B');

            if (valid)
                validAoriB.Text += " DA";
            else
                validAoriB.Text += " NU";
        }

        private void calculAplusB_Click(object sender, EventArgs e)
        {
            List<List<Tuple<double, int>>> matrixa_copy = new List<List<Tuple<double, int>>>(matrixA);

            List<List<Tuple<double, int>>> matrixb_copy = new List<List<Tuple<double, int>>>(matrixB);

            List<List<Tuple<double, int>>> matrixaplusb = addMatrices(matrixa_copy, matrixb_copy);

            int ok = 1;
            if (matrixaplusb.Count != matrixAplusB.Count)
            {
                ok = 0;
                calcAplusB.Text += " NU, difera lungimea intregii liste. "+matrixaplusb.Count+" "+matrixAplusB.Count;
                return;
            }
             
            try
            {
                for (int i = 0; i < matrixaplusb.Count; i++) 
                {
                    if (matrixaplusb[i].Count != matrixAplusB[i].Count) 
                    {
                        ok = 0;
                        calcAplusB.Text += " NU, difera lungimea intregii linii. Linia: "+i;
                        return;
                    }

                    for (int j = 0; j < matrixaplusb[i].Count; j++)
                    {
                        if (matrixaplusb[i][j].Item2 != matrixAplusB[i][j].Item2)
                        {
                            ok = 0;
                            calcAplusB.Text += " NU, difera indecsii.";
                            return;
                        }
                        if (Math.Abs(matrixaplusb[i][j].Item1 - matrixAplusB[i][j].Item1)>precizie())
                        {
                            ok = 0;
                            calcAplusB.Text += " NU, valorile nu sunt egale. Linia "+i+"Elem "+j;
                            return;
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                ok = 0;
                calcAplusB.Text += "NU\n" + ex.Message;
                return;
            }
            if (ok == 1)
                calcAplusB.Text += " DA";
            
        }

        private void calculAoriB_Click(object sender, EventArgs e)
        {
            List<List<Tuple<double, int>>> matrixa_copy = new List<List<Tuple<double, int>>>(matrixA);

            List<List<Tuple<double, int>>> matrixb_copy = new List<List<Tuple<double, int>>>(matrixB);

            List<List<Tuple<double, int>>> matrixaorib = multiplyMatrices(matrixa_copy, matrixb_copy);

            int ok = 1;
            if (matrixaorib.Count != matrixAoriB.Count)
            {
                ok = 0;
                calcAoriB.Text += " NU, difera lungimea intregii liste. " + matrixaorib.Count + " " + matrixAoriB.Count;
                return;
            }

            try
            {
                for (int i = 0; i < matrixaorib.Count; i++)
                {
                    if (matrixaorib[i].Count != matrixAoriB[i].Count)
                    {
                        ok = 0;
                        calcAoriB.Text += " NU, difera lungimea intregii linii. Linia: " + i;
                        return;
                    }

                    for (int j = 0; j < matrixaorib[i].Count; j++)
                    {
                        if (matrixaorib[i][j].Item2 != matrixAoriB[i][j].Item2)
                        {
                            ok = 0;
                            calcAoriB.Text += " NU, difera indecsii.";
                            return;
                        }
                        if (Math.Abs(matrixaorib[i][j].Item1 - matrixAoriB[i][j].Item1) > precizie())
                        {
                            ok = 0;
                            calcAoriB.Text += " NU, valorile nu sunt egale. Linia " + i + "Elem " + j;
                            return;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ok = 0;
                calcAoriB.Text += "NU\n" + ex.Message;
                return;
            }
            if (ok == 1)
                calcAoriB.Text += " DA";

        }
    }
    
}
