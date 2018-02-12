using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ToddlerGames.Models
{
    public class Member : IdentityUser
    {

        [Key]
        public int MemberID { get; set; }
        public string Name { get; set; }
        //public override string Email { get; set; }
        public string Password { get; set; }
    }
}
