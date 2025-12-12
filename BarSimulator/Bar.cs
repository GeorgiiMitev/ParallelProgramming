using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarSimulator
{
    internal class Bar
    {
        List<Student> Students { get; set; }
        SemaphoreSlim Semaphore { get; set; }

        public ManualResetEventSlim ClosingSignal { get; private set; }
        
        public Bar()
        {
            Students = new List<Student>();
            Semaphore = new SemaphoreSlim(20, 20);
        }
        public void Enter(Student student)
        {
            Semaphore.Wait();
            lock (Students)
            {
                Students.Add(student);
            }
        }
        public void Exit(Student student)
        {
            lock (Students)
            {
                Students.Remove(student);
            }
            Semaphore.Release();
        }

        private void KickEveryoneOut()
        {
            ClosingSignal.Set();
        }

        public void Run()
        {
            DateTime openingTime = DateTime.Now;
            while(DateTime.Now - openingTime < TimeSpan.FromSeconds(30))
            {
                //just waits for time to end
                Thread.Sleep(1000);
            }
            KickEveryoneOut();
        }
    }
}
