using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Yngir {
    public class FileManager {
        private List<string> SaveData = new List<string>();
        public void LoadFile(string Name) {
            string DirectoryPath = $"{Directory.GetCurrentDirectory()}/{Name}.txt";
            if (DirectoryPath == $"{Directory.GetCurrentDirectory()}/GameData.txt") Load();
            else if (!File.Exists(DirectoryPath));
            else {
                SaveData.Clear();
                StreamReader SR = new StreamReader(DirectoryPath);
                string Line;
                while ((Line = SR.ReadLine()) != null) {
                    SaveData.Add(Line);
                }
                SR.Close();
            }
        }
        private void Load() {
            List<string> Temp = new List<string>();
            Program.GameData.Clear();
            StreamReader SR = new StreamReader($"{Directory.GetCurrentDirectory()}/GameData.txt");
            string Line;
            while ((Line = SR.ReadLine()) != null) {
                Temp.Add(Line);
            }
            Program.GameData = UnformatFile(Temp);
            SR.Close();
        }
        public void SaveFile(string Name) {
            string DirectoryPath = $"{Directory.GetCurrentDirectory()}/{Name}.txt";
            if (!File.Exists(DirectoryPath)) File.Create(DirectoryPath);
            if (DirectoryPath == $"{Directory.GetCurrentDirectory()}/GameData.txt");
            else {
                StreamWriter SW = new StreamWriter(DirectoryPath, false);
                foreach (string s in SaveData) {
                    SW.WriteLine(String.Format(s));
                }
                SW.Flush();
                SW.Close();
            }
        }
        public void AddLineToFile(string Input) {
            SaveData.Add(Input);
        }
        public void ChangeLineInFile(string Input, int Line) {
            List<string> NewData = new List<string>();
            for (int i = 0; i < Line - 1; i++) {
                NewData.Add(SaveData[i]);
            }
            NewData.Add(Input);
            for (int j = Line; j < SaveData.Count; j++) {
                NewData.Add(SaveData[j]);
            }
            SaveData.Clear();
            SaveData = NewData;
        }
        private List<string> FormatFile(Dictionary<string, string> UnformattedData) {
            List<string> Arg = new List<string>();
            foreach (KeyValuePair<string,string> Entry in UnformattedData) {
                Arg.Add($"{Entry.Key}:{Entry.Value}");
            }
            return Arg;
        }
        private Dictionary<string,string> UnformatFile(List<string> FormattedData) {
            Dictionary<string, string> Arg = new Dictionary<string, string>();
            foreach (string s in FormattedData) {
                Arg.Add(
                    s.Substring(0, s.IndexOf(':')),
                    s.Substring(s.IndexOf(':') + 1)
                    );
            }
            return Arg;
        }
    }
}
