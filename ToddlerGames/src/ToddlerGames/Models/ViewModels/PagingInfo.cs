using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToddlerGames.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages =>
        (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        public string currentPage { get; set; }
        public int pages { get; set; }
    }
}