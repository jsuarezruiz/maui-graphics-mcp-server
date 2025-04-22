#nullable disable
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiGraphicsMcp.Models
{
    public class PathData : ShapeData
    {
        public string Data { get; set; }
    }

    public class PathMessage : ValueChangedMessage<PathData>
    {
        public PathMessage(PathData path) : base(path)
        {
        }
    }
}