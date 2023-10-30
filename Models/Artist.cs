using Models.Base;

namespace Models
{
    public class Artist : DictionaryTableBase
    {
        public Artist()
        {
            
        }

        public Artist(DictionaryTableBase dictionaryTableBase)
        {
            this.Id = dictionaryTableBase.Id;
            this.Value = dictionaryTableBase.Value;
        }
    }
}
