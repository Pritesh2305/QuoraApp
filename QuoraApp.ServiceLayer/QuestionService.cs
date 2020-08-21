using AutoMapper;
using QuoraApp.DomainModels;
using QuoraApp.Repository;
using QuoraApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoraApp.ServiceLayer
{
    public interface IQuestionService
    {
        void InsertQuestion(NewQuestionViewModel qvm);

        void UpdateQuestion(EditQuestionViewModel qvm);

        void UpdateQuestionsVoteCount(int qid, int value);

        void UpdateQuestionsAnswerCount(int qid, int value);

        void UpdateQuestionsViewsCount(int qid);

        List<QuestionViewModel> GetQuestions();

        List<QuestionViewModel> GetQuestionsByID(int qid);
    }

    public class QuestionService : IQuestionService
    {
        IQuestionsRepository qr;

        public QuestionService()
        {
            qr = new QuestionsRepository();
        }

        public void InsertQuestion(NewQuestionViewModel qvm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewQuestionViewModel, Question>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            Question q = mapper.Map<NewQuestionViewModel, Question>(qvm);
            qr.InsertQuestion(q);

        }

        public void UpdateQuestion(EditQuestionViewModel qvm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EditQuestionViewModel, Question>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();

            Question c = mapper.Map<EditQuestionViewModel, Question>(qvm);
            qr.UpdateQuestion(c);
        }

        public void UpdateQuestionsVoteCount(int qid, int value)
        {
            qr.UpdateQuestionsVoteCount(qid, value);
        }

        public void UpdateQuestionsAnswerCount(int qid, int value)
        {
            qr.UpdateQuestionsAnswerCount(qid, value);
        }

        public void UpdateQuestionsViewsCount(int qid)
        {
            qr.UpdateQuestionsViewsCount(qid);
        }

        public List<QuestionViewModel> GetQuestions()
        {
            List<Question> q = qr.GetQuestions();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Question, QuestionViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            List<QuestionViewModel> qvm = mapper.Map<List<Question>, List<QuestionViewModel>>(q);

            return qvm;
        }

        public List<QuestionViewModel> GetQuestionsByID(int qid)
        {
            List<Question> q = qr.GetQuestionsByID(qid);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Question, QuestionViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            List<QuestionViewModel> qvm = mapper.Map<List<Question>, List<QuestionViewModel>>(q);

            return qvm;

        }
    }
}
