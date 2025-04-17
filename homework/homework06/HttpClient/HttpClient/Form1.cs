using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WebInfoExtractor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btnFetch.Click += btnFetch_Click;
            btnReset.Click += btnReset_Click;
            btnCopy.Click += btnCopy_Click;
        }

        // 查询功能
        private async void btnFetch_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("请输入 URL！");
                return;
            }

            try
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    string html = await client.GetStringAsync(url);

                    string phonePattern = @"(?<!\d)(1[3-9]\d{9})(?!\d)";
                    string emailPattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";

                    var phones = Regex.Matches(html, phonePattern);
                    var emails = Regex.Matches(html, emailPattern);

                    txtResult.Clear();
                    txtResult.AppendText("📱 手机号:\r\n");
                    foreach (Match m in phones)
                        txtResult.AppendText(m.Value + "\r\n");

                    txtResult.AppendText("\r\n📧 邮箱:\r\n");
                    foreach (Match m in emails)
                        txtResult.AppendText(m.Value + "\r\n");

                    if (phones.Count == 0 && emails.Count == 0)
                        txtResult.AppendText("\r\n未找到任何手机号或邮箱。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("请求失败: " + ex.Message);
            }
        }

        // 重置功能
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUrl.Clear();
            txtResult.Clear();
        }

        // 复制功能
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtResult.Text))
            {
                Clipboard.SetText(txtResult.Text);
                MessageBox.Show("结果已复制到剪贴板！");
            }
            else
            {
                MessageBox.Show("没有内容可复制！");
            }
        }
    }
}
