using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDoc = HtmlAgilityPack.HtmlDocument;

namespace WebSearchApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text;
            if (string.IsNullOrWhiteSpace(keyword)) return;

            string baiduUrl = $"https://www.baidu.com/s?wd={Uri.EscapeDataString(keyword)}";
            string bingUrl = $"https://www.bing.com/search?q={Uri.EscapeDataString(keyword)}";

            var baiduTask = GetSearchResultAsync(baiduUrl);
            var bingTask = GetSearchResultAsync(bingUrl);

            txtBaidu.Text = await baiduTask;
            txtBing.Text = await bingTask;
        }

        private async Task<string> GetSearchResultAsync(string url)
        {
            using HttpClient client = new HttpClient();
            try
            {
                string html = await client.GetStringAsync(url);
                var doc = new HtmlDoc();
                doc.LoadHtml(html);
                var text = doc.DocumentNode.InnerText;
                return text.Length > 200 ? text.Substring(0, 200) : text;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private void btnCopyBaidu_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtBaidu.Text);
        }

        private void btnCopyBing_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtBing.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            txtBaidu.Clear();
            txtBing.Clear();
        }
    }
}
