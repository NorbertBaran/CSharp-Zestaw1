using System;
using System.Linq;

namespace NFO
{
    public class Validations {
        //Entry:
        public static bool EntryChoice(string entryChoice) => entryChoice == "1" || entryChoice == "X";
        public static bool Username(string username)=>username.All(char.IsLetter) && username.Length>=2;
        public static bool EHeroClass(string eHeroClassString, out EHeroClass eHeroClass)=>Enum.TryParse(eHeroClassString, out eHeroClass);
        public static bool MainGameChoice(string optionString, int npcCount, int option=0) => optionString=="T" || optionString=="X" || (int.TryParse(optionString, out option) && option>=1 && option<=npcCount);
    }
}