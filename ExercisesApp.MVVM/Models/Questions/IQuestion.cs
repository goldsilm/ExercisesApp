using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesApp.MVVM.Models
{
    public interface IQuestion
    { 
        public int Id { get; set; }
        public string Question {  get; set; }
        public string Answer {  get; set; }
        public string Tip { get; set; }
    }
}
