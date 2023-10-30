using Models.Base;

namespace Models
{
    public class City : DictionaryTableBase
    {
        public City()
        {
            
        }

        public City(DictionaryTableBase dictionaryTableBase)
        {
            this.Id = dictionaryTableBase.Id;
            this.Value = dictionaryTableBase.Value;
        }
    }
}
