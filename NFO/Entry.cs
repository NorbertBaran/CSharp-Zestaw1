using System;

namespace NFO
{
    static class Entry
    {
        static String _name="NFO";

        public static void Main(string[] args) {
            Screens.StartingEntry();
            string entryChoice = GameLogic.InputEntryChoice();
            GameLogic.InitGame(entryChoice);
        }
    }
}
