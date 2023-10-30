using DataAccess.Data;
using DataAccess.Implementation.Base;
using DataAccess.Interfaces;
using Models;

namespace DataAccess.Implementation
{
    public class MusicGenreProvider : DictionaryDataProviderBase<MusicGenre>,IMusicGenreProvider
    {
        public MusicGenreProvider(DataDbContext db) : base(db)
        {
        }
    }
}
