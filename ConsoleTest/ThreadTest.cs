using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace ConsoleTest
{
    internal static class ThreadTest
    {
        public static void Test()
        {
            ////Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.AboveNormal;
            ////var thread = new Thread(new ThreadStart(ConsoleTitleTimer));   
            //var time_thread = new Thread(ConsoleTitleTimer)
            //{
            //    Priority = ThreadPriority.BelowNormal,
            //    IsBackground = true
            //};
            //time_thread.Start();

            //var printer_thread = new Thread(Printer)
            //{
            //    IsBackground = true
            //};
            //printer_thread.Start("Hello World!");

            //Console.WriteLine("Главный поток ждёт printer_thread");
            ////printer_thread.Join();

            //if (!printer_thread.Join(500))
            //{
            //    printer_thread.Abort();
            //    //printer_thread.Interrupt();
            //}

            //Console.WriteLine("Главный поток продолжает работу");

            //Console.Clear();

            //printer_thread = new Thread(() => Printer("thr1", 50, 0)) { Name = "Thread 1"};
            //printer_thread.Start();

            //new Thread(() => Printer("thr1", 50, 0)) { Name = "Thread 2" }.Start();

            //Console.ReadLine();
            //Console.Clear();

            //for (var i = 0; i < 5; i++)
            //{
            //    new Thread(DigitPrinter).Start();
            //}

            //lock (__SyncRoot)
            //{
            //  Критическая секция
            //}

            //Monitor.Enter(__SyncRoot);
            //try
            //{
            //   // Критическая секция
            //}
            //finally
            //{
            //    if(Monitor.IsEntered(__SyncRoot))
            //        Monitor.Exit(__SyncRoot);
            //}

            //Mutex mutex = new Mutex(true, "Имя мютекса");
            //mutex.WaitOne();
            //mutex.ReleaseMutex();

            //var semaphore = new Semaphore(5, 5);
            //#region Код потока
            //{
            //    semaphore.WaitOne();
            //    // Критическая секция
            //    semaphore.Release();
            //} 
            //#endregion

            //ManualResetEvent manual_reset_event = new ManualResetEvent(false);
            //AutoResetEvent auto_reset_event = new AutoResetEvent(false);

            //manual_reset_event.WaitOne();
            //manual_reset_event.Reset();

            //var timer = new Timer(
            //    o => Console.WriteLine("Timer parameter {0}", o), 
            //    "Hello World!", 700, 300);
            ////timer.Change()

            var data = Enumerable.Range(0, 100).Select(i => $"Message {i}").ToArray();

            //ThreadPool.SetMinThreads(3, 3);
            //ThreadPool.SetMaxThreads(15, 15);
            //foreach (var str in data)
            //{
            //    //ThreadPool.QueueUserWorkItem(ProcessMessage, str);
            //    //ThreadPool.QueueUserWorkItem(o => Console.WriteLine(o), str);
            //    ThreadPool.QueueUserWorkItem(Console.WriteLine, str);
            //}

            var func = new Func<string, int>(CharCount);
            foreach (var msg in data)
            {
                #region Синхронный вызов делегата

                //func(msg);
                //func.Invoke(msg); 

                #endregion

                func.BeginInvoke(msg, CaptureResult, func);
            }
        }

        private static void CaptureResult(IAsyncResult result)
        {
            var func = (Func<string, int>)result.AsyncState;
            var count = func.EndInvoke(result);
            Console.WriteLine("Количество символов: {0}", count);
        }

        private static int CharCount(string msg)
        {
            Thread.Sleep(500);
            return msg.Length;
        }

        private static void ProcessMessage(object parameter)
        {
            var msg = (string)parameter;
            Console.WriteLine("{0}({1}):{2}",
                Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId, msg);
        }

        private static readonly object __SyncRoot = new object();

        private static void DigitPrinter()
        {
            lock (__SyncRoot)
            {
                Console.Write("{0}({1}):", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId);
                for (var i = 0; i < 20; i++)
                {
                    Console.Write("{0},", i);
                    Thread.Sleep(1);
                }

                Console.WriteLine("40");
            }
        }

        private static void ConsoleTitleTimer()
        {
            while (true)
            {
                Console.Title = DateTime.Now.ToString("hh:mm:ss.fff");
                Thread.Sleep(100);
            }
        }

        private static void Printer(object parameter)
        {
            try
            {
                var str = (string)parameter;
                for (var i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("{0}\t{1}", str, i);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void Printer(string str, int count, int sleep = 100)
        {
            try
            {
                for (var i = 0; i < count; i++)
                {
                    if (sleep > 0) Thread.Sleep(sleep);
                    Console.Write("{0}({1})\t",
                        Thread.CurrentThread.Name,
                        Thread.CurrentThread.ManagedThreadId);
                    Console.Write(str);
                    Console.WriteLine("\t{0}", i);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    [Synchronization]
    internal class FileLogger : ContextBoundObject
    {
        private readonly string _FileName;

        public FileLogger(string FileName) => _FileName = FileName;

        public void Log(string message)
        {
            File.AppendAllText(_FileName, message);
        }
    }

    internal class FileLogger2 : ContextBoundObject
    {
        private readonly string _FileName;

        public FileLogger2(string FileName) => _FileName = FileName;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Log(string message)
        {
            File.AppendAllText(_FileName, message);
        }

        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void Log2(string message)
        {
            lock (this)
            {
                File.AppendAllText(_FileName, message);
            }
        }
    }
}
