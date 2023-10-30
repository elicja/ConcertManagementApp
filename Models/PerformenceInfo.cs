using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class PerformenceInfo
    {
        public int Id { get; set; }

        [ForeignKey(nameof(ConcertId))]
        public ConcertInfo ConertInfo { get; set; }
        public int ConcertId { get; set; }

        [ForeignKey(nameof(ArtistId))]
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public string StartHour { get; set; }
    }
}
