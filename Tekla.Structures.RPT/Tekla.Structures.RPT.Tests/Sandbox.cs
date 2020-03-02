using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekla.Structures.RPT.Tests
{
    public enum En1
    {
        VAL11,
        VAL12,
        VAL13
    }

    public enum En2
    {
        VAL21,
        VAL22,
        VAL23
    }

    public enum En3
    {
        VAL31,
        VAL32,
        VAL33
    }

    public class Sandbox
    {
        [Test]
        public void EnumTest()
        {
            var type = typeof(En1);

            foreach (var item in type.GetEnumValues())
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("***");

            var values = Enum.GetValues(type);

            foreach (var item in values)
            {
                Console.WriteLine(item.ToString());
            }
        }

        [Test]
        public void EnumTest2()
        {
            var enumTypes = new Type[]
            {
                typeof(En1),
                typeof(En2),
                typeof(En3),
            };

            var dict = new Dictionary<string, object>();

            foreach (var type in enumTypes)
            {
                foreach (var val in type.GetEnumValues())
                {
                    dict.Add(val.ToString(), val);
                }
            }

            Console.WriteLine("***");
            foreach (var key in dict.Keys)
            {
                Console.WriteLine("Key: {0}\tType: {1}\tValue: {2}", key, dict[key].GetType(), dict[key]);
            }

        }

        public abstract class ABSClass
        {
            internal void BindProperty(ParsedProperty parsedProperty)
            {
                var type = this.GetType();
                var properties = type.GetProperties().Where(p => p.Name.Equals(parsedProperty.Name)).ToList();

                if (properties.Count > 0)
                {
                    var property = properties[0];
                    property.SetValue(this, parsedProperty.Value);
                }
                else Console.WriteLine("There are no propety with name: " + parsedProperty.Name);
            }
        }

        public class InhClass : ABSClass
        {
            public string name { get; set; }
            public string text { get; set; }
            public int iValue { get; set; }
            public double dValue { get; set; }
            public double[] ArValue { get; set; }
        }

        [Test]
        public void BindingPropertyFromAbstractClass()
        {
            var parsedProperty_name = new ParsedProperty() { Name = "name", Value = "the name of invlass" };
            var parsedProperty_text = new ParsedProperty() { Name = "text", Value = "the text value" };
            var parsedProperty_iValue = new ParsedProperty() { Name = "iValue", Value = 777 };
            var parsedProperty_dValue = new ParsedProperty() { Name = "dValue", Value = 777.777 };
            var parsedProperty_ArValue = new ParsedProperty() { Name = "ArValue", Value = new double[] { 1.0, 2.0, 3.14 } };


            var inhObject = new InhClass();

            inhObject.BindProperty(parsedProperty_name);
            inhObject.BindProperty(parsedProperty_text);
            inhObject.BindProperty(parsedProperty_iValue);
            inhObject.BindProperty(parsedProperty_dValue);
            inhObject.BindProperty(parsedProperty_ArValue);

            Assert.AreEqual(parsedProperty_name.Value, inhObject.name);
            Assert.AreEqual(parsedProperty_text.Value, inhObject.text);
            Assert.AreEqual(parsedProperty_iValue.Value, inhObject.iValue);
            Assert.AreEqual(parsedProperty_dValue.Value, inhObject.dValue);
            Assert.AreEqual(parsedProperty_ArValue.Value, inhObject.ArValue);
        }
    }
}
