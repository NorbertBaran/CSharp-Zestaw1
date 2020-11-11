using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NFO{
    static class Game{
        static void PrintMenu(Hero hero, Location location){
            Console.WriteLine("Znajdujesz się w: {0}. Co chcesz zrobić?", location.Name);
            int NpcCount=0;
            foreach(var NPC in location.NonPlayerCharacters)
                Console.WriteLine("[{0}] Porozmawiaj z {1}", ++NpcCount, NPC.Name);
            Console.WriteLine("[T] Podróżuj");
            Console.WriteLine("[X] Zamknij program");

            string optionString="";
            int option=1;
            bool isOptionCorrect()=> optionString=="T" || optionString=="X" || (int.TryParse(optionString, out option) && option>=1 && option<=NpcCount) ? true : false;
            do{
                Console.Write("Nr: ");
                optionString=Regex.Replace(Console.ReadLine(), @"\s+", "");
                if(!isOptionCorrect())
                    Console.WriteLine("Brak wskazanej opcji. Spróbuj ponownie.");
            }while(!isOptionCorrect());
            
            if(optionString == "T")

            location.NonPlayerCharacters.ElementAt(option).StartTalking();
        }
        
        public static void PrintLocationChoose() {
            
        }
        
        public static void Play(Hero hero){
            Console.Clear();
            Console.WriteLine("{0} {1} wyrusza na przygodę.", hero.Name, hero.EHeroClass);

            string[] locations=Enum.GetNames(typeof(ELocationNames));

            string randomELocationNameString=locations[new Random().Next(locations.Length)];
            ELocationNames randomELocationName;
            Enum.TryParse(randomELocationNameString, out randomELocationName);
            Location location=new Location(randomELocationName);
            
            PrintMenu(hero, location);
        }

        
    }
}