using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Models
{
    public class CategoryModel
    {
        public Guid SurveyId { get; set; }
        public string CategoryId { get; set; }
        public int Sequence { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public IEnumerable<QuestionModel> Questions { get; set; }
    }
}
