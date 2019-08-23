using System;
using System.Collections.Generic;

namespace Survey.Models
{
    public class SurveyModel
    {
        public Guid SurveyId { get; set; }
        public string SurveyName { get; set; }

        public string SurveyDesignId { get; set; }
        public string ScantronId { get; set; }

        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}
