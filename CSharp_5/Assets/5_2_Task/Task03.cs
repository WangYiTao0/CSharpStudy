using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace _5_2_Task
{
    public class Task03 : MonoBehaviour
    {
        private CancellationTokenSource _tokenSource;

        private void Start()
        {
            //TestAsync();

            //print("主线程执行");
            CalcPathAsync(this.gameObject, Vector3.forward * 5);

            // 计时器
            Timer();
            
            // Addressable 资源异步加载
        }

        public async void TestAsync()
        {
            print("进入异步方法");

            await Task.Run(() =>
            {
                Thread.Sleep(2000);
            });
            
            print("await 后");
        }

        public async void CalcPathAsync(GameObject obj, Vector3 targetPos)
        {
            print("开始寻路计算");
            
            await Task.Run(()=>
            {
                Thread.Sleep(1000);
            });
            
            print("寻路计算完毕 处理逻辑");
            
            obj.transform.position = targetPos;

        }

        async void Timer()
        {
            _tokenSource = new CancellationTokenSource();

            int i = 0;
            while (!_tokenSource.IsCancellationRequested)
            {
                print(i);
                await Task.Delay(1000);
                i++;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _tokenSource.Cancel();
            }
        }
    }
}
