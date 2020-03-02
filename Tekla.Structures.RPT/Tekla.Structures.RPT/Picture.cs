using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class Picture : RPTObject
    {
        public string name { get; set; } = "Picture";
        public string file { get; set; } = "construsoft.png";
        public int[] refpoint { get; set; } = new int[] { 9, 4 };
        public int height { get; set; } = 21;
        public int width { get; set; } = 101;

        public override List<RPTObject> RPTObjects { get; set; } = new List<RPTObject>();

        internal override void BindProperty(ParsedProperty property)
        {
            //TODO implementation
        }
    }
}
