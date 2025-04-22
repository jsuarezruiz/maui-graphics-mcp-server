#nullable disable
namespace MauiGraphicsMcp.Models
{
    public abstract class DrawingElementData
    {
        public float X { get; set; }
        public float Y { get; set; }
    }
     
    public abstract class ShapeData : DrawingElementData
    {
        public Color Stroke { get; set; }
        public Color Background { get; set; }
        public float StrokeSize { get; set; } = 1;
    }
}
