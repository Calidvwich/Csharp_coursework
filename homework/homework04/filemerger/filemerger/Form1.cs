using System;
using System.IO;
using System.Windows.Forms;

namespace FileMergerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 第一个文本文件路径
        private string file1Path;
        // 第二个文本文件路径
        private string file2Path;

        // 当点击第一个按钮时，选择第一个文件
        private void buttonSelectFile1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file1Path = openFileDialog.FileName;
                textBoxContent.AppendText($"已选择第一个文件：{file1Path}\r\n");
            }
        }

        // 当点击第二个按钮时，选择第二个文件
        private void buttonSelectFile2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file2Path = openFileDialog.FileName;
                textBoxContent.AppendText($"已选择第二个文件：{file2Path}\r\n");
            }
        }

        // 当点击合并按钮时，合并两个文件内容并写入新文件
        private void buttonMerge_Click(object sender, EventArgs e)
        {
            try
            {
                // 检查是否选择了文件
                if (string.IsNullOrEmpty(file1Path) || string.IsNullOrEmpty(file2Path))
                {
                    MessageBox.Show("请先选择两个文件！");
                    return;
                }

                // 获取当前执行文件所在的目录
                string appDirectory = Application.StartupPath;
                // 创建 Data 子目录（如果没有的话）
                string dataDirectory = Path.Combine(appDirectory, "Data");
                if (!Directory.Exists(dataDirectory))
                {
                    Directory.CreateDirectory(dataDirectory);
                }

                // 新文件的路径
                string newFilePath = Path.Combine(dataDirectory, "mergedFile.txt");

                // 读取两个文件的内容
                string file1Content = File.ReadAllText(file1Path);
                string file2Content = File.ReadAllText(file2Path);

                // 合并文件内容
                string mergedContent = file1Content + Environment.NewLine + file2Content;

                // 写入新文件
                File.WriteAllText(newFilePath, mergedContent);

                // 显示操作成功的提示
                MessageBox.Show("文件合并成功！新文件已保存在 ./bin/Debug/Data 目录下。");
            }
            catch (UnauthorizedAccessException ex)
            {
                // 权限错误
                MessageBox.Show($"权限错误: {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                // 文件未找到
                MessageBox.Show($"文件未找到: {ex.Message}");
            }
            catch (Exception ex)
            {
                // 其他错误
                MessageBox.Show($"发生错误: {ex.Message}");
            }
        }
    }
}
