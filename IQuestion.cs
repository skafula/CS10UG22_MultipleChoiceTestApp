using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UG22_MultipleChoiceTestApp
{
    public interface IQuestion
    {
        string QuestionText { get; set; }

        List<IOption> Options { get; set; }

        char CorrectAnswerLetter { get; set; }

        char OptionSelectedByStudent { get; set; }

        int MarksSecured { get; set; }
    }
}
