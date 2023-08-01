using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UG22_MultipleChoiceTestApp
{
    public class Option : IOption
    {
        public char OptionLetter { get; set; }
        public string OptionText { get; set; }
    }
}
