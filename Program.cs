using System.Threading;
using NawLog;
namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {
            NawLog.Loader load = new NawLog.Loader();
            load.Start();
            load.Update(10);
            Thread.Sleep(1000);
            load.Update(50);
            Thread.Sleep(1000);
            load.Update(25);
            Thread.Sleep(1000);
            load.Update(75);
            Thread.Sleep(1000);
            load.Update(100);
            Thread.Sleep(1000);
        }
    }
}
