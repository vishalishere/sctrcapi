namespace SCTRC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Question : Activity
    {
        public string QuestionText { get; set; }
        public string CorrectAnswers { get; set; }
        public string CorrectAnswerText { get; set; }
        public string WrongAnswerText { get; set; }
        public string AllCorrect { get; set; }
    }
}
