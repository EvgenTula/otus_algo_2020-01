namespace WindowsFormsTrie
{
    partial class frmSuggest
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
            this.txtBoxSelection = new System.Windows.Forms.RichTextBox();
            this.txtStr = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBoxSelection
            // 
            this.txtBoxSelection.Location = new System.Drawing.Point(12, 68);
            this.txtBoxSelection.Name = "txtBoxSelection";
            this.txtBoxSelection.ReadOnly = true;
            this.txtBoxSelection.Size = new System.Drawing.Size(776, 240);
            this.txtBoxSelection.TabIndex = 1;
            this.txtBoxSelection.Text = "";
            // 
            // txtStr
            // 
            this.txtStr.Location = new System.Drawing.Point(12, 40);
            this.txtStr.Name = "txtStr";
            this.txtStr.Size = new System.Drawing.Size(776, 22);
            this.txtStr.TabIndex = 0;
            this.txtStr.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(118, 11);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(12, 12);
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(100, 22);
            this.txtCount.TabIndex = 3;
            this.txtCount.Text = "0";
            // 
            // frmSuggest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 318);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtStr);
            this.Controls.Add(this.txtBoxSelection);
            this.Name = "frmSuggest";
            this.Text = "suggest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtBoxSelection;
        private System.Windows.Forms.TextBox txtStr;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtCount;
    }
}

