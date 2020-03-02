using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class LineOrArc : RPTObject
    {
        public string name {get;set;} = "lineorarc_88";
        public double x1 {get;set;} = 114.0;
        public double y1 {get;set;} = 0.0;
        public double x2 {get;set;} = 114.0;
        public double y2 {get;set;} = 9.0;
        public int pen {get;set;} = 0;
        public int color {get;set;} = 156;
        public int linetype {get;set;} = 1;
        public double linewidth {get;set;} = 1.0;
        public double bulge {get;set;} = 0.0;
    }
}
