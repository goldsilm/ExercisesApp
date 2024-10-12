using ExercisesApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesApp.MVVM.Services
{
    public interface IQuestionBankService
    {
        Task Create(string BankName, string Author);
        Task Delete(QuesitonBank quesitonBank);
        Task DeleteById(int BankId);
        Task<IList<QuesitonBank>> SelectByName(string Name);
        Task<IList<QuesitonBank>> SelectAll();
        Task UpDate(QuesitonBank quesitonBank);
    }
}
