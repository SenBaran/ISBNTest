//@CodeCopy
using System;
using System.Threading.Tasks;

namespace SnQPayWithFun.ConApp
{
	partial class Program
    {
        static void Main(/*string[] args*/)
        {
            Console.WriteLine("Test SnQPayWithFun");

            BeforeRun();

            AfterRun();
        }

        static partial void BeforeRun();
        static partial void AfterRun();
    }
}
