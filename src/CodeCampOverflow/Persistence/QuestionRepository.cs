using System;
using Raven.Client;
using System.Collections.Generic;
using CodeCampOverflow.Models.Domain;

namespace CodeCampOverflow.Persistence
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IDocumentSession _session;

        public QuestionRepository(IDocumentSession session)
        {
            _session = session;
        }

        public IList<Question> GetQuestions()
        {
            var list = _session.Load<Everything>("codecampoverflow/42");

            // Prepopulate some questions and answers if database is empty
            if (list == null)
            {
                list = new Everything { Id = "codecampoverflow/42" };
                list.Questions.Add(new Question
                {
                    Id = Guid.NewGuid().ToString("D"),
                    Title = "What is 1337% of Pi?",
                    Body = "I hear the answer will make you *nerd asplode*!",
                    Answers = new List<Answer>()
                });
                list.Questions.Add(new Question
                {
                    Id = Guid.NewGuid().ToString("D"),
                    Title = "How many licks does it take to get to the Tootsie Roll center of a Tootsie Pop?",
                    Body = "Mr. Owl: \"Let's find out...\"",
                    Answers = new List<Answer> { new Answer { Id = Guid.NewGuid().ToString("D"), Body = "3" } }
                });
                list.Questions.Add(new Question
                {
                    Id = Guid.NewGuid().ToString("D"),
                    Title = "Why are manhole covers round?",
                    Body = "If you know this, you may be qualified to interview at Microsoft.",
                    Answers = new List<Answer>()
                });
                _session.Store(list);
            }

            return list.Questions;
        }
    }
}