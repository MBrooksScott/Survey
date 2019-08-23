using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Models
{
    public class FormSaveRequest
    {
        public string PracticeId { get; set; }
        public int PatientId { get; set; }
        public int FormId { get; set; }
        public IEnumerable<AnswerSaveRequest> Answers { get; set; }
    }

    public class AnswerSaveRequest
    {
        public int AnswerId { get; set; }
        public DateTime? AnswerDate { get; set; }
    }

}
