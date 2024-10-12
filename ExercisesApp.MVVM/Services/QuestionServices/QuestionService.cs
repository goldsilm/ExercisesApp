using ExercisesApp.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesApp.MVVM.Services
{
    public class QuestionService<T> : IQuestionService<T> where T:IQuestion,new()
    {
        private readonly SQLiteAsyncConnection _db;

        public QuestionService(string DbPath) 
        {
            _db=new SQLiteAsyncConnection(DbPath);
        }

        public async Task Create(T Question)
        {
            await _db.InsertAsync(Question);
        }

        public async Task DeleteById(int Id)
        {
            await _db.DeleteAsync<T>(Id);
        }

        public async Task<T> SelectById(int Id)
        {
            return await _db.Table<T>().Where(q=>q.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<IList<T>> SelectByQuestion(string Question)
        {
            return await _db.Table<T>().Where(q=>q.Question.Contains(Question)).ToListAsync();
        }

        public async Task Update(T Question)
        {
            await _db.UpdateAsync(Question);
        }

    }
}
