using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unyschkovsky {
    public class Enemy : Entity {
        new public Dictionary<string, string> Attribute = new Dictionary<string, string>();
        new public Dictionary<string, int> Value = new Dictionary<string, int>();
        private string Quality;
        public Enemy(int PlayerLevel, string PlayerQuality) {
            this.Quality = PlayerQuality.Substring(0, PlayerQuality.IndexOf(' '));
            this.Quality += $"{Program.R.Next(1, Convert.ToInt32(Program.GameData[this.Quality.ToLower()]))}"; 
            PopulateDictionary(PlayerLevel);
        }
        private void PopulateDictionary(int PL) {
            Attribute.Add("Class", ArithmeticLogic.RandomSplitArray(Program.GameData["classes"]));
            Attribute.Add("Race", ArithmeticLogic.RandomSplitArray(Program.GameData["races"]));
            Attribute.Add("Weapon", ArithmeticLogic.RandomSplitArray(Program.GameData[Attribute["Class"].ToLower()]));
            Attribute.Add("Roll", $"{Program.GameData[Quality]}+{Program.GameData[Attribute["Weapon"]]}");

            Value.Add("Level", Program.R.Next((PL - 2).MinClamp(0), PL + 3));
            Value.Add("Acrobatics", SeekValue(0));
            Value.Add("Marksmanship", SeekValue(1));
            Value.Add("Martial Arts", SeekValue(2));
            Value.Add("Nature Magic", SeekValue(3));
            Value.Add("Arcane Magic", SeekValue(4));
            Value.Add("Grit", SeekValue(5));
            Value.Add("Constitution", SeekValue(6));
            Value.Add("Stealth", SeekValue(7));
            Value.Add("Max Health", 10+(Value["Constituion"]*2));
            Value.Add("Health", Value["Max Health"]);
            Value.Add("Defence", 5+Value["Grit"]);
        }

        private int SeekValue(int Index) {
            int Percent = Convert.ToInt32(ArithmeticLogic.ChaseIndex(Program.GameData[Attribute["Class"]], Index));
            return (int)Math.Round((double)((Percent / 50) * Value["Level"]));
        }
    }
}
