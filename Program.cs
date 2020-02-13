using System;
using System.Collections.Generic;

namespace QueuingUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new Queuing();
            var patiens = new List<Patient>();
            for (int i = 0; i < 10; i++)
            {
                patiens.Add(new Patient(i, "张三" + i, "MZ" + i));
            }

            q.Queue(patiens[0]); // 排队
            q.Print();
            q.Queue(patiens[1]); // 排队
            q.Print();
            q.DeQueueTheTop(); // 第一个出队
            q.Print();
            q.Queue(patiens[2]); // 排队
            q.Print();
            q.QueueTheTop(patiens[3]); // 排队到第一
            q.Print();
            q.Queue(patiens[4]); // 排队
            q.Print();
            q.DeQueue(patiens[2]); // 患者张三2 出队
            q.Print();
            q.DeQueueTheTail(); // 最后一位出队
            q.Print();
            q.Queue(patiens[5]); // 排队
            q.Print();
            q.Queue(patiens[6], 1); // 张三6 插队到2个（排队id下标从0开始）
            q.Print();
            q.Queue(patiens[8], 2); // 张三8 插队到3个（排队id下标从0开始）
            q.Print();
        }
    }
}
