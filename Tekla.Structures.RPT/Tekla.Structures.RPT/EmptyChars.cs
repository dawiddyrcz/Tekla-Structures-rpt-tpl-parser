using System.Collections.Generic;
using System.Text;

namespace Tekla.Structures.RPT
{
    internal class EmptyChars
    {
        private string text;
        private int quoteLevel;

        private void Reset()
        {
            text = string.Empty;
            quoteLevel = 0;
        }

        public string Remove(string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
                return inputText;

            Reset();
            var outputText = new StringBuilder(inputText.Length);
            outputText.Append(inputText[0]);
            this.text = inputText;

            for (int i = 1; i < inputText.Length; i++)
            {
                CalcuateLevels(i);

                if (quoteLevel.Equals(0))
                {
                    if (!char.IsWhiteSpace(inputText[i]) & !inputText[i].Equals('\r'))
                        outputText.Append(inputText[i]);
                }
                else
                    outputText.Append(inputText[i]);
            }
            
            return outputText.ToString();
        }

        private void CalcuateLevels(int index)
        {
            var currentChar = text[index];
            var previousChar = text[index - 1];

            if (currentChar.Equals('\"') & !previousChar.Equals('\\') & quoteLevel.Equals(0))
                quoteLevel++;
            else if (currentChar.Equals('\"') & !previousChar.Equals('\\') & quoteLevel.Equals(1))
                quoteLevel--;
        }
    }
}
