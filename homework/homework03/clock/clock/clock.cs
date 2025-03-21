using System;
using System.Diagnostics;
using System.Timers;
using System.Threading;

public class AlarmClock
{
    private System.Timers.Timer timer; // 使用 System.Timers.Timer 解决歧义
    public event EventHandler Tick;
    public event EventHandler Alarm;

    private DateTime? alarmTime;

    public AlarmClock()
    {
        timer = new System.Timers.Timer(1000); // 每秒触发
        timer.Elapsed += OnTick;
    }

    public void SetAlarm(DateTime time)
    {
        if (time < DateTime.Now)
        {
            throw new ArgumentException("闹钟时间不能设置为过去的时间！");
        }
        alarmTime = time;
        Console.WriteLine($"闹钟已设置：{time:HH:mm:ss}");
    }

    public void Start()
    {
        timer.Start();
        Console.WriteLine("闹钟已启动...");
    }

    public void Stop()
    {
        timer.Stop();
        Console.WriteLine("闹钟已停止...");
    }

    private void OnTick(object sender, ElapsedEventArgs e)
    {
        Tick?.Invoke(this, EventArgs.Empty);
        Console.WriteLine($"当前时间：{DateTime.Now:HH:mm:ss}");

        if (alarmTime.HasValue && DateTime.Now >= alarmTime.Value)
        {
            Alarm?.Invoke(this, EventArgs.Empty);
            Console.WriteLine("时间到了！");

            Console.Beep(); // 播放系统蜂鸣声
            Stop(); // 闹钟响后自动停止
        }
    }

    public static void StartBackgroundProcess()
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = Process.GetCurrentProcess().MainModule.FileName, // 重新启动自己
            Arguments = "background", // 让新进程知道自己是后台模式
            CreateNoWindow = true, // 不创建窗口
            UseShellExecute = true, // 使进程独立于当前控制台
            WindowStyle = ProcessWindowStyle.Hidden // 隐藏窗口
        };
        Process.Start(psi);
        Console.WriteLine("闹钟已在后台运行！");
    }
}
