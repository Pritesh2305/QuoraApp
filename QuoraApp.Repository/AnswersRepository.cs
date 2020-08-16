using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoraApp.DomainModels;

namespace QuoraApp.Repository
{
    public interface IAnswersRepository
    {
        void InsertAnswer(Answer a);

        void UpdateAnswer(Answer a);

        void UpdateAnswerVoteCount(int aid, int uid, int value);

        void DeleteAnswer(int aid);

        List<Answer> GetAnswersByQustionID(int qid);

        List<Answer> GetAnswersByAnswerID(int aid); 

    }

    public class AnswersRepository : IAnswersRepository
    {
        QuoraDBDataContext dc;

        public AnswersRepository()
        {
            dc = new QuoraDBDataContext();
        }

        public void DeleteAnswer(int aid)
        {
            dc.Answers.Remove(dc.Answers.Find(aid));
            dc.SaveChanges();
        }

        public List<Answer> GetAnswersByAnswerID(int aid)
        {
            List<Answer> answers = (from p in dc.Answers
                                    where p.AnswerID == aid
                                    orderby p.AnswerID
                                    select p
                                    ).ToList();
            return answers;
        }

        public List<Answer> GetAnswersByQustionID(int qid)
        {
            List<Answer> answers = (from p in dc.Answers
                                    where p.QuestionID == qid
                                    orderby p.AnswerID
                                    select p
                                      ).ToList();
            return answers;

        }

        public void InsertAnswer(Answer a)
        {
            dc.Answers.Add(a);
            dc.SaveChanges();         
        }

        public void UpdateAnswer(Answer a)
        {
            Answer existinganswer = (from p in dc.Answers
                                           where p.AnswerID == a.AnswerID
                                           select p
                                           ).FirstOrDefault();
            if (existinganswer !=null)
            {
                existinganswer.AnswerText = a.AnswerText;
                existinganswer.QuestionID = a.QuestionID;
                existinganswer.Votes = a.Votes;
                existinganswer.AnswerDateAndTime = a.AnswerDateAndTime;
                existinganswer.UserID = a.UserID;
                dc.SaveChanges();
            }
        }

        public void UpdateAnswerVoteCount(int aid, int uid, int value)
        {
            Answer existinganswer = (from p in dc.Answers
                                     where p.AnswerID == aid && p.UserID == uid
                                     select p
                                     ).FirstOrDefault();

            if (existinganswer != null)
            {
                existinganswer.VotesCount = value;
                dc.SaveChanges();
            }
        }
    }
}
