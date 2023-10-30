using DataAccess.Data;
using DataAccess.Implementation.Base;
using DataAccess.Interfaces;
using Models;

namespace DataAccess.Implementation
{
    public class ArtistProvider : DictionaryDataProviderBase<Artist>, IArtistProvider
    {
        public ArtistProvider(DataDbContext db) : base(db)
        {
        }
    }
}
