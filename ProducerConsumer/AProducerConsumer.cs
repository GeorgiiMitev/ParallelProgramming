using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    internal class AProducerConsumer
    {
        Queue<int> workQueue { get; set; }
        Action<int> consumerAction { get; set; }

        ManualResetEventSlim cancelSignal = new ManualResetEventSlim(false);

        ManualResetEventSlim workAvailableSignal = new ManualResetEventSlim(false);
        public AProducerConsumer(Action<int> consumerAction)
        {
            workQueue = new Queue<int>();
            this.consumerAction = consumerAction;
        }
        public void PushData(int data)
        {
            lock (workQueue)
            {
            workQueue.Enqueue(data);
            }
            workAvailableSignal.Set();
        }

        //Start listening for events, and processing them if data is available.
        //version 1: there will be a single consumer
        public void RunInternal()
        {
            while (cancelSignal.Wait(0) is false)
            {
                workAvailableSignal.Wait(500); //make sure we can cancel if there's no work available

                int workItem;
                lock(workQueue)
                {
                    if (workQueue.TryDequeue(out workItem) is false)
                    {
                        workAvailableSignal.Reset();
                        continue;
                    }
                    consumerAction(workItem);
                }
                

            }
        }

        public void Run()
        {
            Thread consumerThread = new Thread(RunInternal);
            consumerThread.Start();

        }
    }
}
