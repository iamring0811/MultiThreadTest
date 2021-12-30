using System;
using System.Timers;
using System.Windows;
using System.Threading;
namespace MultiThreadTest
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        static DateTime executiveTime;
        public MainWindow()
        {
            InitializeComponent();
            Thread Autoconnect = new Thread(new ThreadStart(AutoConnect));
            Autoconnect.Start();
            Thread.Sleep(500);
            AutoConnect();
        }

        public void AutoConnect()
        {
            // 타이머 생성 및 시작
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1 * 1000; // 1초

            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            executiveTime = DateTime.Now;
            timer.Start();
        }
        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string outputTime;
            outputTime = (e.SignalTime- executiveTime).ToString();
            Console.WriteLine("{0} :{1} ", Thread.CurrentThread.ManagedThreadId, outputTime);
        }

    }
}
