using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class PageFooter : RPTObject
    {
        public string name {get;set;} = "PageFooter";
        public double height {get;set;} = 1.0;
        public OutputPolicy outputpolicy {get;set;} = OutputPolicy.NOTON;
        public int pagefrom {get;set;} = 0;
    }
}
