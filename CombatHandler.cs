using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unyschkovsky {
    public static class CombatHandler {
        public static Dictionary<string, Enemy> Enemies = new Dictionary<string, Enemy>(); 
        public static void Attack(this Entity Attacker, Entity Defender) {
            if (!Dodge()) {
                int Damage = Attacker.Roll();
                Damage -= Defender.Value["Defence"];
                Defender.Value["Health"] -= Damage;
            }
        }
        private static bool Dodge() {
            ConsoleKey RequiredKey = ArithmeticLogic.RandomKey();
            ConsoleStream.CinematicWrite($"Press {RequiredKey} to dodge...");

            return true;
        }
    }
}
