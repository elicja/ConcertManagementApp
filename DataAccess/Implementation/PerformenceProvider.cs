using DataAccess.Data;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Implementation
{
    public class PerformenceProvider : IPerformenceProvider
    {
        private DataDbContext _db;

        public PerformenceProvider(DataDbContext db)
        {
            _db = db;
        }

        public List<PerformenceInfo> GetAll(int concertId)
        {
            List<PerformenceInfo> performenceInfo = _db.PerformencesInfo
                                              .Include(x => x.Artist)
                                              .Where(x=>x.ConcertId==concertId)
                                              .ToList();

            return performenceInfo;
        }

        public PerformenceInfo Get(int id)
        {
            PerformenceInfo performenceInfo = _db.PerformencesInfo
                                              .Include(x => x.Artist)
                                              .FirstOrDefault(x => x.Id == id);

            return performenceInfo;
        }

        public void Create(PerformenceInfo performenceInfo)
        {
            _db.PerformencesInfo.Add(performenceInfo);
            _db.SaveChanges();
        }

        public void Update(PerformenceInfo performenceInfo)
        {
            _db.PerformencesInfo.Update(performenceInfo);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            PerformenceInfo performenceInfo = _db.PerformencesInfo.FirstOrDefault(x => x.Id == id);
            _db.PerformencesInfo.Remove(performenceInfo);
            _db.SaveChanges();
        }
    }
}
