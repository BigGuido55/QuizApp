using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Models.QuizViewModels
{
    public class EditPhotoModel
    {
        public String UserID { get; set; }
        public IFormFile UserPhoto { get; set; }

        public EditPhotoModel()
        {

        }
    }
}
