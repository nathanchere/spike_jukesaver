﻿using System;
using System.Threading;

namespace IPC.NamedPipes
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var quit = new ManualResetEvent(false);
            Console.CancelKeyPress += (s, a) =>
            {
                quit.Set();
                a.Cancel = true;
            };

            // run server

            Console.WriteLine("Named pipe server running; Ctrl+C to quit");
            quit.WaitOne();
        }
    }
}