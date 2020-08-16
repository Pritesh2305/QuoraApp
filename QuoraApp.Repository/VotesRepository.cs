using System;
using QuoraApp.DomainModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoraApp.Repository
{
    public interface IVotesRepository
    {
        void UpdateVote(int aid, int uid, int value);
    }

    public class VotesRepository : IVotesRepository
    {
        QuoraDBDataContext dc;

        public VotesRepository()
        {
            dc = new QuoraDBDataContext();
        }

        public void UpdateVote(int aid, int uid, int value)
        {
            Vote existingvote = (from p in dc.Votes
                                 where p.AnswerID==aid && p.UserID==uid
                                 select p
                                 ).FirstOrDefault();
            
            if (existingvote !=null)
            {
                existingvote.VoteValue = value;
                dc.SaveChanges();
            }
        }
    }
}
