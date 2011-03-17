using System.Collections.Generic;

namespace CodeCampOverflow.Models.Domain
{
    public class Question
    {
        public Question()
        {
            Answers = new List<Answer>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public IList<Answer> Answers { get; set; }
    }
}