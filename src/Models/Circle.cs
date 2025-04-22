#nullable disable
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiGraphicsMcp.Models
{
    public class CircleData : ShapeData
    {   
        public float Radius { get; set; }
    }

    public class CircleMessage : ValueChangedMessage<CircleData>
    {
        public CircleMessage(CircleData circle) : base(circle)
        {
        }
    }
}