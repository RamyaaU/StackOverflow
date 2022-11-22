using StackOverFlow.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverFlow.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        void InsertQuestion(Question question);

        void UpdateQuestionDetails(Question question);

        void UpdateQuestionsVotesCount(int questionid, int value);

        void UpdateQuestionAnswersCount(int questionid, int value);

        void UpdateQuestionViewsCount(int questionid, int value);

        void DeleteQuestion(int qid);

        List<Question> GetQuestions();

        List<Question> GetQuestionByQuestionId(int questionid);
    }
}
