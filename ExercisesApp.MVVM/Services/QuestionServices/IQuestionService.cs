using ExercisesApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesApp.MVVM.Services
{
    public interface IQuestionService<T> where T : IQuestion
    {
        Task Create(T Question);
        Task Update(T Question);
        Task DeleteById(int Id);
        Task<T> SelectById(int Id);
        Task<IList<T>> SelectByQuestion(string t);
    }
}
