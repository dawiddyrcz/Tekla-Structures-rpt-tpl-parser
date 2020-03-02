using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class Circle : RPTObject
    {
        public string name {get;set;} = "circle_454";
        public double radius {get;set;} = 1.2;
        public double[] center {get;set;} = new double[] { 52.2, 11.8 };
        public bool filled {get;set;} = false;
        public int filltype {get;set;} = -1;
        public int pen {get;set;} = 0;
        public int color {get;set;} = 164;
        public int linetype {get;set;} = 1;
        public int linewidth {get;set;} = 1;
        
        public override List<RPTObject> RPTObjects { get; set; } = new List<RPTObject>();

        internal override void BindProperty(ParsedProperty property)
        {
            //TODO implementation
        }
    }
}
