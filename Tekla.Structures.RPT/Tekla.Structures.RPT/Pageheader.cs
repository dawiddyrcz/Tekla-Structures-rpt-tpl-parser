namespace Tekla.Structures.RPT
{
    public class PageHeader : RPTObject
    {
        public string name { get; set; } = "PageHeader_1";
        public double height { get; set; } = 24.0;
        public OutputPolicy outputpolicy { get; set; } = OutputPolicy.NONE;
    }
}
