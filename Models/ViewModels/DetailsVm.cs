using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class DetailsVm
    {
        public List<Artist> Artists { get; set; }
        public List<MusicGenre> MusicGenres { get; set; }
        public List<City> Cities { get; set; }
    }
}
