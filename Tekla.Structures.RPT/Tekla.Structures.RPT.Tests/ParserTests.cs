using NUnit.Framework;
using System.IO;

namespace Tekla.Structures.RPT.Tests
{
    public class ParserTests
    {
        private string GetTestDir()
        {
            return Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
        }

        [Test]
        public void Test01()
        {
            var fileName = Path.Combine(GetTestDir(), "LM.rpt");
            var text = File.ReadAllText(fileName);

            var parser = new Parser();

            var result = parser.Parse(text);

            //Create breakpoint here and check structure of result
            int a = 0;
        }
    }
}
