﻿namespace NumericalMethods
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Count = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.решитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.методомГауссаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заполнитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.Precision = new System.Windows.Forms.TextBox();
            this.методомПрогонкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(303, 243);
            this.dataGridView1.TabIndex = 1;
            // 
            // Count
            // 
            this.Count.Location = new System.Drawing.Point(496, 44);
            this.Count.MaxLength = 2;
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(100, 20);
            this.Count.TabIndex = 2;
            this.Count.TextChanged += new System.EventHandler(this.Count_TextChanged);
            this.Count.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Count_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(493, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Количество неизвестных величин в системе:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView2.Location = new System.Drawing.Point(321, 28);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(80, 243);
            this.dataGridView2.TabIndex = 18;
            // 
            // Column1
            // 
            dataGridViewCellStyle1.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "y";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.Width = 200;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dataGridView3.Location = new System.Drawing.Point(407, 27);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.Size = new System.Drawing.Size(80, 243);
            this.dataGridView3.TabIndex = 19;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "x";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.решитьToolStripMenuItem,
            this.заполнитьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // решитьToolStripMenuItem
            // 
            this.решитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.методомГауссаToolStripMenuItem,
            this.методомПрогонкиToolStripMenuItem});
            this.решитьToolStripMenuItem.Name = "решитьToolStripMenuItem";
            this.решитьToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.решитьToolStripMenuItem.Text = "Решить";
            // 
            // методомГауссаToolStripMenuItem
            // 
            this.методомГауссаToolStripMenuItem.Name = "методомГауссаToolStripMenuItem";
            this.методомГауссаToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.методомГауссаToolStripMenuItem.Text = "Методом Гаусса";
            this.методомГауссаToolStripMenuItem.Click += new System.EventHandler(this.методомГауссаToolStripMenuItem_Click);
            // 
            // заполнитьToolStripMenuItem
            // 
            this.заполнитьToolStripMenuItem.Name = "заполнитьToolStripMenuItem";
            this.заполнитьToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.заполнитьToolStripMenuItem.Text = "Заполнить";
            this.заполнитьToolStripMenuItem.Click += new System.EventHandler(this.заполнитьToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(493, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Количество знаков после запятой";
            // 
            // Precision
            // 
            this.Precision.Location = new System.Drawing.Point(496, 83);
            this.Precision.MaxLength = 2;
            this.Precision.Name = "Precision";
            this.Precision.Size = new System.Drawing.Size(100, 20);
            this.Precision.TabIndex = 22;
            // 
            // методомПрогонкиToolStripMenuItem
            // 
            this.методомПрогонкиToolStripMenuItem.Name = "методомПрогонкиToolStripMenuItem";
            this.методомПрогонкиToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.методомПрогонкиToolStripMenuItem.Text = "Методом прогонки";
            this.методомПрогонкиToolStripMenuItem.Click += new System.EventHandler(this.методомПрогонкиToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.Precision);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox Count;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem решитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem методомГауссаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заполнитьToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Precision;
        private System.Windows.Forms.ToolStripMenuItem методомПрогонкиToolStripMenuItem;
    }
}

