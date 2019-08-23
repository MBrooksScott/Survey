using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Models
{
    public class OutlineItem
    {
        public int Id { get; set; }
        public int OutlineItemId { get; set; }
        public int? ParentOutlineItemId { get; set; }
        public int? DefaultSequence { get; set; }
        public string PatientText { get; set; }
        public string MedicalText { get; set; }
        public string QuestionText { get; set; }
        public bool IncludeDate { get; set; }
        public bool RequireResponse { get; set; }
        public string CheckState { get; set; }
        public string AnswerType { get; set; }
        public string ChildResponseLogic { get; set; }
        public int DescendentCount { get; set; }
        public List<OutlineItem> Children { get; set; }
    }
}
