using System.Collections.Generic;

namespace CodeCampOverflow.Models.Home
{
    public class HomeViewModel
    {
        public IList<Domain.Question> Questions { get; set; }
    }
}