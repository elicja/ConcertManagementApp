using Models;

namespace DataAccess.Interfaces
{
    public interface IConcertProvider
    {
        void AddNewConcert(ConcertInfo concertInfo);
        void DeleteConcert(int id);
        ConcertInfo Get(int id);
        List<ConcertInfo> GetAll();
        void UpdateConcert(ConcertInfo concertInfo);
    }
}