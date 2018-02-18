using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineQuiz.Models.QuizViewModels
{
    public class EditNameModel
    {
        public string UserID { get; set; }

        [Required]
        [MaxLength(15)]
        public string UserName { get; set; }

        public EditNameModel()
        {
        }
    }
}
