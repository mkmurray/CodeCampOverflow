using System.Collections.Generic;

namespace CodeCampOverflow.Models.Domain
{
    public class Everything
    {
        public Everything()
        {
            Questions = new List<Question>();
        }
        
        public string Id { get; set; }
        public IList<Question> Questions { get; set; }
    }
}