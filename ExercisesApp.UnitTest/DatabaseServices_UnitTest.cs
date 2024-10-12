using ExercisesApp.MVVM.Models;
using ExercisesApp.MVVM.Services;

namespace ExercisesApp.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public async void QuestionBankServiceTest()
        {
            IInitDataBaseService initDataBaseService = new InitDataBaseService();
            IQuestionBankService questionBankService=new QuestionBankService(initDataBaseService);
            await questionBankService.Create("TestBank1", "Tom1");
            await questionBankService.Create("TestBank2", "Tom2");
            var banks = await questionBankService.SelectByName("TestBank");
            Assert.Equal(2, banks.Count);

            var banks1 = await questionBankService.SelectByName("TestBank1");
            Assert.Single(banks1);
            Assert.Equal("Tom1", banks1[0].Author);

            banks1[0].Author = "Tom2";
            await questionBankService.UpDate(banks1[0]);
            banks1 = await questionBankService.SelectByName("TestBank1");
            Assert.Single(banks1);
            Assert.Equal("Tom2", banks1[0].Author);

            await questionBankService.Delete(banks1[0]);
            banks = await questionBankService.SelectByName("TestBank");
            Assert.Single(banks);

            await questionBankService.DeleteById(banks[0].Id);
            banks = await questionBankService.SelectByName("TestBank");
            Assert.Empty(banks);

            banks = await questionBankService.SelectRecycleBin();
            Assert.Equal(2, banks.Count);

            await questionBankService.Recover(banks[0]);
            banks = await questionBankService.SelectRecycleBin();
            Assert.Single(banks);
            banks = await questionBankService.SelectByName("TestBank");
            Assert.Single(banks);
            await questionBankService.DeleteRecycleBin();
            banks = await questionBankService.SelectRecycleBin();
            Assert.Empty(banks);

        }

        [Fact]
        public async Task QuesitonServiceTest()
        {
            IInitDataBaseService initDataBaseService = new InitDataBaseService();
            IQuestionBankService questionBankService = new QuestionBankService(initDataBaseService);
            await questionBankService.Create("TestQuestion", "Cat");
            var banks = await questionBankService.SelectByName("TestQuestion");
            Assert.Single(banks);

            IQuestionService<SingleChoiceQuestion> questionService = new QuestionService<SingleChoiceQuestion>(banks[0].BankFileName);
            var singleChoice = new SingleChoiceQuestion()
            {
                Question = "ÄãÊÇÖíÂð£¿",
                ChoiceA = "1",
                ChoiceB = "2",
                ChoiceC = "3",
                ChoiceD = "4",
                ChoiceE = "5",
                ChoiceF = "6",
                ChoiceG = "7",
                ChoiceH = "8",
                Answer = "A",
                Tip = "A",
                IsStar = false
            };

            await questionService.Create(singleChoice);
            var questions = await questionService.SelectAll();
            Assert.Single(questions);
            singleChoice.Question = "ÄãÊÇ¹·Âð£¿";
            await questionService.Create(singleChoice);
            questions = await questionService.SelectAll();
            Assert.Equal(2, questions.Count);

            var question2 = await questionService.SelectByQuestion("¹·");
            Assert.Single(question2);

            var question3 = await questionService.SelectById(question2[0].Id);
            Assert.Equal("ÄãÊÇ¹·Âð£¿", question3.Question);

            await questionService.DeleteById(question3.Id);
            questions = await questionService.SelectAll();
            Assert.Single(questions);
            Assert.Equal("ÄãÊÇÖíÂð£¿", questions[0].Question);

            questions[0].Answer = "B";

            await questionService.Update(questions[0]);
            question3 = await questionService.SelectById(questions[0].Id);
            Assert.Equal("B", question3.Answer);

            Assert.False(question3.IsStar);
            await questionService.Star(question3);
            question3 = await questionService.SelectById(question3.Id);
            Assert.True(question3.IsStar);
            await questionService.UnStar(question3);
            question3 = await questionService.SelectById(question3.Id);
            Assert.False(question3.IsStar);
        }

        [Fact]
        public async Task QuesitonErrorServiceTest()
        {
            IInitDataBaseService initDataBaseService = new InitDataBaseService();
            IQuestionBankService questionBankService = new QuestionBankService(initDataBaseService);


            await questionBankService.Create("TestErrorQuestion", "Bat");
            var banks = await questionBankService.SelectByName("TestErrorQuestion");
            Assert.Single(banks);

            IQuestionService<SingleChoiceQuestion> questionService = new QuestionService<SingleChoiceQuestion>(banks[0].BankFileName);
            IQuestionErrorService questionErrorService = new QuestionErrorService(banks[0].BankFileName);
            var singleChoice = new SingleChoiceQuestion()
            {
                Question = "ÄãÊÇÖíÂð£¿",
                ChoiceA = "1",
                ChoiceB = "2",
                ChoiceC = "3",
                ChoiceD = "4",
                ChoiceE = "5",
                ChoiceF = "6",
                ChoiceG = "7",
                ChoiceH = "8",
                Answer = "A",
                Tip = "A",
                IsStar = false
            };
            await questionService.Create(singleChoice);

            var question = await questionService.SelectByQuestion("ÄãÊÇÖíÂð£¿");
            Assert.Single(question);
            await questionErrorService.Record(question[0]);
            var errors=await questionErrorService.SelectAll();
            Assert.Single(errors);
            Assert.Equal(1, errors[0].ErrorCount);

            await questionErrorService.Record(question[0]);
            errors = await questionErrorService.SelectAll();
            Assert.Single(errors);
            Assert.Equal(2, errors[0].ErrorCount);

            await questionErrorService.RemoveCount(question[0]);
            errors = await questionErrorService.SelectAll();
            Assert.Single(errors);
            Assert.Equal(1, errors[0].ErrorCount);

            await questionErrorService.RemoveAll();
            errors = await questionErrorService.SelectAll();
            Assert.Empty(errors);
        }

    }
}