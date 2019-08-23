using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Models
{
    public class AnswerModel
    {
        public Guid SurveyId { get; set; }
        public string CategoryId { get; set; }
        public string QuestionId { get; set; }
        public string AnswerId { get; set; }
        public int Sequence { get; set; }
        public string AnswerType { get; set; }

        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string OutlineItemId { get; set; }
        public string CheckState { get; set; }
    }
}
