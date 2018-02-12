using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ToddlerGames.Models
{
    public class Picture
    {
        [Key]
        public int PhotoId { get; set; }

        [Display(Name = "Decription")]
 
        public String Description { get; set; }

        [Display(Name = "Image Path")]
        public String ImagePath { get; set; }

  


      
    }
}
