namespace ThreadExceptions;

internal class Program
{
    static Exception workerException = null;
    static void Worker()
    {
        try
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                double d = Random.Shared.NextDouble() * Math.PI;
                double result = Math.Cos(d) * Math.Sin(d);
                result = Math.Sqrt(result);
                if (i > 8_000_000)
                {
                    
                }
            }
           

        }
        catch (Exception ex)
        {
            workerException = ex;
        }


    }
    static void Main(string[] args)
    {
        Thread t = new Thread(Worker);
        Console.WriteLine($"starting computation in the background");
        t.Start();
        while (t.Join(100) is false)
        {
            Console.WriteLine("Calculating...");
        }

        if (workerException is not null)
        {
            Console.WriteLine($"Job completed with errors: {workerException.Message}");
        }
        else
        {
            Console.WriteLine("completed");
        }

    }
}
