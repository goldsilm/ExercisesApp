using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesApp.MVVM.Services
{
    public interface IInitDataBaseService
    {
        void InitQuestionBank();
        void InitQuestions(string bankName);

    }
}
