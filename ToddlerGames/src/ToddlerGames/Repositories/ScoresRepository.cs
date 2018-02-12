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
    public class ScoresRepository : IScoresRepository
    {
        private ApplicationDbContext context;

        public ScoresRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        //public IEnumerable<Models.ScoresRepository> Scores => new List<Models.ScoresRepository>()
        //{

        //    new Models.ScoresRepository() { ScoreNum = 1, Body = "Test Body1", Date = DateTime.Now,  Topic = "Test Topic1" },
        //    new Models.ScoresRepository() { ScoreNum = 2, Body = "Test Body2", Date = DateTime.Now,  Topic = "Test Topic2" },
        //    new Models.ScoresRepository() { ScoreNum = 3, Body = "Test Body3", Date = DateTime.Now,  Topic = "Test Topic3" },
        //    new Models.ScoresRepository() { ScoreNum = 4, Body = "Test Body4", Date = DateTime.Now,  Topic = "Test Topic4" },
        //};

        public IEnumerable<Score> GetAllScores()
        {
            return context.Scores.Include(m => m.From);
        }
        public IEnumerable<Score> GetAllScoresByDate(DateTime date)
        {
            return context.Scores.Where(m => m.Date.Date == date.Date).ToList();
        }

        public IEnumerable<Models.Score> GetAllScoresByTopic(string topic)
        {
            return context.Scores.Where(m => m.Topic == topic).ToList();
        }

        public IEnumerable<Models.Score> GetAllScoressByUser(Member from)
        {
            return context.Scores.Where(m => m.From.MemberID == from.MemberID).ToList();
        }
        public IEnumerable<Models.Score> GetAllScoresByBody(string body)
        {
            return context.Scores.Where(m => m.Body == body).ToList();
        }
        //public void Add(Score Scores)
        //{
        //    context.Add(Scores);
        //    context.SaveChanges();
        //}

       

        public void Add(IEnumerable<Score> score)
        {
            context.Add(score);
            context.SaveChanges();
        }
    }
}



