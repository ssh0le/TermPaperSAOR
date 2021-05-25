using static TermPaper.MainForm;
using System;
using System.Windows.Forms;

namespace TermPaper
{
    public static class Interface
    {
        public static void SetAmountMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    textBoxes[i, j + 1].Text = GetCorrectAmount(matrix[i, j]);
                }
                textBoxes[i, 0].Text = GetCorrectAmount(matrix[i, matrix.GetLength(1) - 1]);
            }
            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                textBoxes[textBoxes.GetLength(0) - 1, i + 1].Text = GetCorrectAmount(matrix[matrix.GetLength(0) - 1, i]);
            }
        }

        public static string GetCorrectAmount(string value)
        {
            int amount = int.Parse(value);
            if (amount > 0)
            {
                return amount.ToString();
            }
            else
            {
                return (Math.Abs(Tariff.Default) + Tariff.Default).ToString();
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
                    matrix[i, j] = textBoxes[i, j + 1].Text;
                }
            }
            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                matrix[matrix.GetLength(0) - 1, i] = textBoxes[textBoxes.GetLength(0) - 1, i + 1].Text;
            }
            return matrix;
        }

        public static void SetDefaultData()
        {
            int[] volume = { 3300, 6000, 1250, 1600, 1850 };
            int[] norma = { 500, 385, 310, 300 };
            double[,] rates = { { 0.8, 1, 0.9, 0.9 }, { 2.4, 3, 3.4, 3.2 }, { 0, 0, 1, 0.95 }, { 0.2, 0.27, 0.25, 0.27 }, { 0, 0.8, 0.75, 0.85 } };
            int[] tAmount = { 4, 20, 10, 4 };
            for (int i = 0; i < textBoxes.GetLength(0); i++)
            {
                if (textBoxes[i, 0] != null)
                {
                    textBoxes[i, 0].Text = volume[i].ToString();
                }
            }
            for (int i = 1; i < textBoxes.GetLength(1); i++)
            {
                textBoxes[textBoxes.GetLength(0) - 1, i].Text = norma[i - 1].ToString();
            }
            for (int i = 0; i < textBoxes.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < textBoxes.GetLength(1); j++)
                {
                    textBoxes[i, j].Text = rates[i, j - 1].ToString();
                }
            }
            for (int i = 0; i < tractorAmounts.Length; i++)
            {
                tractorAmounts[i].Text = tAmount[i].ToString();
            }
        }

        public static string[] GetTractorAmount()
        {
            string[] amounts = new string[4];
            for (int i = 0; i < tractorAmounts.Length; i++)
            {
                amounts[i] = tractorAmounts[i].Text;
            }
            return amounts;
        }

        public static void HighlightFilledCells(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    double amount = double.Parse(matrix[i, j]);
                    if (amount != Tariff.Default && amount != Tariff.Empty)
                    {
                        textBoxes[i, j + 1].BackColor = System.Drawing.Color.LightGreen;
                    }
                }
            }
        }

        public static void Clear()
        {
            for (int i = 0; i < textBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < textBoxes.GetLength(1); j++)
                {
                    if (textBoxes[i, j] != null)
                    {
                        textBoxes[i, j].Text = "";
                        textBoxes[i, j].BackColor = System.Drawing.Color.White;
                    }
                }
            }
            for (int i = 0; i < tractorAmounts.Length; i++)
            {
                tractorAmounts[i].Text = "";
                tractorAmounts[i].BackColor = System.Drawing.Color.White;
            }
            ResultSum.Text = "";
        }

        public static bool CheckFormatAllTextBoxes()
        {
            foreach (TextBox tb in textBoxes)
            {
                if(tb != null && !CheckTextBoxFormat(tb))
                {
                    return false;
                }
            }
            foreach(TextBox tb in tractorAmounts)
            {
                if (!CheckTextBoxFormat(tb))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool CheckTextBoxFormat(TextBox tb)
        {
            if (tb.Tag.ToString() == "double")
            {
                if (!double.TryParse(tb.Text, out _))
                {
                    return false;
                }
            }
            else
            {
                if (!int.TryParse(tb.Text, out _))
                {
                    return false;
                }
            }
            return true;
        }

        public static void HighlightInvalidCells()
        {
            foreach (TextBox tb in textBoxes)
            {
                if (tb != null && !CheckTextBoxFormat(tb))
                {
                    tb.BackColor = System.Drawing.Color.Tomato;
                }
            }
            foreach (TextBox tb in tractorAmounts)
            {
                if (!CheckTextBoxFormat(tb))
                {
                    tb.BackColor = System.Drawing.Color.Tomato;
                }
            }
        }

        public static void DisplayResults(string [,] matrix)
        {
            SetAmountMatrix(matrix);
            HighlightFilledCells(matrix);
            ResultSum.Text = SolverTool.GetResultSum().ToString();
        }

    }
}
