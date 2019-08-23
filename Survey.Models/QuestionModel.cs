using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Models
{
    public class QuestionModel
    {
        public Guid SurveyId { get; set; }
        public string CategoryId { get; set; }
        public string QuestionId { get; set; }
        public int Sequence { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string SummaryText { get; set; }
        public bool HasDate { get; set; }
        public string ClearAnswerId { get; set; }
        public IEnumerable<AnswerModel> Answers { get; set; }
    }
}
