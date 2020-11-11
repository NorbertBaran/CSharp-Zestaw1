using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace NFO
{
    public class GameLogic{
        //Entry:
        public static string InputEntryChoice(string entryChoice = ""){
            while(!Validations.EntryChoice(entryChoice)){
                entryChoice=Regex.Replace(Console.ReadLine(), @"\s+", "");
                if(!Validations.EntryChoice(entryChoice))
                    Screens.EntryAfterMistake();
            };
            return entryChoice;
        }

        public static void InitGame(string entryChoice){
            if(entryChoice == "1")
                GameInit.Init();
            else
                Environment.Exit(0);
        }

        public static string InputUsername(string username = ""){
            while(!Validations.Username(username)){
                username=Regex.Replace(Console.ReadLine(), @"\s+", "");
                if(!Validations.Username(username))
                    Screens.UsernameInitAfterMistake();
            }
            return username;
        }

        public static EHeroClass InputHeroType(string username, string eHeroClassString = "") {
            EHeroClass eHeroClass;
            while(!Validations.EHeroClass(eHeroClassString, out eHeroClass)){
                eHeroClassString=Regex.Replace(Console.ReadLine(), @"\s+", "");
                if(!Validations.EHeroClass(eHeroClassString, out eHeroClass))
                    Screens.HeroInitAfterMistake(username);
            }
            return eHeroClass;
        }

        public static string InputMainGameChoice(int npcCount, string optionString="") {
            while(!Validations.MainGameChoice(optionString, npcCount)){
                Console.Write("Nr: ");
                optionString=Regex.Replace(Console.ReadLine(), @"\s+", "");
                if(!Validations.MainGameChoice(optionString, npcCount))
                    Console.WriteLine("Brak wskazanej opcji. Spróbuj ponownie.");
            }

            return optionString;
        }

        public static Location RandomLocation(){
            string[] locations=Enum.GetNames(typeof(ELocationNames));
            string randomELocationNameString=locations[new Random().Next(locations.Length)];
            ELocationNames randomELocationName;
            Enum.TryParse(randomELocationNameString, out randomELocationName);
            Location location=new Location(randomELocationName);
            
            return location;
        }
    }
}