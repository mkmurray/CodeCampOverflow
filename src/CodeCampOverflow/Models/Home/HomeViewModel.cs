using System.Collections.Generic;

namespace CodeCampOverflow.Models.Home
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Questions = new List<Domain.Question>();
        }

        public IList<Domain.Question> Questions { get; private set; }
    }
}