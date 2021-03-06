﻿namespace Tekla.Structures.RPT
{
    public class Template : RPTObject
    {
        public string name { get; set; } = "template_1987";
        public TemplateType type { get; set; } = TemplateType.GRAPHICAL;
        public double width { get; set; } = 160.009;
        public double maxheight { get; set; } = 200.0;
        public Vector2 columns { get; set; } = new Vector2(1, 1);
        public int gap { get; set; } = 1;
        public FillPolicy fillpolicy { get; set; } = FillPolicy.EVEN;
        public FillDirection filldirection { get; set; } = FillDirection.HORIZONTAL;
        public FillStartFrom fillstartfrom { get; set; } = FillStartFrom.TOPLEFT;
        public Vector4 margins { get; set; } = new Vector4(0, 0, 0, 0);
        public double gridxspacing { get; set; } = 1.0;
        public double gridyspacing { get; set; } = 1.0;
        public double version { get; set; } = 3.21;
        public string created { get; set; } = "06.07.2005 09:27";
        public string modified { get; set; } = "29.09.2006 17:41";
        public string notes { get; set; } = "Converted template";
    }
}
