using System.Collections.Generic;
using CodeCampOverflow.Models.Domain;

namespace CodeCampOverflow.Persistence
{
    public interface IQuestionRepository
    {
        IList<Question> GetQuestions();
    }
}