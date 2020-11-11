using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NFO
{
    public class Screens
    {
        private static string GameName = "NFO";
        
        //Entry:
        private static void Entry() {
            Console.Clear();
            Console.WriteLine(
                $"Witaj w grze {GameName}\n" +
                $"[1] Zacznij nową grę\n" +
                $"[X] Zamknij program");
        } 

        public static void StartingEntry(){
            Screens.Entry();
            Console.Write("Nr: ");
        }

        public static void EntryAfterMistake()
        {
            Screens.Entry();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Wybrana opcja jest niewłaściwa");
            Console.ResetColor();
            Console.Write("Nr: ");
        }
        
        //Init:
        public static void UsernameInit(){
            Console.Clear();
            Console.Write("Nazwa gracza: ");
        }

        public static void UsernameInitAfterMistake(){
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Niepoprawna nazwa użytkownika. Nazwa powinna zawierać conajmniej 2 niepuste znaki oraz składać się wyłącznie z liter alfabetu.");
            Console.ResetColor();
            Console.Write("Nazwa gracza: ");
        }

        public static void HeroInit(string userName){
            Console.Clear();
            Console.Write("Witaj {0}, wybierz klasę bohatera ({1}): ", userName, string.Join(", ", Enum.GetValues(typeof(EHeroClass)).Cast<EHeroClass>()));
        }

        public static void HeroInitAfterMistake(string userName){
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Niepoprawna nazwa klsy bohatera. Dostępne klasy: {0}", string.Join(", ", Enum.GetValues(typeof(EHeroClass)).Cast<EHeroClass>()));
            Console.ResetColor();
            Console.Write("Witaj {0}, wybierz klasę bohatera ({1}): ", userName, string.Join(", ", Enum.GetValues(typeof(EHeroClass)).Cast<EHeroClass>()));
        }
        
        //MainGame:
        public static void MainGame(Hero hero, Location location, out int npcCount){
            Console.Clear();
            Console.WriteLine("{0} {1} wyrusza na przygodę.", hero.Name, hero.EHeroClass);
            Console.WriteLine("Znajdujesz się w: {0}. Co chcesz zrobić?", location.Name);
            npcCount=0;
            foreach(var NPC in location.NonPlayerCharacters)
                Console.WriteLine("[{0}] Porozmawiaj z {1}", ++npcCount, NPC.Name);
            Console.WriteLine("[T] Podróżuj");
            Console.WriteLine("[X] Zamknij program");
        }

        public static void Talk(Location location, int option, DialogParser dialogParser){
            var npc = location.NonPlayerCharacters.ElementAt(option);
            
            var npcDialogPart = npc.StartTalking;
            HeroDialogPart heroDialogPart = null;
            var heroDialogPartList = npcDialogPart.HeroDialogParts;
            
            List<Tuple<string, string>> conversation = new List<Tuple<string, string>>();

            bool talk = true;
            while(talk){
                Console.Clear();
                foreach (var sequence in conversation){
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(sequence.Item1);
                    Console.ResetColor();
                    Console.WriteLine(sequence.Item2);
                }

                //string npcConversationPart = npc.Name + ": " + npcDialogPart.DialogPart;
                conversation.Add(new Tuple<string, string>(npc.Name+": ", dialogParser.ParseDialog(npcDialogPart)));
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(npc.Name+": ");
                Console.ResetColor();
                Console.WriteLine(dialogParser.ParseDialog(npcDialogPart));
                
                if (npcDialogPart.HeroDialogParts == null){
                    talk = false;
                    break;
                }
                
                Console.WriteLine("[Wybierz numer odpowiedzi]");
                for (int i = 0; i < heroDialogPartList.Count; i++)
                    Console.WriteLine("["+(i+1)+"] " + dialogParser.ParseDialog(heroDialogPartList[i]));
                
                Console.Write("Nr: ");

                int dialogOption = -1;
                while (dialogOption == -1) {
                    try{;
                        dialogOption = int.Parse(Console.ReadLine());
                        if (dialogOption < 1 || dialogOption > heroDialogPartList.ToArray().Length)
                            dialogOption = -1;
                    }catch (Exception e){
                        dialogOption = -1;
                    }
                }

                heroDialogPart = heroDialogPartList[dialogOption - 1];
                if (heroDialogPart == null) {
                    talk = false;
                    break;
                }
                
                //string heroConversationPart = "you: "+heroDialogPartList[dialogOption - 1].DialogPart;
                conversation.Add(new Tuple<string, string>("you: ", dialogParser.ParseDialog(heroDialogPartList[dialogOption - 1])));

                npcDialogPart = heroDialogPartList[dialogOption - 1].NpcDialogPart;
                if (npcDialogPart == null){
                    talk = false;
                    break;
                }
                
                heroDialogPartList = npcDialogPart.HeroDialogParts;

            }
            
            Console.Clear();
            foreach (var sequence in conversation){
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(sequence.Item1);
                Console.ResetColor();
                Console.WriteLine(sequence.Item2);
            }
            
            Console.WriteLine();
            Console.WriteLine("[You just finished conversation. Press eneter to fininsh conversation]");
            Console.ReadLine();
        }

        public static ELocationNames Travel(Location location){

            var allLocations = (ELocationNames[]) Enum.GetValues(typeof(ELocationNames));
            //allLocations.ToList().ForEach(x=>Console.WriteLine(x+" "+new Location(x).IsUnlocked));
            string optionString="X";
            int option=0;
            bool mistake = false;
            while (true) {
                int locationNr = 0;
                
                var filtered = allLocations
                    .Where(x => x != location.Name && new Location(x).IsUnlocked == true)
                    .OrderBy(x => x.ToString());
                
                Console.Clear();
                Console.WriteLine("Znajdujesz się w: {0}. Gdzie chcesz wyruszyć?", location.Name);
                
                filtered
                    .ToList()
                    .ForEach(x=>Console.WriteLine("["+(++locationNr)+"] "+x));
                
                Console.WriteLine("[X] Powrót");
                if(mistake)
                    Console.WriteLine("Brak wskazanej opcji. Spróbuj ponownie.");
                Console.Write("Nr: ");
                optionString = Console.ReadLine();
                if(optionString=="X")
                    break;
                if (int.TryParse(optionString, out option) == true && int.Parse(optionString) <= filtered.Count())
                    return filtered.ToList()[int.Parse(optionString) - 1];
                mistake = true;
            }

            return location.Name;
        }
        
    }
}