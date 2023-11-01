using Models;

namespace DataAccess.Interfaces
{
    public interface IPerformanceProvider
    {
        void Create(PerformanceInfo performanceInfo);
        void Delete(int performanceId);
        List<PerformanceInfo> GetAll(int concertId);
        PerformanceInfo Get(int performanceId);
        void Update(PerformanceInfo performanceInfo);
    }
}