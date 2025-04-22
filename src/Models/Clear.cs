#nullable disable
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiGraphicsMcp.Models
{
    public class ClearMessage : ValueChangedMessage<string>
    {
        public ClearMessage(string message) : base(message)
        {
        }
    }
}