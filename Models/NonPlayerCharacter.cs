using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NFO{
    public class NonPlayerCharacter{
        public NonPlayerCharacter(String name, NpcDialogPart dialog){
            Name = name;
            StartTalking= dialog;
        }

        public String Name{get;}
        public NpcDialogPart StartTalking { get; }
    }
}