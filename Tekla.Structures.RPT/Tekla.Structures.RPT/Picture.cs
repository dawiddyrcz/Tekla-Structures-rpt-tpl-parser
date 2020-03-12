namespace Tekla.Structures.RPT
{
    public class Picture : RPTObject
    {
        public string name { get; set; } = "Picture";
        public string file { get; set; } = "construsoft.png";
        public Vector2 refpoint { get; set; } = new Vector2(9, 4);
        public double height { get; set; } = 21.0;
        public double width { get; set; } = 101.0;
        public bool keepaspect { get; set; } = false;
        public bool fitinside { get; set; } = false;
    }
}
