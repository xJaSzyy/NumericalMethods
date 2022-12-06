using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumericalMethods
{
    public partial class Form1 : Form
    {
        double[,] x = new double[81, 81];
        double[] y = new double[81];
        double[,] a = new double[81, 81];

        double Sign(double x)
        {
            if (x == 0.0)
            {
                return 0;
            }
            else if (x > 0.0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private double[] GaussMethod(double[,] array, double[] y)
        {
            double[] x = new double[dataGridView3.RowCount];
            double max;
            double eps = 0.00001;
            int index, k = 0;
            int n = dataGridView1.RowCount;
            while (k < n)
            {
                max = Math.Abs(array[k, k]);
                index = k;
                for (int i = k + 1; i < n; i++)
                {
                    if (Math.Abs(array[i, k]) > max)
                    {
                        max = Math.Abs(array[i, k]);
                        index = i;
                    }
                }

                if (max < eps)
                {
                    MessageBox.Show("Получить решение невозможно из-за нулевого столбца");
                }

                for (int j = 0; j < n; j++)
                {
                    double temp = array[k, j];
                    array[k, j] = array[index, j];
                    array[index, j] = temp;
                }
                double temp1 = y[k];
                y[k] = y[index];
                y[index] = temp1;

                for (int i = k; i < n; i++)
                {
                    double temp2 = array[i, k];
                    if (Math.Abs(temp2) < eps)
                    {
                        continue;
                    }
                    for (int j = k; j < n; j++)
                    {
                        array[i, j] = array[i, j] / temp2;
                    }
                    y[i] = y[i] / temp2;
                    if (i == k)
                    {
                        continue;
                    }
                    for (int j = k; j < n; j++)
                    {
                        array[i, j] = array[i, j] - array[k, j];
                    }
                    y[i] = y[i] - y[k];
                }
                k++;
            }
            for (k = n - 1; k >= 0; k--)
            {
                x[k] = y[k];
                for (int i = 0; i < k; i++)
                {
                    y[i] = y[i] - array[i, k] * x[k];
                }
            }
            return x;
        }

        private double[] SweepMethod(double[,] array, double[] y)
        {
            double[] x = new double[dataGridView1.RowCount];
            double[] eps = new double[dataGridView1.RowCount];
            double[] et = new double[dataGridView1.RowCount];
            double z;
            int n;
            n = Convert.ToInt32(Count.Text) - 1;
            eps[0] = -array[0, 1] / array[0, 0];
            et[0] = y[0] / array[0, 0];

            for (int i = 1; i < n; i++)
            {
                z = array[i, i] + array[i, i - 1] * eps[i - 1];
                eps[i] = -array[i, i + 1] / z;
                et[i] = (y[i] - array[i, i - 1] * et[i - 1]) / z;
            }
            x[n] = (y[n] - array[n, n - 1] * et[n - 1]) / (array[n, n] + array[n, n - 1] * eps[n - 1]);
            
            for (int i = n-1; i >= 0; i--)
            {
                x[i] = eps[i] * x[i + 1] + et[i];
            }
            return x;
        }

        private double[] SquareRootMethod(double[,] array)
        {
            int n = Convert.ToInt32(Count.Text);
            int m = n + 1;
            double[,] S = new double[n + 1, n + 1];
            double[,] D = new double[n + 1, n + 1];  

            S[1,1] = Math.Sqrt(Math.Abs(array[1,1]));
            D[1,1] = Sign(array[1,1]);

            for (int j = 2; j <= n; ++j)
            {
                S[1, j] = array[1,j] / (S[1, 1] * D[1, 1]);
            }

            for (int i = 2; i <= n; ++i)
            {
                double sum = 0;
                for (int l = 1; l <= i - 1; ++l)
                {
                    sum = sum + S[l, i] * S[l, i] * D[l, l];
                }
                S[i,i] = Math.Sqrt(Math.Abs(array[i,i] - sum));
                D[i,i] = Sign(array[i, i] - sum);
                for (int j = i + 1; j <= n; ++j)
                {
                    sum = 0;
                    for (int l = 1; l <= i - 1; l++)
                    {
                        sum = sum + S[l,i] * S[l,j] * D[l,l];
                    }
                    S[i,j] = (array[i,j] - sum) / (S[i,i] * D[i,i]);
                }
            }

            double[] y = new double[n + 1];
            y[1] = array[1, m] / S[1, 1] * D[1, 1];
            for (int i = 2; i <= n; ++i)
            {
                double sum = 0;
                for (int l = 1; l <= i - 1; ++l)
                {
                    sum = sum + S[l, i] * y[l] * D[l, l];
                }
                y[i] = (array[i, m] - sum) / (S[i, i] * D[i, i]);
            }

            double[] x = new double[n+1];
            x[n] = y[n] / S[n,n];
            for (int i = n - 1; i >= 1; --i)
            {
                double sum = 0;
                for (int l = i + 1; l <= n; ++l)
                {
                    sum = sum + S[i, l] * x[l];
                }
                x[i] = (y[i] - sum) / S[i,i];
            }

            return x;
        }

        private double[] SteepestDescentMethod(double[,] array, double[] y)
        {
            int N = Convert.ToInt32(Count.Text);
            double[] x0 = new double[N];
            double[] x1 = new double[N];
            double[] r = new double[N];
            double[] r1 = new double[N];
            double s, s1 = 0;
            int k = 0;

            do
            {
                for (int i = 0; i < N; i++)
                {
                    r[i] = y[i];
                    for (int j = 0; j < N; j++)
                    {
                        r[i] -= array[i, j] * x0[j];
                    }
                }

                s = 0;
                for (int i = 0; i < N; i++)
                {
                    s += r[i] * r[i];
                }

                for (int i = 0; i < N; i++)
                {
                    r1[i] = 0;
                    for (int j = 0; j < N; j++)
                    {
                        r1[i] += array[i, j] * r[j];
                    }
                }

                s1 = 0;
                for (int i = 0; i < N; i++)
                {
                    s1 += r[i] * r1[i];
                }
                s /= s1;

                for (int i = 0; i < N; i++)
                {
                    x1[i] += s * r[i];
                }
                s = 0;

                for (int i = 0; i < N; i++)
                {
                    s += (x0[i] - x1[i]) * (x0[i] - x1[i]);
                    x0[i] = x1[i];
                }
                k++;
            }
            while (k < 50000 && Math.Sqrt(s) > 0.01);
            return x1;
        }

        private void Count_TextChanged(object sender, EventArgs e)
        {
            if (Count.Text != "")
            {
                dataGridView1.RowCount = int.Parse(Count.Text);
                dataGridView2.RowCount = int.Parse(Count.Text);
                dataGridView3.RowCount = int.Parse(Count.Text);
                dataGridView1.ColumnCount = int.Parse(Count.Text);
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1.Columns[i].Name = "x" + (i + 1).ToString();
                }
                x = new double[dataGridView1.RowCount, dataGridView1.ColumnCount];
                y = new double[dataGridView2.RowCount];
            }
        }

        private void Count_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void заполнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = rnd.Next(-10, 10);
                }
            }
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = rnd.Next(-10, 10);
            }
        }

        private void FillArray()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    x[i, j] = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
                }
            }

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                y[i] = Convert.ToDouble(dataGridView2.Rows[i].Cells[0].Value);
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount + 1; j++)
                {
                    if (j != dataGridView1.ColumnCount)
                    {
                        a[i, j] = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
                    }
                    else
                    {
                        a[i, j] = Convert.ToDouble(dataGridView2.Rows[i].Cells[0].Value);
                    }
                }
            }
        }

        private void Print(double[] x, int accuracy)
        {
            for (int i = 0; i < x.Length; i++)
            {
                dataGridView3.RowCount = x.Length;
                dataGridView3.Rows[i].Cells[0].Value = Math.Round(x[i], accuracy);
            }
        }

        private int Accuracy()
        {
            return 3;
        }

        private void квадратногоКорняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillArray();
            Print(SquareRootMethod(a), Accuracy());
        }

        private void прогонкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillArray();
            Print(SweepMethod(x, y), Accuracy());
        }

        private void гауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillArray();
            Print(GaussMethod(x, y), Accuracy());
        }

        private void наискорейшегоСпускаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillArray();
            Print(SteepestDescentMethod(x, y), Accuracy());
        }
    }
}
