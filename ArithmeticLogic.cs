using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unyschkovsky {
    public static class ArithmeticLogic {
        public static int Roll(this Entity Roller) {
            string Input = Roller.Attribute["Roll"];
            int TempValue = 0;
            string[] Rolls = Input.Split(new char[] { '+' });
            foreach (string s in Rolls) {
                if (!s.Contains('d')) TempValue += Roller.Value[s];
                else {
                    for (int i = 0; i < Convert.ToInt32(s.Substring(0, s.IndexOf('d'))); i++) {
                        TempValue += Program.R.Next(1, Convert.ToInt32(s.Substring(s.IndexOf('d') + 1)));
                    }
                }
            }
            return TempValue;
        }
        public static ConsoleKey RandomKey() {
            ConsoleKey[] Keys = { ConsoleKey.A, ConsoleKey.B, ConsoleKey.C, ConsoleKey.D, ConsoleKey.E, ConsoleKey.F, ConsoleKey.G, ConsoleKey.H, ConsoleKey.I, ConsoleKey.J, 
            ConsoleKey.K, ConsoleKey.L,ConsoleKey.M,ConsoleKey.N,ConsoleKey.O,ConsoleKey.P,ConsoleKey.Q,ConsoleKey.R,ConsoleKey.S,ConsoleKey.T,
            ConsoleKey.U,ConsoleKey.V,ConsoleKey.W,ConsoleKey.X,ConsoleKey.Y,ConsoleKey.Z};
            return Keys[Program.R.Next(0, Keys.Length)];
        }
        public static string RandomSplitArray(string Input) {
            string[] Articles = Input.Split(new char[] { '/' });
            return Articles[Program.R.Next(0, Articles.Length)];
        }
        public static string ChaseIndex(string Input, int Index) {
            string[] Articles = Input.Split(new char[] { '/' });
            return Articles[Index];
        }
        public static List<T> ToList<T>(this T[] ToConvert) {
            return new List<T>(ToConvert);
        }
        public static int MinClamp(this int Value, int Clamp) {
            if (Value < Clamp) return Clamp;
            else return Value;
        }
    }
}
