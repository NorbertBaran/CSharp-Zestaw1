using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace NFO{
    class GameInit{
        public static void Init(){
            Screens.UsernameInit();
            string username = GameLogic.InputUsername();
            
            Screens.HeroInit(username);
            EHeroClass eHeroClass = GameLogic.InputHeroType(username);

            Game.Play(new Hero(username, eHeroClass));
        }
    }
}