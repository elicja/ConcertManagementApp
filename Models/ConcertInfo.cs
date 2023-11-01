using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class ConcertInfo
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } 
        public double TicketPrice { get; set; }
        public string Address { get; set; }

        [ForeignKey(nameof(CityId))]
        [ValidateNever]
        public City City { get; set; }
        public int CityId { get; set; }

        [ForeignKey(nameof(MusicGenreId))]
        [ValidateNever]
        public MusicGenre MusicGenre { get; set; }
        public int MusicGenreId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [ValidateNever]
        public ICollection<PerformenceInfo> Performences { get; set; }
    }
}
