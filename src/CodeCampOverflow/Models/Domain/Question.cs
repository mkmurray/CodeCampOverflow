using System.Collections.Generic;

namespace CodeCampOverflow.Models.Domain
{
    public class Question
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public IList<Answer> Answers { get; set; }
    }
}