using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class PerformanceInfo
    {
        public int Id { get; set; }

        [ForeignKey(nameof(ConcertId))]
        public ConcertInfo ConcertInfo { get; set; }
        public int ConcertId { get; set; }

        [ForeignKey(nameof(ArtistId))]
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public string StartHour { get; set; }
    }
}
