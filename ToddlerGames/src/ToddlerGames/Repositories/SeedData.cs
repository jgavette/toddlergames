using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ToddlerGames.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;




namespace ToddlerGames.Repositories
{
    public class SeedData
    {
        // public static void EnsurePopulated(IApplicationBuilder app)
        public static async Task EnsurePopulated(IApplicationBuilder app)

        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();



            //#region UserRolesRegion

            
         if (!context.Members.Any())
            {

                #region Identity

                string adminRole = "Admin";
                string memberRole = "Member";

                UserManager<Member> userManager = app.ApplicationServices.GetRequiredService<UserManager<Member>>();
                RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();

                if (await roleManager.FindByNameAsync(adminRole) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(adminRole));
                }
                if (await roleManager.FindByNameAsync(memberRole) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(memberRole));
                }


                #region works adds net user admin role 
                // Add one user.
                string username = "Admin";
                string email = "admin@gmail.com";
                string password = "Password123";

                Member user = await userManager.FindByNameAsync(username);
                if (user == null)
                {
                    user = new Member { UserName = username, Email = email, Password = password };
                    IdentityResult result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, adminRole);
                    }
                }
                #endregion

                context.Members.AddRange(
               new Member() { Name = "Fred William", Email = "thebiggestwall@example.gov", Password = "4wheeler" },
               new Member() { Name = "Fry Burger", Email = "ilikebasketball@example.com", Password = "igotreallyold321" },
               new Member() { Name = "Bill Nye", Email = "scienceiscool@example.com", Password = "globalwarmingisreal" }
               
           );




                #endregion



                #region SeedDataRegion

                var member1 = new Member { Name = "Member0ne", Email = "Bademail1@mail.com", Password = "Memberonepassword" };
                context.Members.Add(member1);
                var Score1 = new Models.Score { ScoreNum = 1, Body = "Big Moma jokes are hurtful", Date = DateTime.Now, From = member1, Topic = "stuff she says" };
                context.Scores.Add(Score1);

                var member2 = new Member { Name = "Membertw0", Email = "Bademail2@mail.com", Password = "MemberTwopassword" };
                context.Members.Add(member2);
                var Score2 = new Models.Score { ScoreNum = 4, Body = "Big Moma jokes are hurtful", Date = DateTime.Now, From = member2, Topic = "Topic 2" };
                context.Scores.Add(Score2);//working / score is int

                var member3 = new Member { Name = "Memberthree", Email = "Bademail3@mail.com", Password = "MemberThreepassword" };
                context.Members.Add(member3);
                var Score3 = new Models.Score { ScoreNum = 3, Body = "Big Dad jokes are hurtful", Date = DateTime.Now, From = member3, Topic = "Topic 3" };
                context.Scores.Add(Score3);

                var member4 = new Member { Name = "MemberFour", Email = "Bademail4@mail.com", Password = "MemberThreepassword" };
                context.Members.Add(member4);
                var Score4 = new Models.Score { ScoreNum = 4, Body = "Big Moma jokes are hurtful", Date = DateTime.Now, From = member4, Topic = "Topic 4" };
                context.Scores.Add(Score4);

                var member5 = new Member { Name = "MemberFive", Email = "Bademail5@mail.com", Password = "MemberFivepassword" };
                context.Members.Add(member5);
                var Score5 = new Models.Score { ScoreNum = 5, Body = "Dad", Date = DateTime.Now, From = member5, Topic = "Stop" };
                context.Scores.Add(Score5);

                var member6 = new Member { Name = "BillNewy", Email = "Bademail5@mail.com", Password = "MemberSixpassword" };
                context.Members.Add(member5);
                var Score6 = new Score { ScoreNum = 5, Body = "we win!", Date = DateTime.Now, From = member6, Topic = "stuff ontop od f stuff" };
                context.Scores.Add(Score6);

                #endregion
            }
            //await EnsurePopulated(app);
            context.SaveChanges();
        }
    }
}



