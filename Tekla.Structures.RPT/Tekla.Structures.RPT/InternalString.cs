using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekla.Structures.RPT
{
    internal class InternalString
    {
        public class UnpackResult
        {
            public string Text { get; set; } = string.Empty;
            public List<string> InternalTexts { get; set; } = new List<string>();
        }

        private int curlyBracketLevel = 0;
        private bool currentCharIsOpeningCurlyBracket = false;
        private bool currentCharIsClosingCurlyBracket = false;
        private int quoteLevel = 0;
        private string text = string.Empty;
        private int internalStringIndex = 0;

        public UnpackResult Unpack(string inputText)
        {
            Reset();
            var output = new UnpackResult();

            var externalText = new StringBuilder(inputText.Length);
            externalText.Append(inputText[0]);

            var internalText = new StringBuilder(inputText.Length);
            this.text = inputText;

            for (int i = 1; i < inputText.Length; i++)
            {
                CalcuateLevels(i);

                if (curlyBracketLevel.Equals(1) & currentCharIsOpeningCurlyBracket)
                {
                    externalText.Append(inputText[i]);
                    externalText.Append(internalStringIndex);
                    continue;
                }
                else if(curlyBracketLevel.Equals(0) & currentCharIsClosingCurlyBracket)
                {
                    output.InternalTexts.Add(internalText.ToString());
                    internalStringIndex++;
                    internalText.Clear();
                }

                if (curlyBracketLevel.Equals(0))
                    externalText.Append(inputText[i]);
                else
                    internalText.Append(inputText[i]);
            }
            
            output.Text = externalText.ToString();
            return output;
        }

        private void CalcuateLevels(int index)
        {
            currentCharIsOpeningCurlyBracket = false;
            currentCharIsClosingCurlyBracket = false;

            var currentChar = text[index];
            var previousChar = text[index - 1];

            if (currentChar.Equals('\"') & !previousChar.Equals('\\') & quoteLevel.Equals(0))
                quoteLevel++;
            else if (currentChar.Equals('\"') & !previousChar.Equals('\\') & quoteLevel.Equals(1))
                quoteLevel--;

            if (currentChar.Equals('{') & quoteLevel.Equals(0))
            {
                curlyBracketLevel++;
                currentCharIsOpeningCurlyBracket = true;
            }

            if (currentChar.Equals('}') & quoteLevel.Equals(0))
            {
                curlyBracketLevel--;
                currentCharIsClosingCurlyBracket = true;
            }
        }

        private void Reset()
        {
            currentCharIsOpeningCurlyBracket = false;
            currentCharIsClosingCurlyBracket = false;
            text = string.Empty;
            curlyBracketLevel = 0;
            internalStringIndex = 0;
            quoteLevel = 0;
        }
    }
}
