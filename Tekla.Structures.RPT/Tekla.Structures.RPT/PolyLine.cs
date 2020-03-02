using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class PolyLine : RPTObject
    {
        public string name { get; set; } = "Polyline_i28";
        public bool filled { get; set; } = false;
        public int filltype { get; set; } = -1;
        public int color { get; set; } = 153;
        public int linetype { get; set; } = 1;
        public int linewidth { get; set; } = 1;
        public int pen { get; set; } = -1;

        public override List<RPTObject> RPTObjects { get; set; } = new List<RPTObject>();

        internal override void BindProperty(ParsedProperty property)
        {
            //TODO implementation
        }
    }
}
