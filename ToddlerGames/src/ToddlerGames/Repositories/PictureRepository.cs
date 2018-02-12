using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToddlerGames.Models;
using ToddlerGames.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ToddlerGames.Repositories
{
    public class PictureRepository : IPicturesRepository
    {
        private ApplicationDbContext context;

        public PictureRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
       

        public IEnumerable<Picture> GetAllPictures()
        {
            return context.Pictures.Include(m => m.PhotoId);
        }
       
        public void Add(IEnumerable<Picture> picture)
        {
            context.Add(picture);
            context.SaveChanges();
        }

        
    }
}



