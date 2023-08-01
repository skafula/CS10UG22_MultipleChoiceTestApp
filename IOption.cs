using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UG22_MultipleChoiceTestApp
{
    public interface IOption
    {

        char OptionLetter { get; set; }

        string OptionText { get; set; }
    }
}
