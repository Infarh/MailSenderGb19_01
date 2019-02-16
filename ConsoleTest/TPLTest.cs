using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal static class TPLTest
    {
        private struct Data
        {
            public int Count { get; set; }
            public string Message { get; set; }
        }

        public static void Test()
        {

            Parallel.Invoke(
                PrintAction,
                PrintAction,
                PrintAction,
                () => Console.WriteLine("Hello World!!!"));

            #region Parallel.For

            //Console.WriteLine("----------------------------------");

            //Parallel.For(1, 21, i => Console.WriteLine("Iteration {0}", i));

            //Console.WriteLine("----------------------------------");

            //var result = Parallel.For(0, 21/*, new ParallelOptions{  }*/, (i, state) =>
            //{
            //    if (i > 5)
            //        state.Break();
            //    Thread.Sleep(100);
            //    Console.WriteLine("Iteration {0}", i);
            //});

            //Console.WriteLine("Выполнено {0} итераций", result.LowestBreakIteration); 

            #endregion

            Console.WriteLine(new string('-', 30));

            var data = Enumerable.Range(1, 100).Select(i => $"Message {i}");

            #region Parallel.ForEach

            //Parallel.ForEach(data.Select(ProcessData), (d, state) =>
            //   {
            //       if (d.Message.EndsWith("5"))
            //           state.Break();
            //       Console.WriteLine("Thread: {0} -> msg:{1}({2})",
            //           Thread.CurrentThread.ManagedThreadId,
            //           d.Message, d.Count);
            //   }); 

            #endregion

            //var parallel_data = data.AsParallel();

            data.AsParallel()
                .WithDegreeOfParallelism(10)
                //.WithCancellation(CancellationToken.None)
                //.WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                //.WithMergeOptions(ParallelMergeOptions.AutoBuffered)
                .Select(msg => ProcessData(msg))
                .ForAll(d =>
                {
                    Console.WriteLine("Thread: {0} -> msg:{1}({2})",
                               Thread.CurrentThread.ManagedThreadId,
                               d.Message, d.Count);
                });

            //var parallel_data = data.AsParallel()
            //    .WithDegreeOfParallelism(10)
            //    //.WithCancellation(CancellationToken.None)
            //    //.WithExecutionMode(ParallelExecutionMode.ForceParallelism)
            //    //.WithMergeOptions(ParallelMergeOptions.AutoBuffered)
            //    .Select(msg => ProcessData(msg));

            //foreach (var d in parallel_data)
            //{
            //    Console.WriteLine("Thread: {0} -> msg:{1}({2})",
            //        Thread.CurrentThread.ManagedThreadId,
            //        d.Message, d.Count);
            //}

            //data.AsParallel()
            //    .WithDegreeOfParallelism(10)
            //    //.WithCancellation(CancellationToken.None)
            //    //.WithExecutionMode(ParallelExecutionMode.ForceParallelism)
            //    //.WithMergeOptions(ParallelMergeOptions.AutoBuffered)
            //    .Select(msg => ProcessData(msg))
            //    .AsOrdered()
            //    .AsEnumerable();

            Console.WriteLine("Продолжение выполнение основного потока");

        }

        private static void PrintAction()
        {
            Thread.Sleep(100);
            Console.WriteLine("Action in thread id:{0}", Thread.CurrentThread.ManagedThreadId);
        }

        private static Data ProcessData(string str)
        {
            Thread.Sleep(100);
            return new Data
            {
                Count = str.Length,
                Message = str
            };
        }

        private static int Sum(int Max)
        {
            var result = 0;
            for (var i = 1; i <= Max; i++)
                result += i;
            return result;
        }

        private static int Sum(int Min, int Max)
        {
            var result = 0;
            for (var i = Min; i <= Max; i++)
                result += i;
            return result;
        }

        private static int SumParallel(int Max, int BlockLength = 10)
        {
            object sync_root = new object();
            var sum = 0;
            Parallel.For(0, Max / BlockLength, block_n =>
            {
                var block_sum = 0;
                for (var i = block_n * BlockLength; i < (block_n + 1) * BlockLength; i++)
                    block_sum += i;
                lock (sync_root)
                    sum += block_sum;
            });
            return sum;
        }
    }
}
