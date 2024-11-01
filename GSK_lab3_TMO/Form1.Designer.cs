namespace GSK_lab3_TMO
{
    partial class Form1
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
            this.pic_panel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.choice_figure = new System.Windows.Forms.ToolStripMenuItem();
            this.type_0 = new System.Windows.Forms.ToolStripMenuItem();
            this.type_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.type_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.другоеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.choice_TMO = new System.Windows.Forms.ToolStripMenuItem();
            this.Union = new System.Windows.Forms.ToolStripMenuItem();
            this.Intersection = new System.Windows.Forms.ToolStripMenuItem();
            this.SymmetricDifference = new System.Windows.Forms.ToolStripMenuItem();
            this.DifferenceAB = new System.Windows.Forms.ToolStripMenuItem();
            this.DifferenceBA = new System.Windows.Forms.ToolStripMenuItem();
            this.color_box = new System.Windows.Forms.ComboBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.pic_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic_panel
            // 
            this.pic_panel.Controls.Add(this.pictureBox1);
            this.pic_panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pic_panel.Location = new System.Drawing.Point(0, 33);
            this.pic_panel.Name = "pic_panel";
            this.pic_panel.Size = new System.Drawing.Size(869, 310);
            this.pic_panel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(869, 310);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.choice_figure,
            this.choice_TMO});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(869, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // choice_figure
            // 
            this.choice_figure.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.type_0,
            this.type_1,
            this.type_2,
            this.другоеToolStripMenuItem});
            this.choice_figure.Name = "choice_figure";
            this.choice_figure.Size = new System.Drawing.Size(114, 20);
            this.choice_figure.Text = "Выбор фигуры";
            // 
            // type_0
            // 
            this.type_0.Name = "type_0";
            this.type_0.Size = new System.Drawing.Size(168, 22);
            this.type_0.Text = "Треугольник";
            this.type_0.Click += new System.EventHandler(this.type_0_Click);
            // 
            // type_1
            // 
            this.type_1.Name = "type_1";
            this.type_1.Size = new System.Drawing.Size(168, 22);
            this.type_1.Text = "Прямоугльник";
            this.type_1.Click += new System.EventHandler(this.type_1_Click);
            // 
            // type_2
            // 
            this.type_2.Name = "type_2";
            this.type_2.Size = new System.Drawing.Size(168, 22);
            this.type_2.Text = "Круг";
            this.type_2.Click += new System.EventHandler(this.type_2_Click);
            // 
            // другоеToolStripMenuItem
            // 
            this.другоеToolStripMenuItem.Name = "другоеToolStripMenuItem";
            this.другоеToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.другоеToolStripMenuItem.Text = "Другое";
            this.другоеToolStripMenuItem.Click += new System.EventHandler(this.другоеToolStripMenuItem_Click);
            // 
            // choice_TMO
            // 
            this.choice_TMO.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Union,
            this.Intersection,
            this.SymmetricDifference,
            this.DifferenceAB,
            this.DifferenceBA});
            this.choice_TMO.Name = "choice_TMO";
            this.choice_TMO.Size = new System.Drawing.Size(94, 20);
            this.choice_TMO.Text = "Выбор ТМО";
            // 
            // Union
            // 
            this.Union.Name = "Union";
            this.Union.Size = new System.Drawing.Size(249, 22);
            this.Union.Text = "Объединение";
            this.Union.Click += new System.EventHandler(this.Union_Click);
            // 
            // Intersection
            // 
            this.Intersection.Name = "Intersection";
            this.Intersection.Size = new System.Drawing.Size(249, 22);
            this.Intersection.Text = "Пересечение";
            this.Intersection.Click += new System.EventHandler(this.Intersection_Click);
            // 
            // SymmetricDifference
            // 
            this.SymmetricDifference.Name = "SymmetricDifference";
            this.SymmetricDifference.Size = new System.Drawing.Size(249, 22);
            this.SymmetricDifference.Text = "Симметрическая разность";
            this.SymmetricDifference.Click += new System.EventHandler(this.SymmetricDifference_Click);
            // 
            // DifferenceAB
            // 
            this.DifferenceAB.Name = "DifferenceAB";
            this.DifferenceAB.Size = new System.Drawing.Size(249, 22);
            this.DifferenceAB.Text = "Разность A/B";
            this.DifferenceAB.Click += new System.EventHandler(this.DifferenceAB_Click);
            // 
            // DifferenceBA
            // 
            this.DifferenceBA.Name = "DifferenceBA";
            this.DifferenceBA.Size = new System.Drawing.Size(249, 22);
            this.DifferenceBA.Text = "Разность B/A";
            this.DifferenceBA.Click += new System.EventHandler(this.DifferenceBA_Click);
            // 
            // color_box
            // 
            this.color_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.color_box.FormattingEnabled = true;
            this.color_box.Items.AddRange(new object[] {
            "Чёрный",
            "Красный",
            "Зелёный",
            "Синий"});
            this.color_box.Location = new System.Drawing.Point(214, 367);
            this.color_box.Name = "color_box";
            this.color_box.Size = new System.Drawing.Size(133, 24);
            this.color_box.TabIndex = 2;
            this.color_box.Text = "Цвет рисования";
            this.color_box.SelectedIndexChanged += new System.EventHandler(this.color_box_SelectedIndexChanged);
            // 
            // btn_clear
            // 
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_clear.Location = new System.Drawing.Point(556, 361);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(112, 35);
            this.btn_clear.TabIndex = 3;
            this.btn_clear.Text = "Очистить";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 410);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.color_box);
            this.Controls.Add(this.pic_panel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.pic_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pic_panel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem choice_figure;
        private System.Windows.Forms.ToolStripMenuItem choice_TMO;
        private System.Windows.Forms.ComboBox color_box;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.ToolStripMenuItem type_0;
        private System.Windows.Forms.ToolStripMenuItem type_2;
        private System.Windows.Forms.ToolStripMenuItem другоеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Union;
        private System.Windows.Forms.ToolStripMenuItem Intersection;
        private System.Windows.Forms.ToolStripMenuItem SymmetricDifference;
        private System.Windows.Forms.ToolStripMenuItem DifferenceAB;
        private System.Windows.Forms.ToolStripMenuItem DifferenceBA;
        private System.Windows.Forms.ToolStripMenuItem type_1;
    }
}

