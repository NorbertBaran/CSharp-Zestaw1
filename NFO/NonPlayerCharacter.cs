using System;
using System.Collections.Generic;
using System.Linq;

namespace NFO{
    class NonPlayerCharacter{
        public NonPlayerCharacter(String name){
            Name=name;
        }

        public String Name{get;}
        public NpcDialogPart StartTalking(){
            return null;
        }
    }
}