using System;

namespace NFO{
    class HeroDialogPart{
        public HeroDialogPart(){}
        public HeroDialogPart(string dialogPart){
            DialogPart=dialogPart;
        }
        public HeroDialogPart(string dialogPart, NpcDialogPart npcDialogPart){
            DialogPart=dialogPart;
            NpcDialogPart=npcDialogPart;
        }

        public string DialogPart{get; set;}
        public NpcDialogPart NpcDialogPart{get; set;}
    }
}