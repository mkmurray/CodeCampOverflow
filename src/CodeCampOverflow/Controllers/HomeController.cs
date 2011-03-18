using CodeCampOverflow.Models.Home;
using CodeCampOverflow.Persistence;

namespace CodeCampOverflow.Controllers
{
    public class HomeController
    {
        private readonly IQuestionRepository _repo;

        public HomeController(IQuestionRepository repo)
        {
            _repo = repo;
        }

        public HomeViewModel IndexQuery()
        {
            return new HomeViewModel { Questions = _repo.GetQuestions() };
        }
    }
}