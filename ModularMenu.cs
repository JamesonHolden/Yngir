using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yngir {
    public class ModularMenu<T> {
        private bool Running;
        private int OptionSelected;
        public string Title;
        public ConsoleColor SelectedColour;
        public List<string> Articles;
        public List<T> Actions;
        public ModularMenu(List<string> Articles, List<T> Actions, string Title = "", ConsoleColor SelectedColour = ConsoleColor.Red) {
            this.SelectedColour = SelectedColour;
            this.Title = Title;
            this.Articles = Articles;
            this.Actions = Actions;
        }
        public void Open(out T output) {
            output = Actions[0];
            Running = true;
            OptionSelected = 0;
            while (Running) {
                Console.Clear();
                if (Title != "") ConsoleStream.PrintTitle(Title);
                for (int Index = 0; Index < Articles.Count; Index++) {
                    if (Index == OptionSelected) ConsoleStream.ColouredWriteLine($"> {Articles[Index]} <", SelectedColour);
                    else Console.WriteLine(Articles[Index]);
                }
                ConsoleKey UserInput = ConsoleStream.ReadKey().Key;
                if (UserInput == ConsoleKey.Enter) {
                    output = Actions[OptionSelected];
                    break;
                }
                else if (UserInput == ConsoleKey.S || UserInput == ConsoleKey.DownArrow) {
                    if (OptionSelected < Articles.Count - 1) OptionSelected++;
                    else OptionSelected = 0;
                }
                else if (UserInput == ConsoleKey.W || UserInput == ConsoleKey.UpArrow) {
                    if (OptionSelected > 0) OptionSelected--;
                    else OptionSelected = Articles.Count - 1;
                }
            }
        }
    }
}
