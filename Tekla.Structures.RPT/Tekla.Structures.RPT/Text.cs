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
        public double fontsize { get; set; } = 2.0;
        public double fontratio { get; set; } = 1.0;
        public int fontslant { get; set; } = 0;
        public int fontstyle { get; set; } = 0;
        public double angle { get; set; } = 0.0;
        public Justify justify { get; set; } = Justify.CENTERED;
        public int pen { get; set; } = 0;
        public int fontlinewidth { get; set; } = 1;
    }
}
