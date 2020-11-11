using System;
using System.Collections.Generic;
using System.Linq;

namespace NFO{
    public class NpcDialogPart : IDialogPart{
        public NpcDialogPart(string dialogPart, List<HeroDialogPart> heroDialogParts){
            DialogPart=dialogPart;
            HeroDialogParts=heroDialogParts;
        }

        private string DialogPart;
        public List<HeroDialogPart> HeroDialogParts{get; set;}
        public string GetContent(){
            return DialogPart;
        }
    }
}