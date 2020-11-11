using System;
using System.Collections.Generic;
using System.Linq;

namespace NFO{
    class NpcDialogPart{
        public NpcDialogPart(){}
        public NpcDialogPart(string dialogPart){
            DialogPart=dialogPart;
        }
        public NpcDialogPart(string dialogPart, List<HeroDialogPart> heroDialogParts){
            DialogPart=dialogPart;
            HeroDialogParts=heroDialogParts;
        }

        public string DialogPart{get; set;}
        public List<HeroDialogPart> HeroDialogParts{get; set;}
    }
}