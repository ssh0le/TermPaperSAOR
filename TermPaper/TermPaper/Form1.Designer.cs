using System.Windows.Forms;
namespace TermPaper
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.WorkType = new System.Windows.Forms.Label();
            this.Workload = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.Work1 = new System.Windows.Forms.Label();
            this.Work2 = new System.Windows.Forms.Label();
            this.Work5 = new System.Windows.Forms.Label();
            this.Work3 = new System.Windows.Forms.Label();
            this.Work4 = new System.Windows.Forms.Label();
            this.SeasonalRate = new System.Windows.Forms.Label();
            this.Brand1 = new System.Windows.Forms.Label();
            this.Brand2 = new System.Windows.Forms.Label();
            this.Brand3 = new System.Windows.Forms.Label();
            this.Brand4 = new System.Windows.Forms.Label();
            this.textBox00 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.textBox40 = new System.Windows.Forms.TextBox();
            this.textBox41 = new System.Windows.Forms.TextBox();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox01 = new System.Windows.Forms.TextBox();
            this.textBox51 = new System.Windows.Forms.TextBox();
            this.textBox52 = new System.Windows.Forms.TextBox();
            this.textBox42 = new System.Windows.Forms.TextBox();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox02 = new System.Windows.Forms.TextBox();
            this.textBox53 = new System.Windows.Forms.TextBox();
            this.textBox43 = new System.Windows.Forms.TextBox();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox03 = new System.Windows.Forms.TextBox();
            this.textBox54 = new System.Windows.Forms.TextBox();
            this.textBox44 = new System.Windows.Forms.TextBox();
            this.textBox34 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox04 = new System.Windows.Forms.TextBox();
            this.DefaultData = new System.Windows.Forms.Button();
            this.FindSolution = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TAmount4 = new System.Windows.Forms.TextBox();
            this.TAmount3 = new System.Windows.Forms.TextBox();
            this.TAmount2 = new System.Windows.Forms.TextBox();
            this.TAmount1 = new System.Windows.Forms.TextBox();
            this.Clear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.resultSum = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // WorkType
            // 
            this.WorkType.AutoSize = true;
            this.WorkType.Location = new System.Drawing.Point(29, 71);
            this.WorkType.Name = "WorkType";
            this.WorkType.Size = new System.Drawing.Size(58, 13);
            this.WorkType.TabIndex = 0;
            this.WorkType.Text = "Вид работ";
            // 
            // Workload
            // 
            this.Workload.Location = new System.Drawing.Point(115, 55);
            this.Workload.Name = "Workload";
            this.Workload.Size = new System.Drawing.Size(77, 39);
            this.Workload.TabIndex = 1;
            this.Workload.Text = "Объём работ, га условной пахоты";
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Location = new System.Drawing.Point(255, 58);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(294, 13);
            this.Price.TabIndex = 2;
            this.Price.Text = "Себестоимость 1 га работ (ден. ед.) для трактора марки";
            // 
            // Work1
            // 
            this.Work1.Location = new System.Drawing.Point(29, 113);
            this.Work1.Name = "Work1";
            this.Work1.Size = new System.Drawing.Size(75, 28);
            this.Work1.TabIndex = 3;
            this.Work1.Tag = "";
            this.Work1.Text = "Культивация пара";
            // 
            // Work2
            // 
            this.Work2.Location = new System.Drawing.Point(29, 153);
            this.Work2.Name = "Work2";
            this.Work2.Size = new System.Drawing.Size(75, 29);
            this.Work2.TabIndex = 4;
            this.Work2.Tag = "";
            this.Work2.Text = "Пахота пара";
            // 
            // Work5
            // 
            this.Work5.Location = new System.Drawing.Point(29, 268);
            this.Work5.Name = "Work5";
            this.Work5.Size = new System.Drawing.Size(75, 29);
            this.Work5.TabIndex = 5;
            this.Work5.Tag = "";
            this.Work5.Text = "Сенокошение";
            // 
            // Work3
            // 
            this.Work3.Location = new System.Drawing.Point(29, 187);
            this.Work3.Name = "Work3";
            this.Work3.Size = new System.Drawing.Size(75, 29);
            this.Work3.TabIndex = 6;
            this.Work3.Tag = "";
            this.Work3.Text = "Культивация пропашных";
            // 
            // Work4
            // 
            this.Work4.Location = new System.Drawing.Point(29, 226);
            this.Work4.Name = "Work4";
            this.Work4.Size = new System.Drawing.Size(75, 29);
            this.Work4.TabIndex = 7;
            this.Work4.Tag = "";
            this.Work4.Text = "Боронование в один след";
            // 
            // SeasonalRate
            // 
            this.SeasonalRate.Location = new System.Drawing.Point(29, 321);
            this.SeasonalRate.Name = "SeasonalRate";
            this.SeasonalRate.Size = new System.Drawing.Size(163, 29);
            this.SeasonalRate.TabIndex = 8;
            this.SeasonalRate.Text = "Сезонная норма выработки на каждый трактор, га условной пахоты";
            // 
            // Brand1
            // 
            this.Brand1.Location = new System.Drawing.Point(234, 82);
            this.Brand1.Name = "Brand1";
            this.Brand1.Size = new System.Drawing.Size(72, 28);
            this.Brand1.TabIndex = 9;
            this.Brand1.Text = "А";
            this.Brand1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Brand2
            // 
            this.Brand2.Location = new System.Drawing.Point(331, 82);
            this.Brand2.Name = "Brand2";
            this.Brand2.Size = new System.Drawing.Size(72, 28);
            this.Brand2.TabIndex = 10;
            this.Brand2.Text = "Б";
            this.Brand2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Brand3
            // 
            this.Brand3.Location = new System.Drawing.Point(426, 82);
            this.Brand3.Name = "Brand3";
            this.Brand3.Size = new System.Drawing.Size(72, 28);
            this.Brand3.TabIndex = 11;
            this.Brand3.Text = "В";
            this.Brand3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Brand4
            // 
            this.Brand4.Location = new System.Drawing.Point(519, 82);
            this.Brand4.Name = "Brand4";
            this.Brand4.Size = new System.Drawing.Size(72, 28);
            this.Brand4.TabIndex = 12;
            this.Brand4.Text = "Г";
            this.Brand4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox00
            // 
            this.textBox00.Location = new System.Drawing.Point(110, 113);
            this.textBox00.Name = "textBox00";
            this.textBox00.Size = new System.Drawing.Size(82, 20);
            this.textBox00.TabIndex = 1;
            this.textBox00.Tag = "int";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(110, 150);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(82, 20);
            this.textBox10.TabIndex = 6;
            this.textBox10.Tag = "int";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(110, 187);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(82, 20);
            this.textBox20.TabIndex = 11;
            this.textBox20.Tag = "int";
            // 
            // textBox30
            // 
            this.textBox30.Location = new System.Drawing.Point(110, 226);
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new System.Drawing.Size(82, 20);
            this.textBox30.TabIndex = 16;
            this.textBox30.Tag = "int";
            // 
            // textBox40
            // 
            this.textBox40.Location = new System.Drawing.Point(110, 265);
            this.textBox40.Name = "textBox40";
            this.textBox40.Size = new System.Drawing.Size(82, 20);
            this.textBox40.TabIndex = 21;
            this.textBox40.Tag = "int";
            // 
            // textBox41
            // 
            this.textBox41.Location = new System.Drawing.Point(237, 265);
            this.textBox41.Name = "textBox41";
            this.textBox41.Size = new System.Drawing.Size(69, 20);
            this.textBox41.TabIndex = 22;
            this.textBox41.Tag = "double";
            // 
            // textBox31
            // 
            this.textBox31.Location = new System.Drawing.Point(237, 226);
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new System.Drawing.Size(69, 20);
            this.textBox31.TabIndex = 17;
            this.textBox31.Tag = "double";
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(237, 187);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(69, 20);
            this.textBox21.TabIndex = 12;
            this.textBox21.Tag = "double";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(237, 150);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(69, 20);
            this.textBox11.TabIndex = 7;
            this.textBox11.Tag = "double";
            // 
            // textBox01
            // 
            this.textBox01.Location = new System.Drawing.Point(237, 113);
            this.textBox01.Name = "textBox01";
            this.textBox01.Size = new System.Drawing.Size(69, 20);
            this.textBox01.TabIndex = 2;
            this.textBox01.Tag = "double";
            // 
            // textBox51
            // 
            this.textBox51.Location = new System.Drawing.Point(237, 325);
            this.textBox51.Name = "textBox51";
            this.textBox51.Size = new System.Drawing.Size(69, 20);
            this.textBox51.TabIndex = 26;
            this.textBox51.Tag = "int";
            // 
            // textBox52
            // 
            this.textBox52.Location = new System.Drawing.Point(334, 325);
            this.textBox52.Name = "textBox52";
            this.textBox52.Size = new System.Drawing.Size(69, 20);
            this.textBox52.TabIndex = 27;
            this.textBox52.Tag = "int";
            // 
            // textBox42
            // 
            this.textBox42.Location = new System.Drawing.Point(334, 265);
            this.textBox42.Name = "textBox42";
            this.textBox42.Size = new System.Drawing.Size(69, 20);
            this.textBox42.TabIndex = 23;
            this.textBox42.Tag = "double";
            // 
            // textBox32
            // 
            this.textBox32.Location = new System.Drawing.Point(334, 226);
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(69, 20);
            this.textBox32.TabIndex = 18;
            this.textBox32.Tag = "double";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(334, 187);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(69, 20);
            this.textBox22.TabIndex = 13;
            this.textBox22.Tag = "double";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(334, 150);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(69, 20);
            this.textBox12.TabIndex = 8;
            this.textBox12.Tag = "double";
            // 
            // textBox02
            // 
            this.textBox02.Location = new System.Drawing.Point(334, 113);
            this.textBox02.Name = "textBox02";
            this.textBox02.Size = new System.Drawing.Size(69, 20);
            this.textBox02.TabIndex = 3;
            this.textBox02.Tag = "double";
            // 
            // textBox53
            // 
            this.textBox53.Location = new System.Drawing.Point(429, 325);
            this.textBox53.Name = "textBox53";
            this.textBox53.Size = new System.Drawing.Size(69, 20);
            this.textBox53.TabIndex = 28;
            this.textBox53.Tag = "int";
            // 
            // textBox43
            // 
            this.textBox43.Location = new System.Drawing.Point(429, 265);
            this.textBox43.Name = "textBox43";
            this.textBox43.Size = new System.Drawing.Size(69, 20);
            this.textBox43.TabIndex = 24;
            this.textBox43.Tag = "double";
            // 
            // textBox33
            // 
            this.textBox33.Location = new System.Drawing.Point(429, 226);
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new System.Drawing.Size(69, 20);
            this.textBox33.TabIndex = 19;
            this.textBox33.Tag = "double";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(429, 187);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(69, 20);
            this.textBox23.TabIndex = 14;
            this.textBox23.Tag = "double";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(429, 150);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(69, 20);
            this.textBox13.TabIndex = 9;
            this.textBox13.Tag = "double";
            // 
            // textBox03
            // 
            this.textBox03.Location = new System.Drawing.Point(429, 113);
            this.textBox03.Name = "textBox03";
            this.textBox03.Size = new System.Drawing.Size(69, 20);
            this.textBox03.TabIndex = 4;
            this.textBox03.Tag = "double";
            // 
            // textBox54
            // 
            this.textBox54.Location = new System.Drawing.Point(522, 325);
            this.textBox54.Name = "textBox54";
            this.textBox54.Size = new System.Drawing.Size(69, 20);
            this.textBox54.TabIndex = 29;
            this.textBox54.Tag = "int";
            // 
            // textBox44
            // 
            this.textBox44.Location = new System.Drawing.Point(522, 265);
            this.textBox44.Name = "textBox44";
            this.textBox44.Size = new System.Drawing.Size(69, 20);
            this.textBox44.TabIndex = 25;
            this.textBox44.Tag = "double";
            // 
            // textBox34
            // 
            this.textBox34.Location = new System.Drawing.Point(522, 226);
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new System.Drawing.Size(69, 20);
            this.textBox34.TabIndex = 20;
            this.textBox34.Tag = "double";
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(522, 187);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(69, 20);
            this.textBox24.TabIndex = 15;
            this.textBox24.Tag = "double";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(522, 150);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(69, 20);
            this.textBox14.TabIndex = 10;
            this.textBox14.Tag = "double";
            // 
            // textBox04
            // 
            this.textBox04.Location = new System.Drawing.Point(522, 113);
            this.textBox04.Name = "textBox04";
            this.textBox04.Size = new System.Drawing.Size(69, 20);
            this.textBox04.TabIndex = 5;
            this.textBox04.Tag = "double";
            // 
            // DefaultData
            // 
            this.DefaultData.Location = new System.Drawing.Point(646, 104);
            this.DefaultData.Name = "DefaultData";
            this.DefaultData.Size = new System.Drawing.Size(87, 54);
            this.DefaultData.TabIndex = 36;
            this.DefaultData.Text = "Вставить исходные данные";
            this.DefaultData.UseVisualStyleBackColor = true;
            this.DefaultData.Click += new System.EventHandler(this.DefaultData_Click);
            // 
            // FindSolution
            // 
            this.FindSolution.Location = new System.Drawing.Point(646, 164);
            this.FindSolution.Name = "FindSolution";
            this.FindSolution.Size = new System.Drawing.Size(87, 38);
            this.FindSolution.TabIndex = 34;
            this.FindSolution.Text = "Найти решение";
            this.FindSolution.UseVisualStyleBackColor = true;
            this.FindSolution.Click += new System.EventHandler(this.FindSolution_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(29, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 65;
            this.label1.Text = "Количество тракторов";
            // 
            // TAmount4
            // 
            this.TAmount4.Location = new System.Drawing.Point(522, 360);
            this.TAmount4.Name = "TAmount4";
            this.TAmount4.Size = new System.Drawing.Size(69, 20);
            this.TAmount4.TabIndex = 33;
            this.TAmount4.Tag = "int";
            // 
            // TAmount3
            // 
            this.TAmount3.Location = new System.Drawing.Point(429, 360);
            this.TAmount3.Name = "TAmount3";
            this.TAmount3.Size = new System.Drawing.Size(69, 20);
            this.TAmount3.TabIndex = 32;
            this.TAmount3.Tag = "int";
            // 
            // TAmount2
            // 
            this.TAmount2.Location = new System.Drawing.Point(334, 360);
            this.TAmount2.Name = "TAmount2";
            this.TAmount2.Size = new System.Drawing.Size(69, 20);
            this.TAmount2.TabIndex = 31;
            this.TAmount2.Tag = "int";
            // 
            // TAmount1
            // 
            this.TAmount1.Location = new System.Drawing.Point(237, 360);
            this.TAmount1.Name = "TAmount1";
            this.TAmount1.Size = new System.Drawing.Size(69, 20);
            this.TAmount1.TabIndex = 30;
            this.TAmount1.Tag = "int";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(646, 342);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(87, 38);
            this.Clear.TabIndex = 35;
            this.Clear.Text = "Очистить";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(29, 410);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 71;
            this.label2.Text = "Итоговая сумма:";
            // 
            // resultSum
            // 
            this.resultSum.Location = new System.Drawing.Point(237, 407);
            this.resultSum.Name = "resultSum";
            this.resultSum.ReadOnly = true;
            this.resultSum.Size = new System.Drawing.Size(69, 20);
            this.resultSum.TabIndex = 72;
            this.resultSum.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(818, 489);
            this.Controls.Add(this.resultSum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.TAmount4);
            this.Controls.Add(this.TAmount3);
            this.Controls.Add(this.TAmount2);
            this.Controls.Add(this.TAmount1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FindSolution);
            this.Controls.Add(this.DefaultData);
            this.Controls.Add(this.textBox54);
            this.Controls.Add(this.textBox44);
            this.Controls.Add(this.textBox34);
            this.Controls.Add(this.textBox24);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox04);
            this.Controls.Add(this.textBox53);
            this.Controls.Add(this.textBox43);
            this.Controls.Add(this.textBox33);
            this.Controls.Add(this.textBox23);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox03);
            this.Controls.Add(this.textBox52);
            this.Controls.Add(this.textBox42);
            this.Controls.Add(this.textBox32);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox02);
            this.Controls.Add(this.textBox51);
            this.Controls.Add(this.textBox41);
            this.Controls.Add(this.textBox31);
            this.Controls.Add(this.textBox21);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox01);
            this.Controls.Add(this.textBox40);
            this.Controls.Add(this.textBox30);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox00);
            this.Controls.Add(this.Brand4);
            this.Controls.Add(this.Brand3);
            this.Controls.Add(this.Brand2);
            this.Controls.Add(this.Brand1);
            this.Controls.Add(this.SeasonalRate);
            this.Controls.Add(this.Work4);
            this.Controls.Add(this.Work3);
            this.Controls.Add(this.Work5);
            this.Controls.Add(this.Work2);
            this.Controls.Add(this.Work1);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.Workload);
            this.Controls.Add(this.WorkType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WorkType;
        private System.Windows.Forms.Label Workload;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label Work1;
        private System.Windows.Forms.Label Work2;
        private System.Windows.Forms.Label Work5;
        private System.Windows.Forms.Label Work3;
        private System.Windows.Forms.Label Work4;
        private System.Windows.Forms.Label SeasonalRate;
        private System.Windows.Forms.Label Brand1;
        private System.Windows.Forms.Label Brand2;
        private System.Windows.Forms.Label Brand3;
        private System.Windows.Forms.Label Brand4;
        private System.Windows.Forms.TextBox textBox00;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox30;
        private System.Windows.Forms.TextBox textBox40;
        private System.Windows.Forms.TextBox textBox41;
        private System.Windows.Forms.TextBox textBox31;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox01;
        private System.Windows.Forms.TextBox textBox51;
        private System.Windows.Forms.TextBox textBox52;
        private System.Windows.Forms.TextBox textBox42;
        private System.Windows.Forms.TextBox textBox32;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox02;
        private System.Windows.Forms.TextBox textBox53;
        private System.Windows.Forms.TextBox textBox43;
        private System.Windows.Forms.TextBox textBox33;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox03;
        private System.Windows.Forms.TextBox textBox54;
        private System.Windows.Forms.TextBox textBox44;
        private System.Windows.Forms.TextBox textBox34;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox04;
        private Button DefaultData;
        private Button FindSolution;
        private Label label1;
        private TextBox TAmount4;
        private TextBox TAmount3;
        private TextBox TAmount2;
        private TextBox TAmount1;
        private Button Clear;
        private Label label2;
        private TextBox resultSum;
        private ErrorProvider errorProvider1;
    }
}

