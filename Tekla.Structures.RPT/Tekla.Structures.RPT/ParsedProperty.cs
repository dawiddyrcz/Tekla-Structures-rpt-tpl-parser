using System;

namespace Tekla.Structures.RPT
{
    internal class ParsedProperty
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public Type Type { get; set; }
    }
}
