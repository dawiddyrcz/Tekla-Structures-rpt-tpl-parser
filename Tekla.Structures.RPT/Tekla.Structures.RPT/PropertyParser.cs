using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Tekla.Structures.RPT
{
    internal class PropertyParser
    {
        private Dictionary<string, object> enumValuesDictionary = new Dictionary<string, object>();
        private InteligentSplit inteligentSplit = new InteligentSplit();
        private string currentText = string.Empty;

        public PropertyParser()
        {
            var enumTypes = new Type[]
            {
                //typeof(En1),
                //typeof(En2),
                //typeof(En3),
            };
            
            foreach (var type in enumTypes)
            {
                foreach (var val in type.GetEnumValues())
                {
                    enumValuesDictionary.Add(val.ToString(), val);
                }
            }
        }

        public ParsedProperty Parse(string text)
        {
            if (String.IsNullOrEmpty(text))
                throw new RPTParserException("Input text is empty or null");

            currentText = text;
            var output = new ParsedProperty();
            var equalIndex = text.IndexOf('=');
            var valueText = text.Substring(equalIndex + 1);

            if (IsArray(valueText))
                output.Value = ParseArray(valueText);
            else
                output.Value = ParseValue(valueText);
          
            output.Name = text.Substring(0, equalIndex);
            return output;
        }

        private bool IsArray(string text)
        {
            return text.StartsWith("(") & text.EndsWith(")");
        }

        private object[] ParseArray(string text)
        {
            var output = new List<object>();
            var firstBracketIndex = text.IndexOf('(');
            var lastBracketIndex = text.LastIndexOf(')');
            var arrayText = text.Substring(firstBracketIndex + 1, lastBracketIndex - firstBracketIndex - 1);
            var splitted = inteligentSplit.Split(arrayText, ',');

            foreach (var valueText in splitted)
            {
                if (IsArray(valueText))
                    output.Add(ParseArray(valueText));
                else
                     output.Add(ParseValue(valueText));
            }

            return output.ToArray();
        }

        private object ParseValue(string valueString)
        {
            object output = null;

            if (valueString.Contains('\"'))
                output = RemoveQuotesFromBeginAndEnd(valueString);
            else if (int.TryParse(valueString, out int intValue))
                output = intValue;
            else if (double.TryParse(valueString, NumberStyles.Any, CultureInfo.InvariantCulture, out double doubleValue))
                output = doubleValue;
            else if (valueString.Equals("TRUE", StringComparison.InvariantCulture))
                output = true;
            else if (valueString.Equals("FALSE", StringComparison.InvariantCulture))
                output = false;
            else
                // throw new RPTParserException("Not supported value type: " + valueString);
                Console.WriteLine("Not supported value type: {0} for text: {1}",valueString, currentText);

            //TODO rest values

            return output;
        }

        private string RemoveQuotesFromBeginAndEnd(string text)
        {
            var firstQuoteIndex = text.IndexOf('\"');
            var lastQuoteIndex = text.LastIndexOf('\"');

            return text.Substring(firstQuoteIndex + 1, lastQuoteIndex - firstQuoteIndex - 1);
        }
    }
}
