using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal static class TaskTest
    {
        public static async void Test()
        {
            var print_task = new Task(PrintAction);         

            print_task.Start();
            Console.WriteLine("Задача запущена... Ожидание...");
            //print_task.Wait();

            //var sum_task = new Task<int>(() => Sum(30));
            //sum_task.Start();
            //Console.WriteLine("Задача вычисления суммы запущена... Ожидание результата...");

            //var result = sum_task.Result;
            //Console.WriteLine("Результат выполнения {0}", result);

            //var max = 30;
            //var sum_task2 = Task.Run(() => Sum(max));
            //Console.WriteLine("Задача вычисления суммы запущена... Ожидание результата...");
            //var result2 = sum_task2.Result;
            //Console.WriteLine("Результат выполнения {0}", result2);

            //var max2 = 20;
            //var sum_task3 = Task.Factory.StartNew(p => Sum((int)p), max2);

            //var sum_task3_continuation = sum_task3
            //    .ContinueWith(t =>
            //    {
            //        Thread.Sleep(1500);
            //        Console.WriteLine("Результат выолнения третей задачи {0}", t.Result);
            //    });

            //sum_task3_continuation.ContinueWith(t => Console.WriteLine("Теперь точно закончили работу с этой задачей"));

            ////var result = sum_task3.Result;

            ////var result = await sum_task3;

            //Task.Delay()
            //Task.WaitAll();
            //Task.WaitAny();

            //var completion_task = Task.WhenAll();
            //var completion_task = Task.WhenAny();

            #region Грабли с замыканием

            //var delegates = new Func<int>[10];
            //for (var i = 0; i < delegates.Length; i++)
            //{
            //    var i0 = i;
            //    delegates[i] = () => (i0 + 1) * 10;
            //    //delegates[i] = () => (i + 1) * 10;
            //}

            //var delegates_result = delegates.Select(d => d()).ToArray(); 

            #endregion

            var tasks = new List<Task<int>>();
            for (var i = 0; i < 10; i++)
            {
                //tasks.Add(Task.Run(() => i * 10)); // Грабли...
                var max = i;
                tasks.Add(Task.Run(() => max * 10));
            }

            var whait_task = Task.WhenAll(tasks.ToArray());

            var result = (await whait_task).Sum();

        }

        private static void PrintAction()
        {
            Console.WriteLine("Action in thread id:{0} started", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(500);
            Console.WriteLine("Action in thread id:{0} finished", Thread.CurrentThread.ManagedThreadId);
            //throw new Exception();
        }

        private static int Sum(int Max)
        {
            var result = 0;
            for (var i = 1; i <= Max; i++)
            {
                Thread.Sleep(100);
                result += i;
            }
            return result;
        }
    }
}
