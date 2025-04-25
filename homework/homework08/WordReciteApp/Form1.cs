
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
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
            ShowCurrentWord();
        }

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

        private void ShowCurrentWord()
        {
            if (currentIndex < wordList.Count)
            {
                labelChinese.Text = wordList[currentIndex].Chinese;
                textBoxEnglish.Text = "";
                labelResult.Text = "";
                textBoxEnglish.Focus();
            }
            else
            {
                labelChinese.Text = "背完啦！";
                textBoxEnglish.Enabled = false;
                labelResult.Text = "";
            }
        }

        private void textBoxEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && currentIndex < wordList.Count)
            {
                string userInput = textBoxEnglish.Text.Trim().ToLower();
                string correctAnswer = wordList[currentIndex].English.ToLower();

                if (userInput == correctAnswer)
                    labelResult.Text = "✅ 正确";
                else
                    labelResult.Text = $"❌ 错误，正确是：{correctAnswer}";

                currentIndex++;

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

        private void buttonNext_Click(object sender, EventArgs e)
        {
            currentIndex++;
            ShowCurrentWord();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxEnglish.Text = "";
            labelResult.Text = "";
            textBoxEnglish.Focus();
        }
    }
}
