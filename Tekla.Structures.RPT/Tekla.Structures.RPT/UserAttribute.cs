using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class UserAttribute : RPTObject
    {
        public string name { get; set; } = "FontName";
        public string value { get; set; } = "Arial";

        public override List<RPTObject> RPTObjects { get; set; } = new List<RPTObject>();

        internal override void BindProperty(ParsedProperty property)
        {
            //TODO implementation
        }
    }
}
