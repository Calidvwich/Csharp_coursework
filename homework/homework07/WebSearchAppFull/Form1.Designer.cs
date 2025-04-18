namespace WebSearchApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBaidu;
        private System.Windows.Forms.TextBox txtBing;
        private System.Windows.Forms.Button btnCopyBaidu;
        private System.Windows.Forms.Button btnCopyBing;
        private System.Windows.Forms.Button btnClear;

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
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBaidu = new System.Windows.Forms.TextBox();
            this.txtBing = new System.Windows.Forms.TextBox();
            this.btnCopyBaidu = new System.Windows.Forms.Button();
            this.btnCopyBing = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(12, 12);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(400, 23);
            this.txtKeyword.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(420, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBaidu
            // 
            this.txtBaidu.Location = new System.Drawing.Point(12, 50);
            this.txtBaidu.Multiline = true;
            this.txtBaidu.Name = "txtBaidu";
            this.txtBaidu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBaidu.Size = new System.Drawing.Size(483, 100);
            this.txtBaidu.TabIndex = 2;
            // 
            // txtBing
            // 
            this.txtBing.Location = new System.Drawing.Point(12, 170);
            this.txtBing.Multiline = true;
            this.txtBing.Name = "txtBing";
            this.txtBing.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBing.Size = new System.Drawing.Size(483, 100);
            this.txtBing.TabIndex = 3;
            // 
            // btnCopyBaidu
            // 
            this.btnCopyBaidu.Location = new System.Drawing.Point(500, 50);
            this.btnCopyBaidu.Name = "btnCopyBaidu";
            this.btnCopyBaidu.Size = new System.Drawing.Size(75, 23);
            this.btnCopyBaidu.TabIndex = 4;
            this.btnCopyBaidu.Text = "复制百度";
            this.btnCopyBaidu.UseVisualStyleBackColor = true;
            this.btnCopyBaidu.Click += new System.EventHandler(this.btnCopyBaidu_Click);
            // 
            // btnCopyBing
            // 
            this.btnCopyBing.Location = new System.Drawing.Point(500, 170);
            this.btnCopyBing.Name = "btnCopyBing";
            this.btnCopyBing.Size = new System.Drawing.Size(75, 23);
            this.btnCopyBing.TabIndex = 5;
            this.btnCopyBing.Text = "复制Bing";
            this.btnCopyBing.UseVisualStyleBackColor = true;
            this.btnCopyBing.Click += new System.EventHandler(this.btnCopyBing_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(500, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(584, 281);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCopyBing);
            this.Controls.Add(this.btnCopyBaidu);
            this.Controls.Add(this.txtBing);
            this.Controls.Add(this.txtBaidu);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtKeyword);
            this.Name = "Form1";
            this.Text = "搜索小工具";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
