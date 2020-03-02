using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Tekla.Structures.RPT
{
    internal class PropertyParser
    {
        private Dictionary<string, object> enumValuesDictionary = new Dictionary<string, object>();
        private Dictionary<string, object> noneValuesDictionary = new Dictionary<string, object>();

        private InteligentSplit inteligentSplit = new InteligentSplit();
        private string currentText = string.Empty;
        private string currentName = string.Empty;

        public PropertyParser()
        {
            var enumTypes = new Type[]
            {
                typeof(FillPolicy),
                typeof(FillDirection),
                typeof(FillStartFrom),
                typeof(OutputPolicy),
                typeof(DataType),
                typeof(Justify),
                typeof(SortDirection),
                typeof(Oncombine),
                typeof(SortType),
                typeof(TemplateType),
            };
            
            foreach (var type in enumTypes)
            {
                foreach (var value in type.GetEnumValues())
                {
                    if (value.ToString().ToUpper().Equals("NONE" , StringComparison.InvariantCulture))
                    {
                        noneValuesDictionary.Add(type.Name.ToLower(), value);
                    }
                    else
                        enumValuesDictionary.Add(value.ToString().ToUpper(), value);
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
            currentName = text.Substring(0, equalIndex);
            var valueText = text.Substring(equalIndex + 1);

            if (IsArray(valueText))
                output.Value = ParseArray(valueText);
            else
                output.Value = ParseValue(valueText);

            output.Name = currentName;
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
            else if (TryParseEnum(valueString, out object value))
                output = value;
            else
                // throw new RPTParserException("Not supported value type: " + valueString);
                Console.WriteLine("Not supported value type: {0} for text: {1}", valueString, currentText);

            return output;
        }

        private bool TryParseEnum(string valueString, out object output)
        {
            output = null;
            if (valueString.ToUpper().Equals("NONE", StringComparison.InvariantCulture))
            {
                var key = currentName.ToLower();
                if (noneValuesDictionary.ContainsKey(key))
                {
                    output = noneValuesDictionary[key];
                    return true;
                }
                else return false;
            }
            else
            {
                var key = valueString.ToUpper();
                if (enumValuesDictionary.ContainsKey(key))
                {
                    output = enumValuesDictionary[key];
                    return true;
                }
                else return false;
            }
        }

        private string RemoveQuotesFromBeginAndEnd(string text)
        {
            var firstQuoteIndex = text.IndexOf('\"');
            var lastQuoteIndex = text.LastIndexOf('\"');

            return text.Substring(firstQuoteIndex + 1, lastQuoteIndex - firstQuoteIndex - 1);
        }
    }
}
