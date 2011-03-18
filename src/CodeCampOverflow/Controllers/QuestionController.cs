using CodeCampOverflow.Models.Question;
using FubuMVC.Core;

namespace CodeCampOverflow.Controllers
{
    public class QuestionController
    {
        [UrlPattern("question/{Id}")]
        public QuestionViewModel IndexQuery(QuestionInputModel inputModel)
        {
            return new QuestionViewModel { Id = inputModel.Id };
        }

        public AskQuestionViewModel AskQuery()
        {
            return new AskQuestionViewModel();
        }
    }
}