﻿using DataAccess.Data;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Implementation
{
    public class ConcertProvider : IConcertProvider
    {
        private DataDbContext _db;

        public ConcertProvider(DataDbContext db)
        {
            _db = db;
        }

        public List<ConcertInfo> GetAll()
        {
            List<ConcertInfo> concerts = _db.ConcertsInfo
                                         .Include(x => x.MusicGenre)
                                         .Include(x => x.City)
                                         .Include(x => x.Performances)
                                             .ThenInclude(x => x.Artist)
                                             .ToList();

            return concerts;
        }

        public ConcertInfo Get(int concertId)
        {
            ConcertInfo concert = _db.ConcertsInfo
                                         .Include(x => x.MusicGenre)
                                         .Include(x => x.City)
                                         .Include(x => x.Performances)
                                             .ThenInclude(x => x.Artist)
                                             .FirstOrDefault(x => x.Id == concertId);

            return concert;
        }

        public void AddNewConcert(ConcertInfo concertInfo)
        {
            _db.ConcertsInfo.Add(concertInfo);
            _db.SaveChanges();
        }

        public void UpdateConcert(ConcertInfo concertInfo)
        {
            _db.ConcertsInfo.Update(concertInfo);
            _db.SaveChanges();
        }

        public void DeleteConcert(int concertId)
        {
            ConcertInfo concert = _db.ConcertsInfo.FirstOrDefault(x => x.Id == concertId);
            _db.ConcertsInfo.Remove(concert);
            _db.SaveChanges();
        }
    }
}
