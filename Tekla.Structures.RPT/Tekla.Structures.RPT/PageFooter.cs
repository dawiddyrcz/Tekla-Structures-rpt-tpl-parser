using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class PageFooter : RPTObject
    {
        public string name {get;set;} = "PageFooter";
        public int height {get;set;} = 1;
        public OutputPolicy outputpolicy {get;set;} = OutputPolicy.NOTON;
        public int pagefrom {get;set;} = 0;

        public override List<RPTObject> RPTObjects { get; set; } = new List<RPTObject>();

        internal override void BindProperty(ParsedProperty property)
        {
            //TODO implementation
        }
    }
}
