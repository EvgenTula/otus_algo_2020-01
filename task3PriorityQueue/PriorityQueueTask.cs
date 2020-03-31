using SimpleTester;
using System;
using System.Collections.Generic;
using System.Text;
using task3DynamicArray;

namespace task3PriorityQueue
{
    class PriorityQueueTask : Task
    {
        public override string Run(string[] data)
        {
            PriorityQueue<String> priorityQueue = new PriorityQueue<String>(int.Parse(data[0]));
            String[] dataToQueue = data[1].Split(" ");
            for (int i = 0; i < dataToQueue.Length; i++)
            {
                string[] param = dataToQueue[i].Split(';');
                int priority = int.Parse(param[0]);
                string val = param[1];
                priorityQueue.enqueue(priority, val);
            }
            String item;
            StringBuilder result = new StringBuilder();
            while ((item = priorityQueue.Dequeue()) != null)
            {
                result.Append(item + " ");
            }
            return result.ToString().TrimEnd();
        }
    }
}
