#nullable disable
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiGraphicsMcp.Models
{
    public class LineData
    {
        public float X1 { get; set; }
        public float Y1 { get; set; }
        public float X2 { get; set; }
        public float Y2 { get; set; }
        public Color Stroke { get; set; }
        public float StrokeSize { get; set; } = 1;
    }

    public class LineMessage : ValueChangedMessage<LineData>
    {
        public LineMessage(LineData line) : base(line)
        {
        }
    }
}