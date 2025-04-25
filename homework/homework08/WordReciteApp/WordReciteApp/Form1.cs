using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WordReciteApp
{
    public partial class Form1 : Form
    {
        private List<(string English, string Chinese)> wordList = new List<(string, string)>();
        private int currentIndex = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadWordsFromDatabase();
            ShuffleWords();  // 随机打乱顺序
            ShowCurrentWord();
        }

        // 初始化数据库
        private void InitializeDatabase()
        {
            if (File.Exists("words.db")) return;

            SQLiteConnection.CreateFile("words.db");
            using (var conn = new SQLiteConnection("Data Source=words.db"))
            {
                conn.Open();
                string createTable = "CREATE TABLE words (id INTEGER PRIMARY KEY AUTOINCREMENT, english TEXT NOT NULL, chinese TEXT NOT NULL);";
                using (var cmd = new SQLiteCommand(createTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                string[] words = new string[] {
                    "apple|苹果", "banana|香蕉", "cat|猫", "dog|狗", "egg|鸡蛋",
                    "fly|飞", "grape|葡萄", "halo|光环", "index|索引", "judge|法官",
                    "kinetic|动力的", "log|日志"
                };

                foreach (var item in words)
                {
                    var parts = item.Split('|');
                    var cmd = new SQLiteCommand("INSERT INTO words (english, chinese) VALUES (@e, @c)", conn);
                    cmd.Parameters.AddWithValue("@e", parts[0]);
                    cmd.Parameters.AddWithValue("@c", parts[1]);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 从数据库加载单词
        private void LoadWordsFromDatabase()
        {
            string dbPath = "Data Source=words.db;";
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.Open();
                string query = "SELECT English, Chinese FROM words";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    wordList.Add((reader.GetString(0), reader.GetString(1)));
                }
            }
        }

        // 随机打乱单词顺序
        private void ShuffleWords()
        {
            Random rand = new Random();
            wordList = wordList.OrderBy(x => rand.Next()).ToList();
        }

        // 显示当前单词
        private void ShowCurrentWord()
        {
            if (currentIndex < wordList.Count)
            {
                labelChinese.Text = wordList[currentIndex].Chinese;
                textBoxEnglish.Text = "";
                labelResult.Text = "";
                textBoxEnglish.Enabled = true;
                buttonNext.Enabled = false;  // 禁用“下一个”按钮

                textBoxEnglish.Focus();
            }
            else
            {
                labelChinese.Text = "背完啦！";
                textBoxEnglish.Enabled = false;
                labelResult.Text = "";
                buttonNext.Enabled = false;  // 禁用“下一个”按钮
            }
        }

        // 按下回车时检查用户输入
        private void textBoxEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && currentIndex < wordList.Count)
            {
                string userInput = textBoxEnglish.Text.Trim().ToLower();
                string correctAnswer = wordList[currentIndex].English.ToLower();

                if (userInput == correctAnswer)
                {
                    labelResult.Text = "✅ 正确";
                    labelResult.ForeColor = System.Drawing.Color.Green;
                    currentIndex++;
                }
                else
                {
                    labelResult.Text = $"❌ 错误，正确是：{correctAnswer}";
                    labelResult.ForeColor = System.Drawing.Color.Red;
                    return;  // 错误时不切换到下一个单词
                }

                // 使用计时器延迟切换单词
                Timer t = new Timer();
                t.Interval = 1000;
                t.Tick += (s, ev) =>
                {
                    t.Stop();
                    ShowCurrentWord();
                };
                t.Start();
            }
        }

        // 点击“下一个”按钮时显示下一个单词
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEnglish.Text)) return;  // 如果没有输入，不能点击“下一个”

            currentIndex++;
            ShowCurrentWord();
        }

        // 点击“清除”按钮时清空输入框
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxEnglish.Text = "";
            labelResult.Text = "";
            textBoxEnglish.Focus();
        }
    }
}
