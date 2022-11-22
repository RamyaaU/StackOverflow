using StackOverFlow.DomainModels;
using StackOverFlow.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverFlow.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly StackOverflowDatabaseDbContext _context;

        public QuestionRepository(StackOverflowDatabaseDbContext context)
        {
            _context = context;
        }

        public void InsertQuestion(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }

        public void UpdateQuestionDetails(Question question)
        {
            Question question1 = _context.Questions.Where(q => q.QuestionId == question.QuestionId).FirstOrDefault();
            if (question1 != null)
            {
                question1.CategoryId = question.CategoryId;
                question1.QuestionDateAndTime = question.QuestionDateAndTime;
                question1.QuestionName = question1.QuestionName;
                _context.SaveChanges();
            }
        }

        public void UpdateQuestionsVotesCount(int questionid, int value)
        {
            Question question = _context.Questions.Where(q => q.QuestionId == questionid).FirstOrDefault();
            if (question != null)
            {
                question.VotesCount = value;
                _context.SaveChanges();
            }
        }

        public void UpdateQuestionAnswersCount(int questionid, int value)
        {
            Question question = _context.Questions.Where(q => q.QuestionId == questionid).FirstOrDefault();
            if (question != null)
            {
                question.AnswersCount += value;
                _context.SaveChanges();
            }
        }

        public void UpdateQuestionViewsCount(int questionid, int value)
        {
            Question question = _context.Questions.Where(q => q.QuestionId == questionid).FirstOrDefault();
            if (question != null)
            {
                question.AnswersCount += value;
                _context.SaveChanges();
            }
        }

        public void DeleteQuestion(int qid)
        {
            Question question = _context.Questions.Where(q => q.QuestionId == qid).FirstOrDefault();
            if (question != null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();
            }
        }

        public List<Question> GetQuestions()
        {
            List<Question> questions = _context.Questions.OrderByDescending(x => x.QuestionDateAndTime).ToList();
            return questions;
        }

        public List<Question> GetQuestionByQuestionId(int questionid)
        {
            List<Question> questions = _context.Questions.Where(x => x.QuestionId == questionid).ToList();
            return questions;
        }
    }
}
        
