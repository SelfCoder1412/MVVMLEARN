using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1.Controller
{
    class AsyncDemo
    {
        //private Task jjTask = null;
        internal void asyncStart()
        {
            //Main();
            Task t = SayHello();
            //TaskMethod(null);
            //var h = t.Status;

            //SayBye();
        }

        private void SayHello2()
        {
            var tf = new TaskFactory();
            Task t1 = new Task(TaskMethod, "using a task factory", TaskCreationOptions.LongRunning);
            t1.Start();
        }

        private void TaskMethod(object obj)
        {
            Thread t = new Thread(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    Console.WriteLine("Hello" + i);
                    //Task.Delay(100).Wait();
                }
            });
            t.IsBackground = true; //by default it will be foreground. so don't need this line in your case
            t.Start();
        }

        public async Task SayHello()
        {
            Task jjTask = Task.Run(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    //Dispatcher.Be
                    Console.WriteLine("Hello" + i);
                    //Task.Delay(100).Wait();
                }
            });
            
            await jjTask;
        }

        public static void SayBye()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Bye" + i);
                Task.Delay(100).Wait();
            }
        }

        private static readonly object _object = new object();

        private static void TestLock()
        {
            lock (_object)
            {
                Thread.Sleep(1000);
                Console.WriteLine(Environment.TickCount);
            }
        }

        private  void Main()
        {
            for (int i = 0; i < 5; i++)
            {
                ThreadStart start = TestLock;
                new Thread(start).Start();
            }

            Console.ReadLine();
        }

        //private static string Send(int id)
        //{
        //    Task<HttpResponseMessage> responseTask = client.GetAsync("aaaaa");
        //    string result = string.Empty;
        //    Task continuation = responseTask.ContinueWith(x => result = Print(x));
        //    continuation.Wait();
        //    return result;
        //}

        private static string Print(Task<HttpResponseMessage> httpTask)
        {
            Task<string> task = httpTask.Result.Content.ReadAsStringAsync();
            string result = string.Empty;
            Task continuation = task.ContinueWith(t =>
            {
                Console.WriteLine("Result: " + t.Result);
                result = t.Result;
            });
            continuation.Wait();
            return result;
        }
    }
}
