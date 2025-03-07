using System;

public class AlarmClock
{
    private System.Timers.Timer timer; // 解决 CS0104 问题
    public event EventHandler Tick;
    public event EventHandler Alarm;

    private DateTime? alarmTime;

    public AlarmClock()
    {
        timer = new System.Timers.Timer(1000); // 每秒触发一次
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

    private void OnTick(object sender, System.Timers.ElapsedEventArgs e)
    {
        Tick?.Invoke(this, EventArgs.Empty);
        Console.WriteLine($"当前时间：{DateTime.Now:HH:mm:ss}");

        if (alarmTime.HasValue && DateTime.Now >= alarmTime.Value)
        {
            Alarm?.Invoke(this, EventArgs.Empty);
            Stop(); // 闹钟响后自动停止
        }
    }
}
