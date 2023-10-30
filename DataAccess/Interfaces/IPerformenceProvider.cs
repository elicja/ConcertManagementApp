using Models;

namespace DataAccess.Interfaces
{
    public interface IPerformenceProvider
    {
        void Create(PerformenceInfo performenceInfo);
        void Delete(int id);
        List<PerformenceInfo> GetAll(int concertId);
        PerformenceInfo Get(int id);
        void Update(PerformenceInfo performenceInfo);
    }
}