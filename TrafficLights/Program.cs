namespace TrafficLights
{
    internal class Program
    {
        static string[] mainRoadLight = new string[]
        {
            "Червено", "Зелено", "Жълто", "Червено"
        };
        static string[] pedestrianLight = new string[]
        {
            "Зелено", "Червено"
        };
        static ManualResetEventSlim signalTraffic = new ManualResetEventSlim(false);
        static ManualResetEventSlim signalPedestrian = new ManualResetEventSlim(false);

        static void TrafficLight(object objParams)
        {
            int index = (int)objParams;
            if(index == 0)
            {
                Thread.Sleep(1000);
                Console.Write($"{mainRoadLight[index]}");
            }
            if (index == 1)
            {
                Thread.Sleep(1000);
                Console.Write($"{mainRoadLight[index]}");

            }
            if (index == 2)
            {
                Thread.Sleep(200);
                Console.Write($"{mainRoadLight[index]}");
            }
            
            Thread.Sleep(1000); 
            signalPedestrian.Set(); 
            signalTraffic.Wait();       
            Thread.Sleep(1000);
        }
        static void PedestrianLight(object objParams)
        {
            int index = (int)objParams;
            signalPedestrian.Wait();
            Console.WriteLine($"{pedestrianLight[index]}");
            signalPedestrian.Wait();   
            signalTraffic.Set();
        }
        static void Main(string[] args)
        {
            Thread[] trafficThreads = new Thread[4];
            Thread[] pedestrianThreads = new Thread[2];
            

            for (int i = 0; i < trafficThreads.Length; i++)
            {
                trafficThreads[i] = new Thread(TrafficLight);
                trafficThreads[i].Start(i);
            }
            for (int i = 0; i < pedestrianThreads.Length; i++)
            {
                pedestrianThreads[i] = new Thread(PedestrianLight);
                pedestrianThreads[i].Start(i);
                
            }
        }
    }
}
