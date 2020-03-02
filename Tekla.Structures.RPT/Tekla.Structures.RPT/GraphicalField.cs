using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class GraphicalField : RPTObject
    {
        public string name { get; set; } = "field_REBAR_SHAPE";
        public int[] location { get; set; } = new int[] { 102, 1 };
        public string field { get; set; } = "CONTENTTYPE";
        public int height { get; set; } = 4;
        public int width { get; set; } = 32;

        public override List<RPTObject> RPTObjects { get; set; } = new List<RPTObject>();

        internal override void BindProperty(ParsedProperty property)
        {
            //TODO implementation
        }
    }
}
