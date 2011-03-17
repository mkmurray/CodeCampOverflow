using System.Collections.Generic;
using CodeCampOverflow.Models.Domain;
using CodeCampOverflow.Models.Home;

namespace CodeCampOverflow.Controllers
{
    public class HomeController
    {
        public HomeViewModel Index()
        {
            var returnModel = new HomeViewModel();

            returnModel.Questions.Add(new Question
            {
                Id = 1,
                Title = "What is 1337% of Pi?"
            });
            returnModel.Questions.Add(new Question
            {
                Id = 2,
                Title = "How many licks does it take to get to the Tootsie Roll center of a Tootsie Pop?",
                Answers = new List<Answer> { new Answer { Id = 4, Body = "3" } }
            });
            returnModel.Questions.Add(new Question
            {
                Id = 3,
                Title = "Why are manhole covers round?"
            });


            return returnModel;
        }
    }
}