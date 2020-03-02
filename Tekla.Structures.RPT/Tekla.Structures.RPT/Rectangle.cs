using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class Rectangle : RPTObject
    {
        public string name { get; set; } = "Rechthoek";
        public double x1 { get; set; } = 0;
        public double y1 { get; set; } = 5;
        public double x2 { get; set; } = 160;
        public double y2 { get; set; } = 0;
        public bool filled { get; set; } = false;
        public int filltype { get; set; } = -1;
        public int pen { get; set; } = -1;
        public int color { get; set; } = 164;
        public int linetype { get; set; } = 1;
        public double linewidth { get; set; } = 1;
    }
}
