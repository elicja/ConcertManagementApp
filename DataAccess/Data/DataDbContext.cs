using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class DataDbContext : DbContext
    {
        IConfiguration _configuration;

        public DataDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<MusicGenre> MusicGenres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ConcertInfo> ConcertsInfo { get; set; }
        public DbSet<PerformenceInfo> PerformencesInfo { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("Default"));
        }
    }
}
