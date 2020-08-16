using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoraApp.DomainModels;

namespace QuoraApp.Repository
{
    public interface IQuestionsRepository
    {
        void InsertQuestion(Question Q);

        void UpdateQuestion(Question Q);

        void UpdateQuestionsVoteCount(int qid, int value);

        void UpdateQuestionsAnswerCount(int qid, int value);

        void UpdateQuestionsViewsCount(int qid);

        List<Question> GetQuestions();

        List<Question> GetQuestionsByID(int qid);

    }

    public class QuestionsRepository : IQuestionsRepository
    {
        QuoraDBDataContext dc;

        public QuestionsRepository()
        {
            dc = new QuoraDBDataContext();
        }

        public List<Question> GetQuestions()
        {
            List<Question> Questions = (from p in dc.Questions
                                        orderby p.QuestionName
                                        select p
                                        ).ToList();
            return Questions;
        }

        public List<Question> GetQuestionsByID(int qid)
        {
            List<Question> questions = (from p in dc.Questions
                                        where p.QuestionID == qid
                                        orderby p.QuestionName
                                        select p
                                        ).ToList();
            return questions;
        }

        public void InsertQuestion(Question Q)
        {
            dc.Questions.Add(Q);
            dc.SaveChanges();            
        }

        public void UpdateQuestion(Question Q)
        {
            Question existingquestion = (from p in dc.Questions
                                         where p.QuestionID == Q.QuestionID
                                         select p
                                         ).FirstOrDefault();

            if (existingquestion != null)
            {
                existingquestion.QuestionName = Q.QuestionName;
                existingquestion.QuestionDateAndTime = Q.QuestionDateAndTime;
                existingquestion.UserID = Q.UserID;
                existingquestion.CategoryID = Q.CategoryID;
                dc.SaveChanges();
            }
        }

        public void UpdateQuestionsAnswerCount(int qid, int value)
        {
            Question existingquestion = (from p in dc.Questions
                                         where p.QuestionID == qid
                                         select p
                                         ).FirstOrDefault();

            if (existingquestion != null)
            {
                existingquestion.AnswersCount = value;
                dc.SaveChanges();
            }
        }

        public void UpdateQuestionsViewsCount(int qid)
        {
            Question existingquestion = (from p in dc.Questions
                                         where p.QuestionID == qid
                                         select p
                                        ).FirstOrDefault();

            if (existingquestion != null)
            {
                existingquestion.ViewsCount += 1;
                dc.SaveChanges();
            }
        }

        public void UpdateQuestionsVoteCount(int qid, int value)
        {
            Question existingquestion = (from p in dc.Questions
                                         where p.QuestionID == qid
                                         select p
                                       ).FirstOrDefault();

            if (existingquestion != null)
            {
                existingquestion.VotesCount = value;
                dc.SaveChanges();
            }
        }
    }
}
