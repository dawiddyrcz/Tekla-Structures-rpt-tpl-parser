using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class Symbol : RPTObject
    {
        public string name { get; set; } = "symbol_5144";
        public string file { get; set; } = "xsteel.sym";
        public int symbolid { get; set; } = 2;
        public double[] refpoint { get; set; } = new double[] { 125.009, 41.541 };
        public double height { get; set; } = 7.0;
        public double width { get; set; } = 7.0;
        public int slant { get; set; } = 0;
        public double angle { get; set; } = 0;
        public int linepen { get; set; } = 0;
        public int linecolor { get; set; } = 153;
        public int linetype { get; set; } = 1;
        public double linewidth { get; set; } = 1.0;
        public int fillpen { get; set; } = 0;
        public int fillcolor { get; set; } = 153;
        public int filltype { get; set; } = 1;
        public bool fitinside { get; set; } = false;

    }
}
