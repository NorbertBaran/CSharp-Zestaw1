using System.Text.RegularExpressions;

namespace NFO{
    public class Hero{
        public string Name{get;}
        public EHeroClass EHeroClass{get;}
        public Hero(string name, EHeroClass eHeroClass){
            Name=name;
            EHeroClass=eHeroClass;
        }
    }
}