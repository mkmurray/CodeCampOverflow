using System.Collections.Generic;
using CodeCampOverflow.Models.Domain;

namespace CodeCampOverflow.Models.Question
{
    public class QuestionViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public IList<Answer> Answers { get; set; }
    }
}