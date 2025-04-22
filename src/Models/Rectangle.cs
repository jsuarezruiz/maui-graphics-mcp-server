using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiGraphicsMcp.Models
{
    public class RectangleData : ShapeData
    {
        public float Height { get; set; }
        public float Width { get; set; }
    }

    public class RectangleMessage : ValueChangedMessage<RectangleData>
    {
        public RectangleMessage(RectangleData rectangle) : base(rectangle)
        {
        }
    }
}