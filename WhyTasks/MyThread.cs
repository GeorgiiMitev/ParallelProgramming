using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhyTasks
{
    internal enum ThreadStatus
    {
        NotStarted,
        Running,
        Cancelled,
        Completed,
        Faulted
    };
    internal class MyThread<TResult>
    {
        private TResult resultField;
        public TResult Result
        {
            get
            {
                if (Status != ThreadStatus.Completed)
                {
                    throw new InvalidOperationException("Result not there yet.");
                }
                return resultField;
            }
            set
            {
                resultField = value;
            }
        }
        public Exception Exception { get; private set; }

        public ThreadStatus Status { get; private set; }

        private ManualResetEvent ranToCompletionEvent;

        Func<TResult> Worker { get; set; }

        public MyThread(Func<TResult> worker)
        {
            Worker = worker;
            ranToCompletionEvent = new ManualResetEvent(false);
        }

        private void RunInternal(object state)
        {
            Status = ThreadStatus.Running;
            try
            {
                Result = Worker();
                Status = ThreadStatus.Completed;
            }
            catch (Exception e)
            {
                Exception = e;
                Status = ThreadStatus.Faulted;
            }
            finally
            {
                ranToCompletionEvent.Set();
            }
        }

        public void Run()
        {
            ThreadPool.QueueUserWorkItem(RunInternal);
        }

        public void Wait()
        {
            ranToCompletionEvent.WaitOne();
            if(Status == ThreadStatus.Faulted)
            {
                throw Exception;
            }
        }
    }
}
