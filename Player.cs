using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yngir {
    public class Player : Entity {
        public string Quality = "Bronze 1";
        public InventoryHandler Inventory = new InventoryHandler();
        public Player() {
            Attribute = new Dictionary<string, string>();
            Value = new Dictionary<string, int>();
            Attribute.Add("Class", ArithmeticLogic.RandomSplitArray(Program.GameData["classes"]));
            Attribute.Add("Race", ArithmeticLogic.RandomSplitArray(Program.GameData["races"]));
            Attribute.Add("Weapon", ArithmeticLogic.RandomSplitArray(Program.GameData[Attribute["Class"].ToLower()]));
            Attribute.Add("Roll", $"{Program.GameData[Quality]}+{Program.GameData[Attribute["Weapon"]]}");

            Value.Add("Level", 0);
            Value.Add("Acrobatics", 0);
            Value.Add("Marksmanship", 0);
            Value.Add("Martial Arts", 0);
            Value.Add("Nature Magic", 0);
            Value.Add("Arcane Magic", 0);
            Value.Add("Grit", 0);
            Value.Add("Constitution", 0);
            Value.Add("Stealth", 0);
            Value.Add("Max Health", 10);
            Value.Add("Health", 10);
            Value.Add("Defence", 5);
        }
    }
}
