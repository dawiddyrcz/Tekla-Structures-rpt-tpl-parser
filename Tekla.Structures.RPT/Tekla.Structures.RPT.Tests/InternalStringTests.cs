using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tekla.Structures.RPT.Tests
{
    public class InternalStringTests
    {
        private string GetTestDir()
        {
            return Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
        }

        [Test]
        public void ResultIsNotEmpty()
        {
            var internalStr = new InternalString();
            string text = "some text { internal text } ";

            var result = internalStr.Unpack(text);
            Assert.AreNotEqual(result.Text, string.Empty, "Result should not be empty");
            Assert.AreNotEqual(result.InternalTexts.Count, 0, "List should not be empty");
        }

        [Test]
        public void Case1()
        {
            var internalStr = new InternalString();
            var fileName = Path.Combine(GetTestDir(), "case1.txt");
            string text = File.ReadAllText(fileName);

            var result = internalStr.Unpack(text);

            Console.WriteLine(result.Text);

            int i = 1;
            foreach (var item in result.InternalTexts)
            {
                Console.WriteLine("********** " + i);
                Console.WriteLine(item);
                Console.WriteLine("********** " + i);
                i++;
            }
        }

        [Test]
        public void Case2()
        {
            var internalStr = new InternalString();
            var fileName = Path.Combine(GetTestDir(), "case2.txt");
            string text = File.ReadAllText(fileName);

            var result = internalStr.Unpack(text);

            Console.WriteLine(result.Text);

            int i = 1;
            foreach (var item in result.InternalTexts)
            {
                Console.WriteLine("********** " + i);
                Console.WriteLine(item);
                Console.WriteLine("********** " + i);
                i++;
            }
        }
    }
}
