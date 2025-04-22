using MauiGraphicsMcp.Models;
using System.Text;

namespace MauiGraphicsMcp.Tools
{
    class RoundedRectangleCommand : DrawingCommand
    {
        public RoundedRectangleData RoundedRectangle { get; }

        public RoundedRectangleCommand(RoundedRectangleData roundedRectangle)
        {
            RoundedRectangle = roundedRectangle;
        }

        public RoundedRectangleCommand(float x, float y, float height, float width, Color background, Color stroke, float strokeSize, float cornerRadius)
        {
            RoundedRectangle = new RoundedRectangleData
            {
                X = x,
                Y = y,
                Height = height,
                Width = width,
                Background = background,
                Stroke = stroke,
                StrokeSize = strokeSize,
                CornerRadius = cornerRadius
            };
        }

        public override void Execute(ICanvas canvas, RectF dirtyRect)
        {
            if (RoundedRectangle.Background is not null)
            {
                canvas.FillColor = RoundedRectangle.Background;
                canvas.FillRoundedRectangle(RoundedRectangle.X, RoundedRectangle.Y, RoundedRectangle.Width, RoundedRectangle.Height, RoundedRectangle.CornerRadius);
            }

            if (RoundedRectangle.Stroke is not null)
            {
                canvas.StrokeColor = RoundedRectangle.Stroke;
                canvas.StrokeSize = RoundedRectangle.StrokeSize;
                canvas.DrawRoundedRectangle(RoundedRectangle.X, RoundedRectangle.Y, RoundedRectangle.Width, RoundedRectangle.Height, RoundedRectangle.CornerRadius);
            }
        }

        public override string GetCode()
        {
            var codeBuilder = new StringBuilder();

            if (RoundedRectangle.Background is not null)
            {
                codeBuilder.AppendLine($"canvas.FillColor = {RoundedRectangle.Background};");
                codeBuilder.AppendLine($"canvas.FillRoundedRectangle({RoundedRectangle.X}, {RoundedRectangle.Y}, {RoundedRectangle.Width}, {RoundedRectangle.Height}, {RoundedRectangle.CornerRadius});");
                codeBuilder.AppendLine();
            }

            if (RoundedRectangle.Stroke is not null)
            {
                codeBuilder.AppendLine($"canvas.StrokeColor = {RoundedRectangle.Stroke};");
                codeBuilder.AppendLine($"canvas.StrokeSize = {RoundedRectangle.StrokeSize};");
                codeBuilder.AppendLine($"canvas.DrawRoundedRectangle({RoundedRectangle.X}, {RoundedRectangle.Y}, {RoundedRectangle.Width}, {RoundedRectangle.Height}, {RoundedRectangle.CornerRadius});");
                codeBuilder.AppendLine();
            }

            return codeBuilder.ToString();
        }
    }
}
