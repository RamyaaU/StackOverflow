using System;
using System.Collections.Generic;
using System.Linq;
using StackOverFlow.DomainModels;
using StackOverFlow.Repositories.Interfaces;

namespace StackOverFlow.Repositories
{
    public class AnswersRepository : IAnswersRepository
    {
        private readonly StackOverflowDatabaseDbContext _context;
        private readonly IQuestionRepository _questionRepository;
        private readonly IVotesRepository _votesRepository;

        public AnswersRepository(StackOverflowDatabaseDbContext context, 
            QuestionRepository questionRepository,
            VotesRepository votesRepository)
        {
            _context = context;
            _questionRepository = questionRepository;
            _votesRepository = votesRepository;
        }

        public void InsertAnswer(Answer answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
            _questionRepository.UpdateQuestionAnswersCount(answer.QuestionId, 1);
        }

        public void UpdateAnswer(Answer answer)
        {
            Answer answer1 = _context.Answers.Where(a => a.AnswerId == answer.AnswerId).FirstOrDefault();
            if ( answer1 != null )
            {
                answer1.AnswerText = answer.AnswerText;
                _context.SaveChanges();
            }
        }

        public void UpdateAnswerVotesCount(int answerId, int userId, int value)
        {
            Answer answer1 = _context.Answers.Where(a => a.AnswerId == answerId).FirstOrDefault();
            if (answer1 != null)
            {
                answer1.VotesCount += value;
                _context.SaveChanges();
                _questionRepository.UpdateQuestionsVotesCount(answer1.QuestionId, value);
                _votesRepository.UpdateVote(answerId, userId, value);
            }
        }

        public void DeleteAnswer(int answerId)
        {
            Answer answer = _context.Answers.Where(a => a.AnswerId == answerId).FirstOrDefault();
            if(answer != null)
            {
                _context.Answers.Remove(answer);
                _context.SaveChanges();
                _questionRepository.UpdateQuestionAnswersCount(answer.QuestionId, -1);
            }
        }

        public List<Answer> GetAnswerByQuestionId(int questionId)
        {
            List<Answer> answer = _context.Answers.Where(a => a.QuestionId == questionId).OrderByDescending(x => x.AnswerDateAndTime).ToList();
            return answer;
        }

        public List<Answer> GetAnswerByAnswerId(int answerId)
        {
            List<Answer> answer = _context.Answers.Where(a => a.AnswerId == answerId).ToList();
            return answer;
        }        
    }
}
