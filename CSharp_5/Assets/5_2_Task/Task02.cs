using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace _5_2_Task
{
    public class Task02　: MonoBehaviour
    {
        // 知识点二 创建无返回值Task的三种方式
        bool _isRuning = true;
        private Task<float> _t3;
        private Task<string> _t2;
        private Task<int> _t1;

        private CancellationTokenSource _tokenSource;

        private void Start()
        {
            //CreateNoReturnTask();
            //CreateHasReturnTask();
            // 同步执行方法 只能new 因为run start new 在建立时就异步执行了
            //CreateSynChronouslyTask();
            // 线程阻塞的方式
            //WaitTask();
            // 任务延续
            //ContinueTask();
            //取消Task执行
            CancelTask();

        }

        private void CancelTask()
        {
            _tokenSource = new CancellationTokenSource();
            //延迟取消
            _tokenSource.CancelAfter(5000);
            //取消回调
            _tokenSource.Token.Register(()=>
            {
                print("任务取消了");
            });
            
            Task.Run(() =>
            {
                int i = 0;
                while (!_tokenSource.IsCancellationRequested)
                {
                    print(i);
                    i++;
                    Thread.Sleep(1000);
                }
            });
        }

        private void ContinueTask()
        {
            Task t1 = Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    print("t1: " + i);
                }
            });
            
            Task t2 = Task.Run(() =>
            {
                for (int i = 6; i < 20; i++)
                {
                    print("t2: " + i);
                }
            });

            Task.WhenAll(t2).ContinueWith((t) =>
            {
                print("t2完成  一个新的任务开始");
                int i = 0;
                while (_isRuning)
                {
                    print(i);
                    ++i;
                    Thread.Sleep(1000);
                }
            });

            Task.Factory.ContinueWhenAll(new Task[] { t1, t2 }, (t) =>
            {
                print("t2完成  一个新的任务开始");
            });

            Task.WhenAny(t1,t2).ContinueWith((t)=>{  print("t2完成  一个新的任务开始");});
        }

        private void WaitTask()
        {
            Task t1 = Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    print("t1: " + i);
                }
            });
            
            Task t2 = Task.Run(() =>
            {
                for (int i = 6; i < 20; i++)
                {
                    print("t2: " + i);
                }
            });
            //等任务完成
            //t1.Wait();

            //Task.WaitAny(t1,t2);
            //Task.WaitAll(t1,t2);

            print("主线程");
        }

        private void CreateSynChronouslyTask()
        {
            Task t1 = new Task(() =>
            {
                Thread.Sleep(1000);
                print("123");
            });
            
            t1.RunSynchronously();
        }

        void CreateNoReturnTask()
        {
            Task t1 = new Task(() =>
            {
                int i = 0;
                while (_isRuning)
                {
                    print("方式1:" + i);
                    ++i;
                    Thread.Sleep(1000);
                }
            });
            t1.Start();
            
            //不需要Start
            Task t2 = new Task(() =>
            {
                int i = 0;
                while (_isRuning)
                {
                    print("方式2:" + i);
                    ++i;
                    Thread.Sleep(1000);
                }
            });

            Task t3 = Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (_isRuning)
                {
                    print("方式3:" + i);
                    ++i;
                    Thread.Sleep(1000);
                }
            });
        }
        
        void CreateHasReturnTask()
        {
            _t1 = new Task<int>(() =>
            {
                int i = 0;
                while (_isRuning)
                {
                    print("方式1:" + i);
                    ++i;
                    Thread.Sleep(1000);
                }

                return 1;
            });
            _t1.Start();
            
            //不需要Start
            //会自动识别 泛型
            _t2 = Task.Run<string>(() =>
            {
                int i = 0;
                while (_isRuning)
                {
                    print("方式2:" + i);
                    ++i;
                    Thread.Sleep(1000);
                }
                return "abc";
            });

            //不需要Start
            //会自动识别 泛型
            _t3 = Task.Factory.StartNew<float>(() =>
            {
                int i = 0;
                while (_isRuning)
                {
                    print("方式3:" + i);
                    ++i;
                    Thread.Sleep(1000);
                }

                return 1.5f;
            });
            
            //获得Result时 会阻塞线程 
            //等待 返回值逻辑
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // _isRuning = false;
                // print(_t1.Result);
                // print(_t2.Result);
                // print(_t3.Result);
                
                _tokenSource.Cancel();
            }
        }

        private void OnDestroy()
        {
            _isRuning = false;
        }
    }
}