using System.Collections.Generic;
using System.Text;

namespace Tekla.Structures.RPT
{
    internal class InteligentSplit
    {
        private string text;
        private int quoteLevel;

        private void Reset()
        {
            text = string.Empty;
            quoteLevel = 0;
        }

        public List<string> Split(string inputText, char schar)
        {
            Reset();
            var output = new List<string>();
            var currentOutputString = new StringBuilder(100);
            currentOutputString.Append(inputText[0]);
            this.text = inputText;

            for (int i = 1; i < inputText.Length; i++)
            {
                CalcuateLevels(i);

                if (quoteLevel.Equals(0))
                {
                    if (inputText[i].Equals(schar))
                    {
                        output.Add(currentOutputString.ToString());
                        currentOutputString.Clear();
                    }
                    else
                    {
                        currentOutputString.Append(inputText[i]);
                    }
                }
                else currentOutputString.Append(inputText[i]);
            }

            Reset();
            output.Add(currentOutputString.ToString());
            currentOutputString.Clear();
            return output;
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
