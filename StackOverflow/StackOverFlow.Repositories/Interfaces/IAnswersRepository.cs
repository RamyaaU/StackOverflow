using StackOverFlow.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverFlow.Repositories.Interfaces
{
    public interface IAnswersRepository
    {
        void InsertAnswer(Answer answer);

        void UpdateAnswer(Answer answer);

        void UpdateAnswerVotesCount(int answerId, int userId, int value);
        void DeleteAnswer(int answerId);

        List<Answer> GetAnswerByQuestionId(int questionId);
        List<Answer> GetAnswerByAnswerId(int answerId);
    }
}
