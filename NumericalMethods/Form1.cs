﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumericalMethods
{
    public partial class Form1 : Form
    {
        double[,] array = new double[81, 81];
        double[] y = new double[81];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private double[] GaussMethod(double[,] array, double[] y)
        {
            double[] x = new double[dataGridView1.RowCount];
            double max;
            double eps = 1e-9;
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
                    for (int j = 0; j < n; j++)
                    {
                        array[i, j] = array[i, j] / temp2;
                    }
                    y[i] = y[i] / temp2;
                    if (i == k)
                    {
                        continue;
                    }
                    for (int j = 0; j < n; j++)
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
                array = new double[dataGridView1.RowCount, dataGridView1.ColumnCount];
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

        private void методомГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillArray();

            PrintArray(GaussMethod(array, y), Accuracy());
        }

        private void методомПрогонкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillArray();

            PrintArray(SweepMethod(array, y), Accuracy());
        }

        private void FillArray()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    array[i, j] = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
                }
            }

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                y[i] = Convert.ToDouble(dataGridView2.Rows[i].Cells[0].Value);
            }
        }

        private void PrintArray(double[] x, int accuracy)
        {
            for (int i = 0; i < x.Length; i++)
            {
                dataGridView3.Rows[i].Cells[0].Value = Math.Round(x[i], accuracy);
            }
        }

        private int Accuracy()
        {
            if (Precision.Text != "")
            {
                return Convert.ToInt32(Precision.Text);
            }
            else
            {
                return 2;
            }
        }
    }
}
