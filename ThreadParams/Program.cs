namespace ThreadParams;

internal class Program
{

    static void ThreadMethod(object objectParam)
    {
        string tag = objectParam.ToString();
        Console.WriteLine($"Hello I am {tag}");
    }
    static void Main(string[] args)
    {
        Thread t1 = new Thread(ThreadMethod);
        Thread t2 = new Thread(ThreadMethod);

        t1.Start("T1");
        t2.Start("T2");
    }
}
