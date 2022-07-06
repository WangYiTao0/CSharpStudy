using System;
using System.Threading;

namespace _08_MultiThread
{
    internal class Program
    {
        private static bool isRuning = true;
        private static object obj = new object();
        public static void Main(string[] args)
        {
            //声明一个对象
            //线程执行的代码 需要封装到一个函数中
            //新线程 将要执行的代码逻辑 被封装到了一个函数语句块中
            Thread t = new Thread(NewThreadLogic);
            //2.启动线程
            t.Start();
            //3.设置为后台线程 
            t.IsBackground = true;
            //4.关闭释放一个线程
            Console.ReadKey();
            isRuning = false;

            Console.ReadKey();
            try
            {
                t.Abort();
                t = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            //5. 线程休眠
            Thread.Sleep(1000);

          
            // Lock 会影响线程之间的效率
            while(true)
            {
             
                lock(obj)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("●");
                }
            }
        }
        
        static void NewThreadLogic()
        {
            //同时访问同一个数据时
            
            //新开线程 执行的代码逻辑 在该函数语句块中
            while(isRuning)
            {
                Thread.Sleep(1000);
                Console.WriteLine("new Thread ");
                lock(obj)  //执行到 check obj 有没有被锁
                {
                    Console.SetCursorPosition(10, 5);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("■");
                }
            }
        }
    }
}