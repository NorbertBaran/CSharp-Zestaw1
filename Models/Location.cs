using System;
using System.Collections.Generic;
using System.Linq;

namespace NFO{
    public class Location{
        public Location(ELocationNames name){
            Name=name;
            NonPlayerCharacters=NPCList.Get(name);
            IsUnlocked = name != ELocationNames.Radom && name != ELocationNames.Sonsowiec;
        }

        public ELocationNames Name{get;}
        public List<NonPlayerCharacter> NonPlayerCharacters{get;}
        public bool IsUnlocked { get; set; }
    }

    public enum ELocationNames{
        Calimport,
        Neverwinter,
        Silverymoon,
        Radom,
        Sonsowiec,
        Bydgoszcz
    }

    public static class NPCList{
        public static List<NonPlayerCharacter> Get(ELocationNames location){
            return new List<NonPlayerCharacter>{
                new NonPlayerCharacter("Akara", Dialogs.AkaraDialog),
                new NonPlayerCharacter("Charsi", Dialogs.CharsiDialog)
            };
        }
    }
}