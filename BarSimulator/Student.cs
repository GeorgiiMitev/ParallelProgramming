using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarSimulator
{
    internal class Student
    {
        public string Name { get; set; }
        private Bar Bar {  get; set; }
        public Student(string name, Bar bar)
        {
            Bar = bar;
            Name = name;
        }

        private static void RandomDelay()
        {
            Thread.Sleep(Random.Shared.Next(500, 2000));
        }
        private static bool ThrowDice()
        {
            return Random.Shared.Next(0, 2) == 0;
        }
        public void WalkAroundTheTown()
        {
            Console.WriteLine($"{Name} is walking around the town");
            RandomDelay();
        }

        

        public void GoToTheBar()
        {
            Console.WriteLine($"{Name} is trying to enter the bar");
            Bar.Enter(this);
            Console.WriteLine($"{Name} enters the bar!");
        }

        public void Dance()
        {
            Console.WriteLine($"{Name} is dancing");
            RandomDelay();
        }
        public void Drink()
        {
            Console.WriteLine($"{Name} is drinking");
            RandomDelay();
        }
        public void GoHome()
        {
            Bar.Exit(this);
            Console.WriteLine($"{Name} is turning in");
            
        }
        public void PaintTheTownRed()
        {
            if (ThrowDice())
            {
                WalkAroundTheTown();
            }
            GoToTheBar();

            while (true)
            {
                if (ThrowDice()) { Dance(); continue; }
                if (ThrowDice()) { Drink(); continue; }
                if (ThrowDice() || Bar.ClosingSignal.Wait(0) is true)  { GoHome(); break; }
                
            }
        }
    }
}
