using Models;

namespace DataAccess.Interfaces
{
    public interface IConcertProvider
    {
        void AddNewConcert(ConcertInfo concertInfo);
        void DeleteConcert(int concertId);
        ConcertInfo Get(int concertId);
        List<ConcertInfo> GetAll();
        void UpdateConcert(ConcertInfo concertInfo);
    }
}