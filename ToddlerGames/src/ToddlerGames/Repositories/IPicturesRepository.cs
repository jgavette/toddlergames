using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToddlerGames.Models.ViewModels;
using ToddlerGames.Models;


namespace ToddlerGames.Repositories
{
    public interface IPicturesRepository
    {
        IEnumerable<Picture> GetAllPictures();

        void Add(IEnumerable<Picture> picture);
    }
}
