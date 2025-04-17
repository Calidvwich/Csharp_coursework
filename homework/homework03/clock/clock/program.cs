using System;
using System.Threading;

namespace MyAlarmApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                // 让进程在后台运行
                AlarmClock.StartBackgroundProcess();
                return;
            }

            AlarmClock clock = new AlarmClock();

            clock.Tick += (sender, e) =>
            {
                Console.WriteLine($"Tick: 当前时间是 {DateTime.Now:HH:mm:ss}");
            };

            clock.Alarm += (sender, e) =>
            {
                Console.WriteLine("时间到了！");
                Console.Beep(); // 播放系统蜂鸣声
            };

            try
            {
                Console.Write("请输入闹钟时间（格式 HH:mm:ss）：");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime alarmTime))
                {
                    // 修正 alarmTime，确保它带有当天日期
                    alarmTime = DateTime.Today.Add(alarmTime.TimeOfDay);

                    if (alarmTime < DateTime.Now)
                    {
                        // 如果用户输入的时间已经过去，自动调整到明天
                        alarmTime = alarmTime.AddDays(1);
                    }

                    clock.SetAlarm(alarmTime);
                    clock.Start();
                }
                else
                {
                    Console.WriteLine("输入格式错误");
                }

                // 让后台进程保持运行
                while (true) Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误：{ex.Message}");
            }
        }
    }
}
