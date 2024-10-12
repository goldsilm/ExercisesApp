using ExercisesApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesApp.MVVM.Services
{
    public interface IQuestionStarService
    {
        Task Star(QuestionType type,int questionId);
        Task UnStar(QuestionType type,int questionId);
    }
}
