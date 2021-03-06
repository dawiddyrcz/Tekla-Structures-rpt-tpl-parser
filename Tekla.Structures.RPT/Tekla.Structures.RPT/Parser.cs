﻿using System;
using System.Linq;

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

                if (textLine.Contains("{#index:") & textLine.Contains('}'))
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
            //How it works:
            //template{#index:81}  should return 81

            var cbindex = textLine.IndexOf("{")+8;
            var cbindex2 = textLine.IndexOf('}');
            var indexText = textLine.Substring(cbindex, cbindex2 - cbindex);

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
            else if (objectName.Equals("lineorarc", StringComparison.InvariantCulture))
                return new LineOrArc() { IsTmp = isTmp };
            else if (objectName.Equals("polyline", StringComparison.InvariantCulture))
                return new PolyLine() { IsTmp = isTmp };
            else if (objectName.Equals("circle", StringComparison.InvariantCulture))
                return new Circle() { IsTmp = isTmp };
            else if (objectName.Equals("rectangle", StringComparison.InvariantCulture))
                return new Rectangle() { IsTmp = isTmp };
            else if (objectName.Equals("graphicalfield", StringComparison.InvariantCulture))
                return new GraphicalField() { IsTmp = isTmp };
            else if (objectName.Equals("picture", StringComparison.InvariantCulture))
                return new Picture() { IsTmp = isTmp };
            else if (objectName.Equals("symbol", StringComparison.InvariantCulture))
                return new Symbol() { IsTmp = isTmp };
            else if (objectName.Equals("row", StringComparison.InvariantCulture))
                return new Row() { IsTmp = isTmp };
            else if (objectName.Equals("footer", StringComparison.InvariantCulture))
                return new Footer() { IsTmp = isTmp };
            else if (objectName.Equals("pageheader", StringComparison.InvariantCulture))
                return new PageHeader() { IsTmp = isTmp };
            else if (objectName.Equals("pagefooter", StringComparison.InvariantCulture))
                return new PageFooter() { IsTmp = isTmp };
            else if (objectName.Equals("header", StringComparison.InvariantCulture))
                return new Header() { IsTmp = isTmp };
            else if (objectName.Equals("group", StringComparison.InvariantCulture))
                return new Group() { IsTmp = isTmp };
            else if (objectName.Equals("template", StringComparison.InvariantCulture))
                return new Template() { IsTmp = isTmp };
            else if (objectName.Equals("userattribute", StringComparison.InvariantCulture))
                return new UserAttribute() { IsTmp = isTmp };
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
