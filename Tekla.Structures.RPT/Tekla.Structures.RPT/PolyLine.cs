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
        public double linewidth { get; set; } = 1.0;
        public int pen { get; set; } = -1;
    }
}
