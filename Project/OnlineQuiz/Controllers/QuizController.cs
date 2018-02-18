using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineQuiz.Core;
using OnlineQuiz.Models;
using OnlineQuiz.Models.QuizViewModels;

namespace OnlineQuiz.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuizRepository _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public QuizController(IQuizRepository context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<FileContentResult> UserPhoto(String UserId)
        {
            User user = await _context.GetUser(UserId);
            if (user.UserPhoto != null)
                return new FileContentResult(user.UserPhoto, "image/png");
            else return null;
            /*
            {
                FileInfo file = new FileInfo("~/images/No_Image.jpg");
                long imageFileLength = file.Length;
                FileStream fs = new FileStream("~/images/No_Image.jpg", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] imageData = br.ReadBytes((int)imageFileLength);
                return new FileContentResult(imageData, "image/jpg");
            }*/

        }

        public async Task<IActionResult> Rankings()
        {
            RankingsModel model = new RankingsModel();
            model.Users = await _context.GetAllUsers();
            if (_userManager.GetUserId(User) != null) model.UserId = _userManager.GetUserId(User);
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> MainPage()
        {
            MainPageModel model = new MainPageModel();
            if (User.IsInRole("Admin"))
            {
                model.Quizes = await _context.GetAll();
                model.AreRemovable = model.Quizes.Exists(s => s.DateExpiring < DateTime.Now);
                return View(model);
            }
            model.Quizes = await _context.GetAvailable(_userManager.GetUserId(User));
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> RemoveOutdated()
        {
            await _context.Remove();
            return RedirectToAction("MainPage");
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult CreateQuiz()
        {
            QuizInfoModel model = new QuizInfoModel();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateQuiz(QuizInfoModel model)
        {
            if (ModelState.IsValid)
            {
                SampleQuiz creatingQuiz = new SampleQuiz(model.QuizName, model.DateExpiring, model.QuizGenre);
                await _context.AddSampleQuiz(creatingQuiz);
                return RedirectToAction("AddQuestions", new { quizId = creatingQuiz.Id });
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddQuestions(Guid quizId)
        {
            QuestionModel model = new QuestionModel()
            {
                QuizId = quizId
            };
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddQuestions(QuestionModel model)
        {
            if (ModelState.IsValid)
            {
                SampleQuestion question = new SampleQuestion(model.QuestionText, model.Correct, model.Wrong1, model.Wrong2, model.Wrong3);
                await _context.AddQuestionToSample(question, model.QuizId);
                model.Number++;
            }
            if(model.IsFinished)
                return RedirectToAction("MainPage");
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Reset(Guid quizId)
        {
            await _context.RemoveSampleQuiz(quizId);
            return RedirectToAction("MainPage");
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> SolveQuiz(Guid quizId)
        {
            SampleQuiz sample = await _context.GetSampleQuiz(quizId);
            SolvingQuiz quiz = SolvingQuiz.CreateFromSample(sample);
            await _context.AddQuizesToUser(quiz, sample, _userManager.GetUserId(User));
            return RedirectToAction("SolveQuestions", new { quizId = quiz.Id, sampleId = sample.Id});
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> SolveQuestions(Guid quizId, Guid sampleId)
        {
            SolvingQuiz quiz = await _context.GetSolvingQuiz(quizId);
            SampleQuiz sample = await _context.GetSampleQuiz(sampleId);
            SolvedQuestion solvedQuestion = quiz.Questions.First();
            SolvingQuestionModel question = new SolvingQuestionModel(sample.Questions.Find(s => s.QuestionText.Equals(solvedQuestion.QuestionText)),solvedQuestion);
            return View(question);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> SolveQuestions(SolvingQuestionModel model)
        {
            if (ModelState.IsValid)
            {
                SolvingQuiz quiz = await _context.GetSolvingQuiz(model.SolvingQuizId);
                SampleQuiz sample = await _context.GetSampleQuiz(model.SampleQuizId);
                _context.StoreUserAnswer(model.UserAnswer, quiz.Questions.ElementAt(model.QuestionNumber-1));
                await _context.CalculateStats(quiz);
                if (model.QuestionNumber == quiz.NumberOfQuestions)
                {                    
                    return RedirectToAction("Profile");
                }
                model.nextQuestion(sample.Questions, quiz.Questions.ElementAt(model.QuestionNumber));
            }
            return View(model);
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> Profile()
        {
            User thisUser = await _context.GetUser(_userManager.GetUserId(User));
            if (thisUser.IsUpdated) await _context.UpdateUserStats(thisUser);
            ProfileModel model = new ProfileModel(thisUser);
            
            return View(model);
        }

        [Authorize(Roles = "User")]
        [HttpGet("{userID}")]
        public IActionResult EditName(string userId)
        {
            EditNameModel model = new EditNameModel();
            model.UserID = userId;
            return View(model);
        }

        [Authorize(Roles = "User")]
        [HttpPost("{userID}")]
        public async Task<IActionResult> EditName(EditNameModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.GetUser(model.UserID);
                user.NickName = model.UserName;
                await _context.EditUser(user);
                return RedirectToAction("Profile");
            }
            return View(model);
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult EditPhoto(string userID)
        {
            EditPhotoModel model = new EditPhotoModel();
            model.UserID = userID;
            return View(model);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> EditPhoto(EditPhotoModel model)
        {
            if (model.UserPhoto != null)
            {
                User user = await _context.GetUser(model.UserID);
                using (var memoryStream = new MemoryStream())
                {
                    await model.UserPhoto.CopyToAsync(memoryStream);
                    user.UserPhoto = memoryStream.ToArray();
                }
                await _context.EditUser(user);
            }
            return RedirectToAction("Profile");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> QuizDetails(Guid quizId)
        {
            SampleQuiz quiz = await _context.GetSampleQuiz(quizId);
            return View(quiz);
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> SolvedQuizDetails(Guid quizId)
        {
            SolvingQuiz quiz = await _context.GetSolvingQuiz(quizId);
            return View(quiz);
        }
    }
}