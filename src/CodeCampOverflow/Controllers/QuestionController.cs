using System;
using System.Collections.Generic;
using System.Linq;
using CodeCampOverflow.Models;
using CodeCampOverflow.Models.Domain;
using CodeCampOverflow.Models.Question;
using CodeCampOverflow.Persistence;
using FubuMVC.Core;
using FubuMVC.Core.Continuations;

namespace CodeCampOverflow.Controllers
{
    public class QuestionController
    {
        private readonly IQuestionRepository _repo;

        public QuestionController(IQuestionRepository repo)
        {
            _repo = repo;
        }

        [UrlPattern("question/{Id}")]
        public QuestionViewModel IndexQuery(QuestionInputModel inputModel)
        {
            var question = GetQuestionById(inputModel.Id);
            return question.Map<QuestionViewModel>();
        }

        public AskQuestionViewModel AskQuery()
        {
            return new AskQuestionViewModel();
        }

        public FubuContinuation AskCommand(AskInputModel inputModel)
        {
            var question = inputModel.Map<Question>();
            question.Id = Guid.NewGuid().ToString("D");
            question.Answers = new List<Answer>();

            _repo.GetQuestions().Add(question);

            return FubuContinuation.RedirectTo(question.Map<QuestionInputModel>());
        }

        [UrlPattern("question/{QuestionId}/answer")]
        public FubuContinuation AnswerCommand(AnswerInputModel inputModel)
        {
            var question = GetQuestionById(inputModel.QuestionId);
            question.Answers.Add(new Answer
            {
                Id = Guid.NewGuid().ToString("D"),
                Body = inputModel.Body
            });

            return FubuContinuation.RedirectTo(new QuestionInputModel { Id = inputModel.QuestionId });
        }

        private Question GetQuestionById(string id)
        {
            return _repo.GetQuestions().Where(x => x.Id == id).Single();
        }
    }
}