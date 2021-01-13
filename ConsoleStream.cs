using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Unyschkovsky {
    public class ConsoleStream {
        private static Thread InputThreadL, InputThreadK;
        private static AutoResetEvent GotInputL, GetInputL, GotInputK, GetInputK;
        private static string InputL;
        private static ConsoleKeyInfo InputK;
        static ConsoleStream() {
            GetInputL = new AutoResetEvent(false);
            GotInputL = new AutoResetEvent(false);
            InputThreadL = new Thread(ReaderL);
            InputThreadL.IsBackground = true;
            InputThreadL.Start();
            GetInputK = new AutoResetEvent(false);
            GotInputK = new AutoResetEvent(false);
            InputThreadK = new Thread(ReaderK);
            InputThreadK.IsBackground = true;
            InputThreadK.Start();
        }
        private static void ReaderL() {
            while (true) {
                GetInputL.WaitOne();
                InputL = Console.ReadLine();
                GotInputL.Set();
            }
        }
        private static void ReaderK() {
            while (true) {
                GetInputK.WaitOne();
                InputK = Console.ReadKey(true);
                GotInputK.Set();
            }
        }

        public static string ReadLine(int TimeOut = Timeout.Infinite) {
            GetInputL.Set();
            bool Success = GotInputL.WaitOne(TimeOut);
            if (Success) return InputL;
            else throw new TimeoutException();
        }
        public static ConsoleKeyInfo ReadKey(int TimeOut = Timeout.Infinite) {
            GetInputK.Set();
            bool Success = GotInputK.WaitOne(TimeOut);
            if (Success) return InputK;
            else throw new TimeoutException();
        }
        public static void CinematicWrite(string Message, int Speed = 25) {
            foreach (char c in Message) {
                Console.Write(c);
                Thread.Sleep((int)Math.Round((double)(1000 / Speed)));
            }
        }
        public static void PrintTitle(string Title) {
            int Spacing = (int)Math.Floor((double)((53 - Title.Length) / 2));
            string _Message = "";
            for (byte i = 0; i < Spacing; i++) {
                _Message += " ";
            }
            _Message += Title;
            Console.Clear();
            Console.WriteLine($"===== ===== ===== ===== ===== ===== ===== ===== =====\n{_Message}\n===== ===== ===== ===== ===== ===== ===== ===== =====");
        }
        public static void ColouredWriteLine(string Message, ConsoleColor Colour) {
            Console.ForegroundColor = Colour;
            Console.WriteLine(Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
