using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unyschkovsky {
    public class Program {
        public static Dictionary<string, string> GameData = new Dictionary<string, string>();
        public static Player Player = new Player();
        public static Enemy Enemy = new Enemy(5, "Bronze 1");
        public static Random R = new Random(Guid.NewGuid().GetHashCode());
        public static void Main() {
            try {
                ConsoleKey RequiredKey = ArithmeticLogic.RandomKey();
                ConsoleStream.CinematicWrite($"Press {RequiredKey} to dodge...\n", 500);
                ConsoleKeyInfo Input = ConsoleStream.ReadKey(3000);
                if (!(Input.Key == RequiredKey)) throw new Exception();
                Console.Clear();
                ConsoleStream.CinematicWrite("You dodged!\n");
            }
            catch (TimeoutException e) {
                Console.Clear();
                ConsoleStream.CinematicWrite("Time's up.\n");
            }
            catch (Exception f) {
                Console.Clear();
                ConsoleStream.CinematicWrite("Wrong key.\n");
            }
            ConsoleStream.ReadKey();
        }
    }
}
