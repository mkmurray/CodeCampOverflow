using System.Collections.Generic;
using CodeCampOverflow.Models.Domain;

namespace CodeCampOverflow.Models.Home
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Questions = new List<Question>();
        }

        public IList<Question> Questions { get; private set; }
    }
}