using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExercisesApp.MVVM.Helpers
{
    public static class PathHelper
    {
        private static string _baseFilePath;
        static PathHelper()
        {
            _baseFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ExerciseApp");
            if (!Directory.Exists(_baseFilePath))
            {
                Directory.CreateDirectory(_baseFilePath);
            }
        }
        public static string BaseFilePath => _baseFilePath;
        public static string BaseQuestionBankPath => Path.Combine(BaseFilePath, "QuestionBank.sqlite3");
    }
}
