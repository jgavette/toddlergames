using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ToddlerGames.Models;


namespace ToddlerGames.Repositories
{
    public class AppIdentityDbContext : IdentityDbContext<Member>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
        : base(options) { }
    }
}
