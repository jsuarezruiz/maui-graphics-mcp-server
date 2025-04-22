using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiGraphicsMcp.Models
{
    public class RoundedRectangleData : RectangleData
    {
        public float CornerRadius { get; set; }
    }

    public class RoundedRectangleMessage : ValueChangedMessage<RoundedRectangleData>
    {
        public RoundedRectangleMessage(RoundedRectangleData roundedRectangle) : base(roundedRectangle)
        {
        }
    }
}