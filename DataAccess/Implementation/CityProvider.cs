using DataAccess.Data;
using DataAccess.Implementation.Base;
using DataAccess.Interfaces;
using Models;

namespace DataAccess.Implementation
{
    public class CityProvider : DictionaryDataProviderBase<City>, ICityProvider
    {
        public CityProvider(DataDbContext db) : base(db)
        {
        }
    }
}
