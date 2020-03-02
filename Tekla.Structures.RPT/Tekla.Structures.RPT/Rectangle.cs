using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class Rectangle : RPTObject
    {
        public string name = "Rechthoek";
        public int x1 = 0;
        public int y1 = 5;
        public int x2 = 160;
        public int y2 = 0;
        public bool filled = false;
        public int filltype = -1;
        public int pen = -1;
        public int color = 164;
        public int linetype = 1;
        public int linewidth = 1;

        public override List<RPTObject> RPTObjects { get; set; } = new List<RPTObject>();

        internal override void BindProperty(ParsedProperty property)
        {
            //TODO implementation
        }
    }
}
