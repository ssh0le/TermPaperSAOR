using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static TermPaper.Interface;

namespace TermPaper
{
    public partial class MainForm : Form
    {
        public static TextBox[,] textBoxes;
        public static TextBox[] tractorAmounts;
        public static TextBox ResultSum;
        public static Button[] buttons;
        private const string Err = "Не все текстовые поля имеют корректный формат";
        private const string MesErr = "В выделенных текстовых полях указан некорректный формат!";
        private static bool IsValidAllFormat;

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
            foreach(TextBox tb in textBoxes)
            {
                if(tb != null)
                {
                    SetEvents(tb);
                }
            }

            tractorAmounts = new TextBox[4];
            tractorAmounts[0] = TAmount1;
            tractorAmounts[1] = TAmount2;
            tractorAmounts[2] = TAmount3;
            tractorAmounts[3] = TAmount4;
            foreach(TextBox tb in tractorAmounts)
            {
                SetEvents(tb);
            }

            ResultSum = resultSum;

            buttons = new Button[3];
            buttons[0] = DefaultData;
            buttons[1] = FindSolution;
            buttons[2] = Clear;

            IsValidAllFormat = false;
        }

        public enum MainFormButtons
        {
            SetDafultData,
            FindSolution,
            Clear
        }

        private void SetEvents(TextBox tb)
        {
            if(tb.Tag.ToString() == "double")
            {
                tb.KeyPress += OnlyDoubleKeyPressEvent;
            }
            else
            {
                tb.KeyPress += OnlyIntKeyPressEvent;
            }
            tb.TextChanged += TextBoxTextChanged;
        }

        private void OnlyDoubleKeyPressEvent(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 44 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void OnlyIntKeyPressEvent(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8) 
            {
                e.Handled = true;
            }
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            bool flag = false;
            if (tb.Tag.ToString() == "double")
            {
                if (!double.TryParse(tb.Text, out _))
                {
                    flag = true;
                }
            }
            else
            {
                if (!int.TryParse(tb.Text, out _))
                {
                    flag = true;
                }
            }
            if (flag)
            {
                tb.BackColor = System.Drawing.Color.Tomato;
                tb.ForeColor = System.Drawing.Color.White;
                errorProvider1.SetError(buttons[(int)MainFormButtons.FindSolution], Err);
            }
            else
            {
                tb.BackColor = System.Drawing.Color.White;
                tb.ForeColor = System.Drawing.Color.Black;
                if (CheckFormatAllTextBoxes())
                {
                    errorProvider1.Clear();
                }
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void DefaultData_Click(object sender, EventArgs e)
        {
            Clear();
            SetDefaultData();
        }

        private void FindSolution_Click(object sender, EventArgs e)
        {
            if (CheckFormatAllTextBoxes())
            {
                SolverTool.SolveProblem(GetTariffMatrix(), GetTractorAmount());
                DisplayResults(SolverTool.GetAmountArray());
            }
            else
            {
                HighlightInvalidCells();
                MessageBox.Show(MesErr);
            }
        }

    }
}
