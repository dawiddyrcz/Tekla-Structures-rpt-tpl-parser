using NUnit.Framework;
using System;
using System.IO;

namespace Tekla.Structures.RPT.Tests
{
    public class EmptyCharsTests
    {
        private string GetTestDir()
        {
            return Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
        }

        //We have to remove blank and empty chars from text but not from string values

        [Test]
        public void InteligentEmptyCharsRemove()
        {
            var fileName = Path.Combine(GetTestDir(), "emptyCharsCase1.txt");
            var text = File.ReadAllText(fileName);
            var ech = new EmptyChars();

            var result = ech.Remove(text);

            Console.WriteLine(result);

            Assert.IsTrue(result.Contains("template_1	ff	asdfas erwtcxb      cxb cxvb cv   cxb sdsdg sd"));
            Assert.IsTrue(result.Contains(";pageheader{name=\"PAGEHEADER one \";height=6;outputpolicy=NONE;valuef"));
        }
    }
}
