using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestInterlockedId
{
    class Program
    {
        static void Main(string[] args)
        {
            int cores = System.Environment.ProcessorCount;
            int amount = 1000000000;

            DoTest("1 thread lock generator", () => OneThTest(new LockGenerator(), amount));
            DoTest("1 thread lock free gen.", () => OneThTest(new InterlockGenerator(), amount));
            DoTest("1 thread no lock gen.  ", () => OneThTest(new InterlockGenerator(), amount));

            DoTest($"{cores} thread lock generator", () => MultyThTest(new LockGenerator(), amount));
            DoTest($"{cores} thread lock free gen.", () => MultyThTest(new InterlockGenerator(), amount));

            Console.ReadKey();
        }

        static void DoTest(string name, Action test)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Console.Write(name + " ... ");
            test();
            Console.WriteLine("elapsed: " + sw.Elapsed);
            Thread.Sleep(10000);
        }

        static void OneThTest(IGenBase gen, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                int key = gen.NewId;
                key++;
            }
        }

        static void MultyThTest(IGenBase gen, int amount)
        {
            Parallel.For(0, amount, (i) =>
            {
                int key = gen.NewId;
                key++;
            });
        }
    }
}
