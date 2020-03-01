using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekla.Structures.RPT
{
    public class Parser
    {
        private InternalString internalString = new InternalString();
        private EmptyChars emptyChars = new EmptyChars();
        private InteligentSplit inteligentSplit = new InteligentSplit();
        private PropertyParser propertyParser = new PropertyParser();

        public RPTObject Parse(string inputText)
        {
            var text = emptyChars.Remove(inputText);
            return ParseRPTObject("rptfile", text);
        }

        private RPTObject ParseRPTObject(string objectName, string text)
        {
            var currentObject = GetFromName(objectName);
            var unpacked = internalString.Unpack(text);
            var splittedBySemicolon = inteligentSplit.Split(unpacked.Text, ';');

            foreach (var textLine in splittedBySemicolon)
            {
                if (string.IsNullOrEmpty(textLine))
                    continue;

                if (textLine.Contains('{') & textLine.Contains('}'))
                {
                    var name = GetName(textLine);
                    var internalStringIndex = GetIndex(textLine);
                    var internalText = unpacked.InternalTexts[internalStringIndex];

                    currentObject.RPTObjects.Add(ParseRPTObject(name, internalText));
                }
                else
                {
                    var property = propertyParser.Parse(textLine);
                    currentObject.BindProperty(property);
                }
            }

            return currentObject;
        }


        private int GetIndex(string textLine)
        {
            var cbindex = textLine.IndexOf('{');
            var cbindex2 = textLine.IndexOf('}');
            var indexText = textLine.Substring(cbindex + 1, cbindex2 - cbindex - 1);

            return Convert.ToInt32(indexText);
        }

        private string GetName(string textLine)
        {
            var cbindex = textLine.IndexOf('{');
            return textLine.Substring(0, cbindex);
        }


        //TODO a co z tempolary number?

        private RPTObject GetFromName(string objectName0)
        {
            string objectName = objectName0.Replace("\r", "");
            bool isTmp = objectName.Contains("tmp");

            if (isTmp)
                objectName = RemoveTmpString(objectName);

            if (objectName.Equals("valuefield", StringComparison.InvariantCulture))
                return new Valuefield() { IsTmp = isTmp };
            else if (objectName.Equals("text", StringComparison.InvariantCulture))
                return new Text() { IsTmp = isTmp };
            else if (objectName.Equals("row", StringComparison.InvariantCulture))
                return new Row() { IsTmp = isTmp };
            else if (objectName.Equals("footer", StringComparison.InvariantCulture))
                return new Footer() { IsTmp = isTmp };
            else if (objectName.Equals("pageheader", StringComparison.InvariantCulture))
                return new Pageheader() { IsTmp = isTmp };
            else if (objectName.Equals("template", StringComparison.InvariantCulture))
                return new Template() { IsTmp = isTmp };
            else if (objectName.Equals("rptfile", StringComparison.InvariantCulture))
                return new RPTFile() { IsTmp = isTmp };
            else
                throw new RPTParserException("Could not get object from name: " + objectName);
        }

        private string RemoveTmpString(string objectName)
        {
            var index = objectName.IndexOf("_tmp_");
            return objectName.Substring(0, index);
        }
    }
}
