using ExercisesApp.MVVM.Helpers;
using ExercisesApp.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesApp.MVVM.Services
{
    public class InitDataBaseService : IInitDataBaseService
    {
        
        public void InitQuestionBank()
        {
            var db = new SQLiteConnection(PathHelper.BaseQuestionBankPath);
            db.CreateTable<QuesitonBank>();
            db.Close();
        }

        public void InitQuestions(string bankName)
        {
            var db = new SQLiteConnection(bankName);
            db.CreateTable<SingleChoiceQuestion>();
            db.CreateTable<MultipleChoiceQuestion>();
            db.CreateTable<SingleOrMultipleChoiceQuestion>();
            db.CreateTable<TrueOrFalseQuestion>();
            db.CreateTable<FillBlankQuestion>();
            db.CreateTable<ShortAnswerQuestion>();
            db.CreateTable<CaseAnalysisQuestion>();
            db.CreateTable<QuesitonBank>();
            db.CreateTable<QuestionStar>();
            db.CreateTable<QuestionError>();
            db.Close();
        }
    }
}
