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
           quesitonBank.IsDeleted = true;
           await _db.UpdateAsync(quesitonBank);
        }

        public async Task DeleteById(int BankId)
        {
            var bank=await _db.Table<QuesitonBank>().Where(b=>b.Id==BankId).FirstOrDefaultAsync();
            if(bank!=null)
            {
                bank.IsDeleted = true;
                await _db.UpdateAsync(bank);
            }
        }

        public async Task<IList<QuesitonBank>> SelectRecycleBin()
        {
            return await _db.Table<QuesitonBank>().Where(b => b.IsDeleted).ToListAsync();
        }

        public async Task DeleteRecycleBin()
        {
            await _db.Table<QuesitonBank>().Where(b => b.IsDeleted).DeleteAsync();
        }

        public async Task Recover(QuesitonBank quesitonBank)
        {
            quesitonBank.IsDeleted=false;
            await _db.UpdateAsync(quesitonBank);
        }

        public async Task<IList<QuesitonBank>> SelectAll()
        {
            return await _db.Table<QuesitonBank>().Where(b=>!b.IsDeleted).ToListAsync();
        }

        public async Task<IList<QuesitonBank>> SelectByName(string Name)
        {
            return await _db.Table<QuesitonBank>().Where(b=>b.Name.Contains(Name)&&!b.IsDeleted).ToListAsync();
        }

        public async Task UpDate(QuesitonBank quesitonBank)
        {
            await _db.UpdateAsync(quesitonBank);
        }
    }
}
