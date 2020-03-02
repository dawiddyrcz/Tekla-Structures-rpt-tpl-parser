using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class Row : RPTObject
    {
        public string name { get; set; } = "PART";
        public double height { get; set; } = 2.15152155197153;
        public bool visibility { get; set; } = false;
        public bool usecolumns { get; set; } = false;
        public string rule { get; set; } = "";
        public string contenttype { get; set; } = "PART";
        public SortType sorttype { get; set; } = SortType.DISTINCT;
    }
}
