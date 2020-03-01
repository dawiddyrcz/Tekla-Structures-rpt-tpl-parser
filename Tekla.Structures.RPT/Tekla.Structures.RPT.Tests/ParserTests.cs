using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekla.Structures.RPT.Tests
{
    public class ParserTests
    {
        [Test]
        public void WhenInputTest_Return_NewObject()
        {
            var parser = new Parser();
            Assert.NotNull(parser.Parse("text"));
        }
    }
}
