using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesApp.MVVM.Models
{
    public class SingleChoiceQuestion : IQuestion
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Question { get; set; }
        public string ChoiceA { get; set; }
        public string ChoiceB { get; set; }
        public string ChoiceC { get; set; }
        public string ChoiceD { get; set; }
        public string ChoiceE { get; set; }
        public string ChoiceF { get; set; }
        public string ChoiceG { get; set; }
        public string ChoiceH { get; set; }
        public string Answer { get; set; }
        public string Tip { get; set; }
        public bool IsStar { get; set; }

        public QuestionType GetQuestionType()
        {
            return QuestionType.SingleChoiceQuestion;
        }
    }
}
