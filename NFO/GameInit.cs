using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace NFO{
    class GameInit{
        public static void Init(){
            Console.Clear();

            string userName="";
            bool isUserNameCorrect()=>userName.All(char.IsLetter) && userName.Length>=2 ? true : false;
            do{
                Console.Write("Nazwa gracza: ");
                userName=Regex.Replace(Console.ReadLine(), @"\s+", "");
                if(!isUserNameCorrect())
                    Console.WriteLine("Niepoprawna nazwa użytkownika. Nazwa powinna zawierać conajmniej 2 niepuste znaki oraz składać się wyłącznie z liter alfabetu.");
            }while(!isUserNameCorrect());
            
            string eHeroClassString="";
            EHeroClass eHeroClass;
            bool isEHeroClassCorrect()=>Enum.TryParse(eHeroClassString, out eHeroClass);
            do{
                Console.Write("Witaj {0}, wybierz klasę bohatera ({1}): ", userName, string.Join(", ", Enum.GetValues(typeof(EHeroClass)).Cast<EHeroClass>()));
                eHeroClassString=Regex.Replace(Console.ReadLine(), @"\s+", "");
                if(!isEHeroClassCorrect())
                    Console.WriteLine("Niepoprawna nazwa klsy bohatera. Dostępne klasy: {0}", string.Join(", ", Enum.GetValues(typeof(EHeroClass)).Cast<EHeroClass>()));
            }while(!isEHeroClassCorrect());

            Game.Play(new Hero(userName, eHeroClass));
        }
    }
}