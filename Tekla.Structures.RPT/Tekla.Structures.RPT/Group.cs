using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class Group : RPTObject
    {
        public string name { get; set; }  = "Group_5";

        public override List<RPTObject> RPTObjects { get; set; } = new List<RPTObject>();

        internal override void BindProperty(ParsedProperty property)
        {
            //TODO implementation
        }
    }
}
