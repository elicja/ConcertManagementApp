using DataAccess.Data;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Implementation
{
    public class PerformanceProvider : IPerformanceProvider
    {
        private DataDbContext _db;

        public PerformanceProvider(DataDbContext db)
        {
            _db = db;
        }

        public List<PerformanceInfo> GetAll(int concertId)
        {
            List<PerformanceInfo> performanceInfo = _db.PerformancesInfo
                                              .Include(x => x.Artist)
                                              .Where(x=>x.ConcertId==concertId)
                                              .ToList();

            return performanceInfo;
        }

        public PerformanceInfo Get(int performanceId)
        {
            PerformanceInfo performanceInfo = _db.PerformancesInfo
                                              .Include(x => x.Artist)
                                              .FirstOrDefault(x => x.Id == performanceId);

            return performanceInfo;
        }

        public void Create(PerformanceInfo performanceInfo)
        {
            _db.PerformancesInfo.Add(performanceInfo);
            _db.SaveChanges();
        }

        public void Update(PerformanceInfo performanceInfo)
        {
            _db.PerformancesInfo.Update(performanceInfo);
            _db.SaveChanges();
        }

        public void Delete(int performanceId)
        {
            PerformanceInfo performanceInfo = _db.PerformancesInfo.FirstOrDefault(x => x.Id == performanceId);
            _db.PerformancesInfo.Remove(performanceInfo);
            _db.SaveChanges();
        }
    }
}
