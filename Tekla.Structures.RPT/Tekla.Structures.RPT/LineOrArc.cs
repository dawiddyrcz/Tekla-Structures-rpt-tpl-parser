using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class LineOrArc : RPTObject
    {
        public string name {get;set;} = "lineorarc_88";
        public int x1 {get;set;} = 114;
        public int y1 {get;set;} = 0;
        public int x2 {get;set;} = 114;
        public int y2 {get;set;} = 9;
        public int pen {get;set;} = 0;
        public int color {get;set;} = 156;
        public int linetype {get;set;} = 1;
        public int linewidth {get;set;} = 1;
        public int bulge {get;set;} = 0;

        public override List<RPTObject> RPTObjects { get; set; } = new List<RPTObject>();

        internal override void BindProperty(ParsedProperty property)
        {
            //TODO implementation
        }
    }
}
