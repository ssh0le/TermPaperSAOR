using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TermPaper
{
    public partial class MainForm : Form
    {
        public static TextBox[,] textBoxes;

        public MainForm()
        {
            InitializeComponent();
            textBoxes = new TextBox[6, 5];
            textBoxes[0, 0] = textBox00;
            textBoxes[0, 4] = textBox04;
            textBoxes[1, 4] = textBox14;
            textBoxes[2, 4] = textBox24;
            textBoxes[3, 4] = textBox34;
            textBoxes[4, 4] = textBox44;
            textBoxes[5, 4] = textBox54;
            textBoxes[0, 3] = textBox03;
            textBoxes[1, 3] = textBox13;
            textBoxes[2, 3] = textBox23;
            textBoxes[3, 3] = textBox33;
            textBoxes[4, 3] = textBox43;
            textBoxes[5, 3] = textBox53;
            textBoxes[0, 2] = textBox02;
            textBoxes[1, 2] = textBox12;
            textBoxes[2, 2] = textBox22;
            textBoxes[3, 2] = textBox32;
            textBoxes[4, 2] = textBox42;
            textBoxes[5, 2] = textBox52;
            textBoxes[5, 1] = textBox51;
            textBoxes[0, 1] = textBox01;
            textBoxes[1, 1] = textBox11;
            textBoxes[2, 1] = textBox21;
            textBoxes[3, 1] = textBox31;
            textBoxes[4, 1] = textBox41;
            textBoxes[4, 0] = textBox40;
            textBoxes[1, 0] = textBox10;
            textBoxes[2, 0] = textBox20;
            textBoxes[3, 0] = textBox30;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Interface.Clear();
            SolverTool.InitializeTariffs(GetTariffMatrix());
            SetTariffMatrix(SolverTool.GetAmountArray());
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Interface.Clear();
            int[] volume = { 3300, 6000, 1250, 1600, 1850 };
            int[] norma = { 500, 385, 310, 300 };
            double[,] rates = { { 0.8, 1, 0.9, 0.9 }, { 2.4, 3, 3.4, 3.2 }, { 0, 0, 1, 0.95 }, { 0.2, 0.27, 0.25, 0.27 }, { 0, 0.8, 0.75, 0.85 } };
            for (int i = 0; i < textBoxes.GetLength(0); i++)
            {
                if (textBoxes[i, 0] != null)
                {
                    textBoxes[i, 0].Text = volume[i].ToString();
                }
            }
            for (int i = 1; i < textBoxes.GetLength(1); i++)
            {
                textBoxes[textBoxes.GetLength(0) - 1, i].Text = norma[i- 1].ToString();
            }
            for (int i = 0; i < textBoxes.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < textBoxes.GetLength(1); j++)
                {
                    textBoxes[i, j].Text = rates[i, j - 1].ToString();
                }
            }
        }

        public static string[,] GetTariffMatrix()
        {
            string[,] matrix = new string[textBoxes.GetLength(0), textBoxes.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                matrix[i, matrix.GetLength(1) - 1] = textBoxes[i, 0].Text;
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    matrix[i, j] = textBoxes[i, j+1].Text;
                }
            }
            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                matrix[matrix.GetLength(0) - 1, i] = textBoxes[textBoxes.GetLength(0) -1, i + 1].Text;
            }
            return matrix;
        }

        public static void SetTariffMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                   textBoxes[i, j + 1].Text = matrix[i, j];
                }
                textBoxes[i, 0].Text = matrix[i, matrix.GetLength(1) - 1];
            }
            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
               textBoxes[textBoxes.GetLength(0) - 1, i + 1].Text = matrix[matrix.GetLength(0) - 1, i];
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Interface.Clear();
            SolverTool.InitializeTariffs(GetTariffMatrix());
            SetTariffMatrix(SolverTool.GetPotentialArray());
            Interface.HighlightFilledCells(SolverTool.GetAmountArray());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Interface.Clear();
            SolverTool.Displayer = Iterator;
            SolverTool.SolveProblem(GetTariffMatrix());
            SetTariffMatrix(SolverTool.GetPotentialArray());
        }

        private static void Iterator()
        {
            Interface.Clear();
            SetTariffMatrix(SolverTool.GetPotentialArray());
            Interface.HighlightFilledCells(SolverTool.GetAmountArray());
            MessageBox.Show("next interation");
        }
    }
}
