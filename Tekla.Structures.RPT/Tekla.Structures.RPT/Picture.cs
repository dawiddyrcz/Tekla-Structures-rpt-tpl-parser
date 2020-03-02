using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class Picture : RPTObject
    {
        public string name { get; set; } = "Picture";
        public string file { get; set; } = "construsoft.png";
        public double[] refpoint { get; set; } = new double[] { 9, 4 };
        public double height { get; set; } = 21.0;
        public double width { get; set; } = 101.0;
        public bool keepaspect { get; set; } = false;
        public bool fitinside { get; set; } = false;
    }
}
