using System.Collections.Generic;

namespace Tekla.Structures.RPT
{
    public class Template : RPTObject
    {
        public string name { get; set; } = "template_1987";
        public TemplateType type { get; set; } = TemplateType.GRAPHICAL;
        public double width { get; set; } = 160.009;
        public int maxheight { get; set; } = 200;
        public int[] columns { get; set; } = new int[] { 1, 1 };
        public int gap { get; set; } = 1;
        public FillPolicy fillpolicy { get; set; } = FillPolicy.EVEN;
        public FillDirection filldirection { get; set; } = FillDirection.HORIZONTAL;
        public int[] margins { get; set; } = new int[] { 0, 0, 0, 0 };
        public int gridxspacing { get; set; } = 1;
        public int gridyspacing { get; set; } = 1;
        public double version { get; set; } = 3.21;
        public string created { get; set; } = "06.07.2005 09:27";
        public string modified { get; set; } = "29.09.2006 17:41";
        public string notes { get; set; } = "Converted template";

        public override List<RPTObject> RPTObjects { get; set; } = new List<RPTObject>();

        internal override void BindProperty(ParsedProperty property)
        {
            //TODO implementation
        }
    }
}
