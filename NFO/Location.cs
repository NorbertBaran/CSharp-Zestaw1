using System;
using System.Collections.Generic;
using System.Linq;

namespace NFO{
    class Location{
        public Location(ELocationNames name){
            Name=name;
            NonPlayerCharacters=NPCList.Get(name);
        }

        public ELocationNames Name{get;}
        public List<NonPlayerCharacter> NonPlayerCharacters{get;}
    }

    enum ELocationNames{
        Calimport,
        Neverwinter,
        Silverymoon
    }

    static class NPCList{
        public static List<NonPlayerCharacter> Get(ELocationNames location){
            return new List<NonPlayerCharacter>{
                new NonPlayerCharacter("Akara"),
                new NonPlayerCharacter("Charsi")
            };
        }
    }

}