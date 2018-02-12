using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToddlerGames.Repositories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace ToddlerGames.Models
{
    public class Score
    {

        [Key]
        public int ScoreID { get; set; }
        //[Required(ErrorMessage = "Please enter a Score title")]
        public int ScoreNum { get; set; }
        //[Required(ErrorMessage = "Please enter content into the body of this message")]
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public Member From { get; set; }
        //[Required(ErrorMessage = "Please enter a topic")]
        public string Topic { get; set; }

        public static implicit operator int(Score v)
        {
            throw new NotImplementedException();
        }
    }


}
