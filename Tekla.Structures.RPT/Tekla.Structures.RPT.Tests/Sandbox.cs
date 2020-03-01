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
    }
}
