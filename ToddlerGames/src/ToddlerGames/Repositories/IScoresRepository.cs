using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToddlerGames.Models.ViewModels;
using ToddlerGames.Models;


namespace ToddlerGames.Repositories
{
    public interface IScoresRepository
    {
        IEnumerable<Score> GetAllScores();

        //void Add(Score Score);
        void Add(IEnumerable<Score> score);
    }
}
