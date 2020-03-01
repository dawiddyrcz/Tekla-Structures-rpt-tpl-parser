using System.Collections.Generic;
using System.Text;

namespace Tekla.Structures.RPT
{
    internal class InternalString
    {
        public class UnpackResult
        {
            public string Text { get; set; } = string.Empty;
            public List<string> InternalTexts { get; set; } = new List<string>();
        }

        private bool currentCharIsOpeningCurlyBracket;
        private bool currentCharIsClosingCurlyBracket ;
        private string text;
        private int curlyBracketLevel;
        private int quoteLevel;
        private int internalStringIndex;

        private void Reset()
        {
            currentCharIsOpeningCurlyBracket = false;
            currentCharIsClosingCurlyBracket = false;
            text = string.Empty;
            curlyBracketLevel = 0;
            quoteLevel = 0;
            internalStringIndex = 0;
        }

        public UnpackResult Unpack(string inputText)
        {
            Reset();
            var output = new UnpackResult();

            if (string.IsNullOrEmpty(inputText))
                return output;

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
                    externalText.Append("#index:" + internalStringIndex);
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

            Reset();
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
    }
}
