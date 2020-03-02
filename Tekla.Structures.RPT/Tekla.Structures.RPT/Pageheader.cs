using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class PageHeader : RPTObject
    {
        public string name { get; set; } = "PageHeader_1";
        public int height { get; set; } = 24;
        public OutputPolicy outputpolicy { get; set; } = OutputPolicy.NONE;

        public override List<RPTObject> RPTObjects { get; set; } = new List<RPTObject>();

        internal override void BindProperty(ParsedProperty property)
        {
            //TODO implementation
        }
    }
}
