using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class Header : RPTObject
    {
        public string name { get; set; } = "header_81";
        public int height { get; set; } = 9;

        public override List<RPTObject> RPTObjects { get; set; } = new List<RPTObject>();

        internal override void BindProperty(ParsedProperty property)
        {
            //TODO implementation
        }
    }
}
