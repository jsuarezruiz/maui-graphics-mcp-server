#nullable disable
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiGraphicsMcp.Models
{
    public class TextData : DrawingElementData
    {
        public string Value { get; set; }
        public float FontSize { get; set; } = 10f;
        public Color FontColor { get; set; }
    }

    public class TextMessage : ValueChangedMessage<TextData>
    {
        public TextMessage(TextData text) : base(text)
        {
        }
    }
}
