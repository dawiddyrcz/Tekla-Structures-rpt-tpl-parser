using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekla.Structures.RPT.Tests
{
    public class InteligentSplitTests
    {
        private string GetTestDir()
        {
            return Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
        }

        [Test]
        public void InteligentSplitTest()
        {
            var fileName = Path.Combine(GetTestDir(), "inteligentSplitCase1.txt");
            var text = File.ReadAllText(fileName);
            text = new EmptyChars().Remove(text);

            var isplit = new InteligentSplit();
            var result = isplit.Split(text,';');

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine("Item {0} \t {1}", i, result[i]);
            }
        }
    }
}
