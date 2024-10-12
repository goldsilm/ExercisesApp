using ExercisesApp.MVVM.Helpers;
using ExercisesApp.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesApp.MVVM.Services
{
    public class QuestionBankService : IQuestionBankService
    {
        private readonly SQLiteAsyncConnection _db;
        private readonly IInitDataBaseService _initDataBaseService;
        public QuestionBankService(IInitDataBaseService initDataBaseService)
        {
            _initDataBaseService = initDataBaseService;
            _initDataBaseService.InitQuestionBank();
            _db = new SQLiteAsyncConnection(PathHelper.BaseQuestionBankPath);
        }

        public async Task Create(string BankName, string Author)
        {
            var time=DateTime.Now;
            var fullpath = Path.Combine(PathHelper.BaseFilePath, $"{BankName}{time.Ticks}.sqlite3");
            var bank = new QuesitonBank()
            {
                Name = BankName,
                Author = Author,
                CreateTime = time,
                BankFileName = fullpath,
            };
            _initDataBaseService.InitQuestions(fullpath);
            await _db.InsertAsync(bank);
        }

        public async Task Delete(QuesitonBank quesitonBank)
        {
           if(File.Exists(quesitonBank.BankFileName))
            {
                File.Delete(quesitonBank.BankFileName);
            }
           await _db.DeleteAsync(quesitonBank);
        }

        public async Task DeleteById(int BankId)
        {
            var bank=await _db.Table<QuesitonBank>().Where(b => b.Id == BankId).FirstOrDefaultAsync();
            if(bank != null)
            {
                if (File.Exists(bank.BankFileName))
                {
                    File.Delete(bank.BankFileName);
                }
            }
            await _db.DeleteAsync<QuesitonBank>(BankId);
        }

        public async Task<IList<QuesitonBank>> SelectAll()
        {
            return await _db.Table<QuesitonBank>().ToListAsync();
        }

        public async Task<IList<QuesitonBank>> SelectByName(string Name)
        {
            return await _db.Table<QuesitonBank>().Where(b=>b.Name.Contains(Name)).ToListAsync();
        }

        public async Task UpDate(QuesitonBank quesitonBank)
        {
            await _db.UpdateAsync(quesitonBank);
        }
    }
}
