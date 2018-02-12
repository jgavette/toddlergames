using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToddlerGames.Models;
using Microsoft.EntityFrameworkCore;

namespace ToddlerGames.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private ApplicationDbContext context;

        public MemberRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Member> GetAllMembers => context.Members;

        public void Add(Member Members)
        {
            context.Add(Members);
            context.SaveChanges();
        }

    }
}