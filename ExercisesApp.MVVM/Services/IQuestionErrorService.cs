using ExercisesApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesApp.MVVM.Services
{ 
    public interface IQuestionErrorService
    {
        Task Record(QuestionType type,int questionId);
        Task Remove(QuestionType type, int questionId);
        Task RemoveCount(QuestionType type, int questionId);
        Task RemoveAll();
    }
}
