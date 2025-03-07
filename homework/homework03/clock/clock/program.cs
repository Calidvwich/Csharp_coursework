using System;
using System.Threading;

namespace MyAlarmApp
{
    class Program
    {
        static void Main()
        {
            AlarmClock clock = new AlarmClock();

            clock.Tick += (sender, e) =>
            {
                // 这里打印每秒的时间
                Console.WriteLine($"Tick: 当前时间是 {DateTime.Now:HH:mm:ss}");
            };

            clock.Alarm += (sender, e) =>
            {
                // 触发响铃时打印提示信息
                Console.WriteLine("时间到了！");
                Console.Beep();  // 播放系统蜂鸣声
            };

            try
            {
                Console.Write("请输入闹钟时间（格式 HH:mm:ss）：");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime alarmTime))
                {
                    if (alarmTime < DateTime.Now)
                    {
                        Console.WriteLine("不能设置过去的时间");
                    }
                    else
                    {
                        clock.SetAlarm(alarmTime);  // 设置闹钟时间
                        clock.Start();               // 启动计时器
                    }
                }
                else
                {
                    Console.WriteLine("输入格式错误");
                }

                // 等待直到用户按下任意键，防止程序提前退出
                Console.WriteLine("按任意键退出程序...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误：{ex.Message}");
            }
        }
    }
}

