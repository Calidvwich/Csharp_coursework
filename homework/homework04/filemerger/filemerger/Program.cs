using FileMergerApp;
using System;
using System.Windows.Forms;

namespace TextFileMergeApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());  // 启动 Form1 窗体
        }
    }
}
