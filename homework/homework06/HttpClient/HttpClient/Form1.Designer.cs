using System.Drawing;
using System.Windows.Forms;

namespace WebInfoExtractor
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnFetch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(231, 121);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(1159, 38);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "输入URL";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(231, 336);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(1145, 76);
            this.txtResult.TabIndex = 1;
            this.txtResult.Text = "查询到的信息：";
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(231, 673);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(227, 103);
            this.btnFetch.TabIndex = 2;
            this.btnFetch.Text = "查询";
            this.btnFetch.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(717, 673);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(227, 103);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(1149, 673);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(227, 103);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "复制到剪贴板";
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1614, 925);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnFetch);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtUrl);
            this.Name = "Form1";
            this.Text = "Web Info Extractor";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCopy;
    }
}
