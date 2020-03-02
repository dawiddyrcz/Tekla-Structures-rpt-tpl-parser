using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class Footer : RPTObject
    {
        public string name { get; set; } = "FOOTER";
        public int height { get; set; } = 0;

        public override List<RPTObject> RPTObjects { get; set; } = new List<RPTObject>();

        internal override void BindProperty(ParsedProperty property)
        {
            //TODO implementation
        }
    }
}
