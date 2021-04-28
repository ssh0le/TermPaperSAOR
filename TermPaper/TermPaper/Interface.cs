namespace TermPaper
{
    public static class Interface
    {
        public static void HighlightFilledCells(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (double.Parse(matrix[i, j]) != Tariff.Default)
                    {
                        MainForm.textBoxes[i, j + 1].BackColor = System.Drawing.Color.LightGreen;
                    }
                }
            }
        }

        public static void Clear()
        {
            for (int i = 0; i < MainForm.textBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < MainForm.textBoxes.GetLength(1); j++)
                {
                    if(i != MainForm.textBoxes.GetLength(1) - 1 && j != 0)
                    {
                        MainForm.textBoxes[i, j].BackColor = System.Drawing.Color.White;
                    }
                }
            }
        }
    }
}
