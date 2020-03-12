namespace Tekla.Structures.RPT
{
    public class GraphicalField : RPTObject
    {
        public string name { get; set; } = "field_REBAR_SHAPE";
        public Vector2 location { get; set; } = new Vector2(102, 1);
        public string field { get; set; } = "CONTENTTYPE";
        public double height { get; set; } = 4.0;
        public double width { get; set; } = 32.0;
    }
}
