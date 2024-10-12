using ExercisesApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesApp.MVVM.Services
{ 
    public interface IQuestionErrorService
    {
        Task Record(IQuestion question);
        Task Remove(IQuestion question);
        Task RemoveCount(IQuestion question);
        Task RemoveAll();
        Task<IList<QuestionError>> SelectAll();
    }
}
