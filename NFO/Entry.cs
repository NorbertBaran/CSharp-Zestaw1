using System;
using System.Text.RegularExpressions;

namespace NFO
{
    static class Entry
    {
        static String _name="NFO";

        public static void Main(string[] args)
        {
            string menuOption;
            bool isMenuOptionCorrect()=>menuOption=="1" || menuOption=="X" ? true : false;
            Console.WriteLine(
                    "Witaj w grze {0}\n[1] Zacznij nową grę\n[X] Zamknij program",
                    _name
                );
            do{
                Console.Write("Nr: ");
                menuOption=Regex.Replace(Console.ReadLine(), @"\s+", "");
                if(!isMenuOptionCorrect())
                    Console.WriteLine("Wybrana opcja jest niewłaściwa");
            }while(!isMenuOptionCorrect());
            
            if(menuOption == "1")
                GameInit.Init();
            else
                Environment.Exit(0);
        }
    }
}
