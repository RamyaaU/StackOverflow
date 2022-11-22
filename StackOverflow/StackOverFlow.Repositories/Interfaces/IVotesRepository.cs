using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverFlow.Repositories.Interfaces
{
    public interface IVotesRepository
    {
        void UpdateVote(int answerId, int userId, int value);
    }
}
