using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesApp.MVVM.Models
{
    public class QuestionError
    {
        [PrimaryKey,AutoIncrement]
        public int Id {  get; set; }
        public QuestionType QuestionType { get; set; }
        public int QestionId { get; set; }
        public int ErrorCount {  get; set; }
    }
}
