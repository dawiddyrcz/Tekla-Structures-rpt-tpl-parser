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
                output.Value = RemoveQuotes(valueString);
            else if (int.TryParse(valueString, out int intValue))
                output.Value = intValue;
            else if (double.TryParse(valueString, NumberStyles.Any, CultureInfo.InvariantCulture ,out double doubleValue))
                output.Value = doubleValue;
            else
                output.Value = valueString;

            //TODO rest values

            output.Name = text.Substring(0, equalIndex);
            return output;
        }

        private string RemoveQuotes(string valueString)
        {
            return valueString.Substring(1, valueString.Length - 2);
        }
    }
}
