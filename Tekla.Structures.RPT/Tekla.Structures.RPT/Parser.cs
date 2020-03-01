using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekla.Structures.RPT
{
    public class Parser
    {
        private int curlyBracketLevel = 0;
        private int quoteLevel = 0;
        private string text = string.Empty;

        public object Parse(string text)
        {
            Reset();


            return true;
        }

        private void CalcuateLevels(int index)
        {
            var currentChar = text[index];
            var previousChar = text[index - 1];

            if (currentChar.Equals("\"") & !previousChar.Equals("\\") & quoteLevel.Equals(0))
                quoteLevel++;
            else if (currentChar.Equals("\"") & !previousChar.Equals("\\") & quoteLevel.Equals(1))
                quoteLevel--;

            if (currentChar.Equals("{") & quoteLevel.Equals(0))
                curlyBracketLevel++;
            
            if (currentChar.Equals("}") & quoteLevel.Equals(0))
                curlyBracketLevel--;
        }

        private void Reset()
        {
            text = string.Empty;
            curlyBracketLevel = 0;
            quoteLevel = 0;
        }
    }
}
