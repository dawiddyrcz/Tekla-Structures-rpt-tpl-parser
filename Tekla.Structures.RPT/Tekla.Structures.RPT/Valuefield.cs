using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class Valuefield : RPTObject
    {
        public string name { get; set; } = "Waarde veld";
        public int[] location { get; set; } = new int[] { 1, 6 };
        public string formula { get; set; } = "";
        public int maxnumoflines { get; set; } = 1;
        public DataType datatype { get; set; } = DataType.STRING;
        public string @class { get; set; } = "";
        public bool cacheable { get; set; } = true;
        public Justify justify { get; set; } = Justify.CENTERED;
        public bool visibility { get; set; } = true;
        public int angle { get; set; } = 0;
        public int length { get; set; } = 6;
        public int decimals { get; set; } = 0;
        public SortDirection sortdirection { get; set; } = SortDirection.ASCENDING;
        public string fontname { get; set; } = "Arial";
        public int fontcolor { get; set; } = 153;
        public int fonttype { get; set; } = 2;
        public double fontsize { get; set; } = 2.5;
        public int fontratio { get; set; } = 1;
        public int fontstyle { get; set; } = 0;
        public int fontslant { get; set; } = 0;
        public int pen { get; set; } = 6;
        public Oncombine oncombine { get; set; } = Oncombine.NONE;

        public override List<RPTObject> RPTObjects { get; set; } = new List<RPTObject>();

        internal override void BindProperty(ParsedProperty property)
        {
            //TODO implementation
        }
    }
}
