using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class Symbol : RPTObject
    {
        public string name = "symbol_5144";
        public string file = "xsteel.sym";
        public int symbolid = 2;
        public double[] refpoint = new double[] { 125.009, 41.541 };
        public int height = 7;
        public int width = 7;
        public int slant = 0;
        public int angle = 0;
        public int linepen = 0;
        public int linecolor = 153;
        public int linetype = 1;
        public int linewidth = 1;
        public int fillpen = 0;
        public int fillcolor = 153;
        public int filltype = 1;

        public override List<RPTObject> RPTObjects { get; set; } = new List<RPTObject>();

        internal override void BindProperty(ParsedProperty property)
        {
            //TODO implementation
        }
    }
}
