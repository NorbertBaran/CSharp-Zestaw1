using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NFO{
    static class Game{
        public static void Play(Hero hero){
            //Dictionary<Location, bool> 
            
            Location location = GameLogic.RandomLocation();
            while (true){
                int npcCount;
                Screens.MainGame(hero, location, out npcCount);
                string optionString=GameLogic.InputMainGameChoice(npcCount);

                if (optionString == "X") {
                    break;
                }
                if (optionString == "T")
                    location = new Location(Screens.Travel(location));
                else {
                    int option = int.Parse(optionString) - 1;
                    if(option >= 0 && option < location.NonPlayerCharacters.Count)
                        Screens.Talk(location, option, new DialogParser(hero));
                }
            }
        }
    }
}