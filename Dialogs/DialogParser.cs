namespace NFO{
    public class DialogParser {
        private Hero _hero;
        public DialogParser(Hero hero) {
            _hero = hero;
        }

        public string ParseDialog(IDialogPart iDialogPart){
            return iDialogPart.GetContent().Replace("#HERONAME#", _hero.Name);
        }
    }
}