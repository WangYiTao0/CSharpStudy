using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Task01 : MonoBehaviour
{
    private Thread t;
    // Start is called before the first frame update
    void Start()
    {
        // t = new Thread(() =>
        // {
        //     while (true)
        //     {
        //         //需要在OnDestroy 停止 不然线程不会停止
        //         print("123");
        //         Thread.Sleep(1000);
        //         //不能使用Unity 主线程的对象
        //     }
        // });
        //
        // t.Start();
        // //t.IsBackground = true;
        //
        // print("MainThread Excute");


        //Thread Pool
        int num1;
        int num2;
        //获取可用的工作线程数和I/O线程数
        ThreadPool.GetAvailableThreads(out num1, out num2);
        print("初始工作线程数、IO线程数量");
        print(num1);
        print(num2);

        //获取线程池中工作线程的最大数目和I/O线程的最大数目
        ThreadPool.GetMaxThreads(out num1, out num2);
        print("工作线程的最大数目和I/O线程的最大数目");
        print(num1);
        print(num2);

        //自己设置 
        if (ThreadPool.SetMaxThreads(25, 25))
        {
            print("更改成功");
            //获取线程池中工作线程的最大数目和I/O线程的最大数目  > 24
            ThreadPool.GetMaxThreads(out num1, out num2);
            print(num1);
            print(num2);
        }
        else
        {
            print("更改失败");
        }
        
        //获取线程池中工作线程的最小数目和I/O线程的最小数目
        ThreadPool.GetMinThreads(out num1, out num2);
        print(num1);
        print(num2);
        
        //5.设置 工作线程的最小数目和I/O线程的最小数目
        if(ThreadPool.SetMinThreads(5, 5))
        {
            print("设置成功");
        }
        print("设置成功 GetMinThreads");
        ThreadPool.GetMinThreads(out num1, out num2);
        print(num1);
        print(num2);
        
        ThreadPool.QueueUserWorkItem((obj) =>
        {
            print(obj);
            print("开启了一个线程");
        }, "123452435345");


        //不能控制线程池里面执行的顺序
        for (int i = 0; i < 10; i++)
        {
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                print("第" + obj + "个任务");
            }, i);
        }

        print("主线程执行");

    }

    private void OnDestroy()
    {
        //t.Abort();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
