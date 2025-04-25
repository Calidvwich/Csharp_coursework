
namespace WordReciteApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelChinese;
        private System.Windows.Forms.TextBox textBoxEnglish;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelChinese = new System.Windows.Forms.Label();
            this.textBoxEnglish = new System.Windows.Forms.TextBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelChinese
            // 
            this.labelChinese.AutoSize = true;
            this.labelChinese.Font = new System.Drawing.Font("Microsoft YaHei", 14F);
            this.labelChinese.Location = new System.Drawing.Point(30, 30);
            this.labelChinese.Name = "labelChinese";
            this.labelChinese.Size = new System.Drawing.Size(140, 25);
            this.labelChinese.TabIndex = 0;
            this.labelChinese.Text = "中文词义显示";
            // 
            // textBoxEnglish
            // 
            this.textBoxEnglish.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.textBoxEnglish.Location = new System.Drawing.Point(35, 70);
            this.textBoxEnglish.Name = "textBoxEnglish";
            this.textBoxEnglish.Size = new System.Drawing.Size(250, 29);
            this.textBoxEnglish.TabIndex = 1;
            this.textBoxEnglish.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxEnglish_KeyDown);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.labelResult.Location = new System.Drawing.Point(35, 110);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(90, 21);
            this.labelResult.TabIndex = 2;
            this.labelResult.Text = "结果显示区";
            // 
            // buttonNext
            // 
            this.buttonNext.Font = new System.Drawing.Font("Microsoft YaHei", 10F);
            this.buttonNext.Location = new System.Drawing.Point(35, 150);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(100, 35);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "下一个";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft YaHei", 10F);
            this.buttonClear.Location = new System.Drawing.Point(185, 150);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(100, 35);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "清除";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 220);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.textBoxEnglish);
            this.Controls.Add(this.labelChinese);
            this.Name = "Form1";
            this.Text = "背单词小程序";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
