using ExerciseAppMVVM.Models.Questions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesApp.MVVM.Models
{
    public class TrueOrFalseQuestion : IQuestion
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Tip { get; set; }
    }
}
