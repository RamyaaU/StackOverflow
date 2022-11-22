using StackOverFlow.DomainModels;
using StackOverFlow.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverFlow.Repositories
{
    public class VotesRepository : IVotesRepository
    {
        private readonly StackOverflowDatabaseDbContext _context;
        
        public VotesRepository(StackOverflowDatabaseDbContext context)
        {
            _context = context;
        }

        public void UpdateVote(int answerId, int userId, int value)
        {
            int updateValue;
            if (value > 0) updateValue = 1;
            else if (value < 0) updateValue = -1;
            else updateValue = 0;

            Vote vote = _context.Votes.Where(x => x.AnswerId == answerId && x.UserId == userId).FirstOrDefault();

            if(vote != null )
            {
                vote.VoteValue = updateValue;
            }
            else
            {
                Vote newVote = new Vote()
                {
                    AnswerId = answerId,
                    UserId = userId,
                    VoteValue = value
                };
                _context.Votes.Add(newVote);
            }
            _context.SaveChanges();
        }

    }
}
