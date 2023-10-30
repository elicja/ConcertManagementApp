using Models.Base;

namespace Models
{
    public class MusicGenre : DictionaryTableBase
    {
        public MusicGenre()
        {
            
        }

        public MusicGenre(DictionaryTableBase dictionaryTableBase)
        {
            this.Id = dictionaryTableBase.Id;
            this.Value = dictionaryTableBase.Value;
        }
    }
}
