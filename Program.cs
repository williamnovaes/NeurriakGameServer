using System;
using System.Threading;

namespace NeurriakGameServer {
    class Program {
        private static bool isRunning = false;
        static void Main(string[] args) {
            isRunning = true;
            Thread mainThread = new Thread(new ThreadStart(MainThread));
            mainThread.Start();
            Server.Start();
            Console.WriteLine("Server Started!");
            Console.Read();
            Server.Stop();
        }

        private static void MainThread() {
            Console.Write("Main Thread Started");
            // DateTime _nextLoop = DateTime.Now;
            // while(isRunning) {
            //     while(_nextLoop < DateTime.Now) {
            //         _nextLoop = _nextLoop.AddMilliseconds(1000 / 30);
            //         if (_nextLoop > DateTime.Now) {
            //             Thread.Sleep(_nextLoop - DateTime.Now);
            //         }   
            //     }
            // }
        }
    }
}
