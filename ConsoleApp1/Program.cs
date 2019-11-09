using System;
using System.Collections.Generic;
using System.Timers;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine machine = new VendingMachine();
            machine.StartMachine();
        }
    }
}
