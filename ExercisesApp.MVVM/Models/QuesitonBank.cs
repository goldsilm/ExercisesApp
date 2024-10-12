using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesApp.MVVM.Models
{
    public class QuesitonBank
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author {  get; set; }
        public DateTime CreateTime { get; set; }
        public string BankFileName {  get; set; }
        public int SingleChoiceQuestionCount {  get; set; }
        public int MultipleChoiceQuestionCount { get; set; }
        public int SingleOrMultipleChoiceQuestionCount { get; set; }
        public int TrueOrFalseQuestionCount { get; set; }
        public int FillBlankQuestionCount { get; set; }
        public int ShortAnswerQuestionCount { get; set; }
        public int CaseAnalysisQuestionCount { get; set; }
        public int QuestionStarCount {  get; set; }
        public int QuestionErrorCount { get; set; }
    }
}
