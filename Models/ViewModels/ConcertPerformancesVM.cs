namespace Models.ViewModels
{
    public class ConcertPerformancesVM
    {
        public int ConcertId { get; set; }
        public List<PerformanceInfo> Performances { get; set; }
    }
}
