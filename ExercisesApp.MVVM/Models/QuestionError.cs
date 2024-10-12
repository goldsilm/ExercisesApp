using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesApp.MVVM.Models
{
    public class QuestionError
    {
        public QuestionType QuestionType { get; set; }
        public int QestionId { get; set; }
        public int ErrorCount {  get; set; }
    }
}
