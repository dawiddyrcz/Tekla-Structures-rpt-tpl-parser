using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class Text : RPTObject
    {
        public string name { get; set; } = "text_91";
        public double x1 { get; set; } = 96.18017578125;
        public double y1 { get; set; } = 1;
        public double x2 { get; set; } = 96.18017578125;
        public double y2 { get; set; } = 1;
        public string @string { get; set; } = "Wiel:";
        public string fontname { get; set; } = "Arial";
        public int fontcolor { get; set; } = 156;
        public int fonttype { get; set; } = 2;
        public int fontsize { get; set; } = 2;
        public int fontratio { get; set; } = 1;
        public int fontslant { get; set; } = 0;
        public int fontstyle { get; set; } = 0;
        public int angle { get; set; } = 0;
        public Justify justify { get; set; } = Justify.CENTERED;
        public int pen { get; set; } = 0;
        public int fontlinewidth { get; set; } = 1;

        public override List<RPTObject> RPTObjects { get; set; } = new List<RPTObject>();

        internal override void BindProperty(ParsedProperty property)
        {
            //TODO implementation
        }
    }
}
