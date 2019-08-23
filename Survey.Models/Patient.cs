using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Models
{
    public class Patient
    {
        public Guid PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Nickname { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        
    }
}
