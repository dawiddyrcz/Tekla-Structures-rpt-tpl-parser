using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekla.Structures.RPT.Tests
{
    public class PropertyParserTestscs
    {
        [Test]
        public void WhenStringValue_ShouldReturn_StringProperty()
        {
            var text1 = "string=\"------------------\"";
            var text2 = "fontname=\"Courier New\"";
            var text3 = "rule=\"if (GetValue(\\\"PROFILE\\\") != NextValue(\\\"PROFILE\\\")||IsLast()) then\\n  Output()\\nelse\\n  StepOver()\\nendif\"";
            var text4 = "name=\"sum_LENGTH\"";
            
            var parser = new PropertyParser();

            var property1 = parser.Parse(text1);
            var property2 = parser.Parse(text2);
            var property3 = parser.Parse(text3);
            var property4 = parser.Parse(text4);

            Assert.AreEqual("string", property1.Name);
            Assert.AreEqual("fontname", property2.Name);
            Assert.AreEqual("rule", property3.Name);
            Assert.AreEqual("name", property4.Name);

            Assert.AreEqual("------------------", property1.Value);
            Assert.AreEqual("Courier New", property2.Value);
            Assert.AreEqual("if (GetValue(\\\"PROFILE\\\") != NextValue(\\\"PROFILE\\\")||IsLast()) then\\n  Output()\\nelse\\n  StepOver()\\nendif", property3.Value);
            Assert.AreEqual("sum_LENGTH", property4.Value);

            Assert.AreEqual(typeof(string), property1.Value.GetType());
            Assert.AreEqual(typeof(string), property2.Value.GetType());
            Assert.AreEqual(typeof(string), property3.Value.GetType());
            Assert.AreEqual(typeof(string), property4.Value.GetType());
        }

        [Test]
        public void WhenDoubleValue_ShouldReturn_DoubleProperty()
        {
            var text1 = "version=3.6";
            var text2 = "fontsize=0.8";
            var text3 = "fontratio=0.75";
            var text4 = "somethingzero=0.0";

            var parser = new PropertyParser();

            var property1 = parser.Parse(text1);
            var property2 = parser.Parse(text2);
            var property3 = parser.Parse(text3);
            var property4 = parser.Parse(text4);

            Assert.AreEqual("version", property1.Name);
            Assert.AreEqual("fontsize", property2.Name);
            Assert.AreEqual("fontratio", property3.Name);
            Assert.AreEqual("somethingzero", property4.Name);

            Assert.AreEqual(3.6, property1.Value);
            Assert.AreEqual(0.8, property2.Value);
            Assert.AreEqual(0.75, property3.Value);
            Assert.AreEqual(0.0, property4.Value);

            Assert.AreEqual(typeof(double), property1.Value.GetType());
            Assert.AreEqual(typeof(double), property2.Value.GetType());
            Assert.AreEqual(typeof(double), property3.Value.GetType());
            Assert.AreEqual(typeof(double), property4.Value.GetType());
        }

        [Test]
        public void WhenIntValue_ShouldReturn_IntProperty()
        {
            var text1 = "version=3";
            var text2 = "fontsize=153";
            var text3 = "fontratio=5";
            var text4 = "somethingzero=0";

            var parser = new PropertyParser();

            var property1 = parser.Parse(text1);
            var property2 = parser.Parse(text2);
            var property3 = parser.Parse(text3);
            var property4 = parser.Parse(text4);

            Assert.AreEqual("version", property1.Name);
            Assert.AreEqual("fontsize", property2.Name);
            Assert.AreEqual("fontratio", property3.Name);
            Assert.AreEqual("somethingzero", property4.Name);

            Assert.AreEqual(3, property1.Value);
            Assert.AreEqual(153, property2.Value);
            Assert.AreEqual(5, property3.Value);
            Assert.AreEqual(0, property4.Value);

            Assert.AreEqual(typeof(int), property1.Value.GetType());
            Assert.AreEqual(typeof(int), property2.Value.GetType());
            Assert.AreEqual(typeof(int), property3.Value.GetType());
            Assert.AreEqual(typeof(int), property4.Value.GetType());
        }
    }
}
