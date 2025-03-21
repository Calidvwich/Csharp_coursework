namespace FileMergerApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonSelectFile1;
        private System.Windows.Forms.Button buttonSelectFile2;
        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.Button buttonMerge;

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
            this.buttonSelectFile1 = new System.Windows.Forms.Button();
            this.buttonSelectFile2 = new System.Windows.Forms.Button();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.buttonMerge = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // buttonSelectFile1
            // 
            this.buttonSelectFile1.Location = new System.Drawing.Point(12, 12);
            this.buttonSelectFile1.Name = "buttonSelectFile1";
            this.buttonSelectFile1.Size = new System.Drawing.Size(100, 23);
            this.buttonSelectFile1.TabIndex = 0;
            this.buttonSelectFile1.Text = "选择文件 1";
            this.buttonSelectFile1.UseVisualStyleBackColor = true;
            this.buttonSelectFile1.Click += new System.EventHandler(this.buttonSelectFile1_Click);

            // 
            // buttonSelectFile2
            // 
            this.buttonSelectFile2.Location = new System.Drawing.Point(12, 41);
            this.buttonSelectFile2.Name = "buttonSelectFile2";
            this.buttonSelectFile2.Size = new System.Drawing.Size(100, 23);
            this.buttonSelectFile2.TabIndex = 1;
            this.buttonSelectFile2.Text = "选择文件 2";
            this.buttonSelectFile2.UseVisualStyleBackColor = true;
            this.buttonSelectFile2.Click += new System.EventHandler(this.buttonSelectFile2_Click);

            // 
            // textBoxContent
            // 
            this.textBoxContent.Location = new System.Drawing.Point(12, 70);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(360, 150);
            this.textBoxContent.TabIndex = 2;

            // 
            // buttonMerge
            // 
            this.buttonMerge.Location = new System.Drawing.Point(12, 226);
            this.buttonMerge.Name = "buttonMerge";
            this.buttonMerge.Size = new System.Drawing.Size(100, 23);
            this.buttonMerge.TabIndex = 3;
            this.buttonMerge.Text = "合并文件";
            this.buttonMerge.UseVisualStyleBackColor = true;
            this.buttonMerge.Click += new System.EventHandler(this.buttonMerge_Click);

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.buttonMerge);
            this.Controls.Add(this.textBoxContent);
            this.Controls.Add(this.buttonSelectFile2);
            this.Controls.Add(this.buttonSelectFile1);
            this.Name = "Form1";
            this.Text = "文件合并程序";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
