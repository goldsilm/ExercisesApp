using ExercisesApp.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesApp.MVVM.Services
{
    public class QuestionErrorService : IQuestionErrorService
    {
        private readonly SQLiteAsyncConnection _db;
        public QuestionErrorService(string DbPath)
        {
            _db = new SQLiteAsyncConnection(DbPath);
        }

        public async Task Record(IQuestion question)
        {
            //Why not use this,becouse it is a bug!!!
            //var error = await _db.Table<QuestionError>().Where(q => q.QuestionType == question.GetQuestionType() && q.QestionId == question.Id).FirstOrDefaultAsync();

            var type= question.GetQuestionType();
            var error = await _db.Table<QuestionError>().Where(q => q.QuestionType == type && q.QestionId == question.Id).FirstOrDefaultAsync();
            if (error != null)
            {
                error.ErrorCount++;
                await _db.UpdateAsync(error);
            }
            else
            {
                var newerror = new QuestionError()
                {
                    QuestionType = question.GetQuestionType(),
                    QestionId = question.Id,
                    ErrorCount = 1
                };
                await _db.InsertAsync(newerror);
            }
        }

        public async Task Remove(IQuestion question)
        {
            //Why not use this,becouse it is a bug!!!
            //var error = await _db.Table<QuestionError>().Where(q => q.QuestionType == question.GetQuestionType() && q.QestionId == question.Id).FirstOrDefaultAsync();

            var type = question.GetQuestionType();
            var error = await _db.Table<QuestionError>().Where(q => q.QuestionType == type && q.QestionId == question.Id).FirstOrDefaultAsync();
            if (error != null)
            {
                await _db.DeleteAsync(error);
            }
        }

        public async Task RemoveAll()
        {
            await _db.DeleteAllAsync<QuestionError>();
        }

        public async Task RemoveCount(IQuestion question)
        {
            //Why not use this,becouse it is a bug!!!
            //var error = await _db.Table<QuestionError>().Where(q => q.QuestionType == question.GetQuestionType() && q.QestionId == question.Id).FirstOrDefaultAsync();

            var type = question.GetQuestionType();
            var error = await _db.Table<QuestionError>().Where(q => q.QuestionType == type && q.QestionId == question.Id).FirstOrDefaultAsync();
            if (error != null)
            {
                error.ErrorCount--;
                await _db.UpdateAsync(error);
            }
        }

        public async Task<IList<QuestionError>> SelectAll()
        {
            return await _db.Table<QuestionError>().ToArrayAsync();
        }
    }
}
