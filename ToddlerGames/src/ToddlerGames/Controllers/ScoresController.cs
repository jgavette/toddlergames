using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToddlerGames.Repositories;
using ToddlerGames.Models;
using ToddlerGames.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

public class ScoresController : Controller
{
    public IScoresRepository scoresRepository;
    public IMemberRepository membersRepository;

    //IScoresRepository repository;
    public ScoresController(IScoresRepository repository, IMemberRepository members)
    {
        ViewData["Message"] = "Baby Leader Board";
        scoresRepository = repository;
        membersRepository = members;
    }
    public int PageSize = 4;
    public ViewResult Scores() => View(scoresRepository.GetAllScores().ToList());

    public ViewResult ScoresByTopic(string topic) => View("Scores", scoresRepository.GetAllScores().Where(m => m.Topic.Contains("Topic")).ToList());

    public ViewResult ScoresByBody(string body) => View("Scores", scoresRepository.GetAllScores().Where(m => m.Body.Contains("Dad")).ToList());
    public ViewResult ScoresByBodyBig(string body) => View("Scores", scoresRepository.GetAllScores().Where(m => m.Body.Contains("Big")).ToList());
    public ViewResult List(int page = 1) => View(new ScoresViewModel
    {
        Score = scoresRepository.GetAllScores()
                .OrderBy(m => m.From.MemberID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

        PagingInfo = new PagingInfo
        {
            CurrentPage = page,
            ItemsPerPage = PageSize,
            TotalItems = scoresRepository.GetAllScores().Count()
        }
    });

    [HttpPost]
    public ActionResult CreateNew(int ScoreNum)
    {
        return View("Scores", new ScoresViewModel
        { Score = scoresRepository.GetAllScores(), Scorekey = new Score { ScoreNum = ScoreNum } });
    }

    [HttpGet]
    public ActionResult CreateNew()
    {
        return View("Scores", new ScoresViewModel
        { Score = scoresRepository.GetAllScores() });
    }

    [HttpPost]
    public ActionResult PostScore(ScoresViewModel vm)
    {
        if (ModelState.IsValid)
        {


            vm.Scorekey = 9;
            scoresRepository.Add(vm.Score.Where(m => m.ScoreID.Equals(2)).ToList());
            return View("Scores", new ScoresViewModel
            { Score = scoresRepository.GetAllScores() });
            //ViewBag.ErrorMessage = string.Empty;
        }
        else
            ViewBag.ErrorMessage = "Could not store Score into database";
        return RedirectToAction("Scores");//attempts to return to message index view
    }
}
//    public IActionResult Scores()
//    {
//        return View("Scores", new ScoresViewModel());
//    }
//}

