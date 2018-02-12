using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToddlerGames.Models.ViewModels
{
    public class ScoresViewModel
    {
        [key]
        public int Scorekey { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public Member From { get; set; }
        public string Topic { get; set; }
        public IEnumerable<Score> Score { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int membersID { get; set; }
        public virtual Member members { get; set; }
    }
}
