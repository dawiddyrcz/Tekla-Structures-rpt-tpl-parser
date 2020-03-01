using System;
using System.Globalization;
using System.Linq;

namespace Tekla.Structures.RPT
{
    internal class PropertyParser
    {
        public ParsedProperty Parse(string text)
        {
            var output = new ParsedProperty();
            var equalIndex = text.IndexOf('=');
            var valueString = text.Substring(equalIndex + 1);

            if (valueString.Contains('\"'))
                output.Value = RemoveQuotesFromBeginAndEnd(valueString);
            else if (int.TryParse(valueString, out int intValue))
                output.Value = intValue;
            else if (double.TryParse(valueString, NumberStyles.Any, CultureInfo.InvariantCulture, out double doubleValue))
                output.Value = doubleValue;
            else if (valueString.Equals("TRUE", StringComparison.InvariantCulture))
                output.Value = true;
            else if (valueString.Equals("FALSE", StringComparison.InvariantCulture))
                output.Value = false;
            else
                output.Value = valueString;

            //TODO rest values

            output.Name = text.Substring(0, equalIndex);
            return output;
        }

        private string RemoveQuotesFromBeginAndEnd(string valueString)
        {
            return valueString.Substring(1, valueString.Length - 2);
        }
    }
}
