using System.Linq;
using CodeCampOverflow.Models;
using CodeCampOverflow.Models.Question;
using CodeCampOverflow.Persistence;
using FubuMVC.Core;

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
            var question = _repo.GetQuestions().Where(x => x.Id == inputModel.Id).Single();
            return question.Map<QuestionViewModel>();
        }

        public AskQuestionViewModel AskQuery()
        {
            return new AskQuestionViewModel();
        }
    }
}