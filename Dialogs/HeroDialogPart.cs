using System;

namespace NFO{
    public class HeroDialogPart : IDialogPart{
        public HeroDialogPart(string dialogPart, NpcDialogPart npcDialogPart){
            DialogPart=dialogPart;
            NpcDialogPart=npcDialogPart;
        }

        private string DialogPart;
        public NpcDialogPart NpcDialogPart{get;}
        public string GetContent() {
            return DialogPart;
        }
    }
}