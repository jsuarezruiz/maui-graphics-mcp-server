using MauiGraphicsMcp.Models;
using System.Text;

namespace MauiGraphicsMcp.Tools
{
    class RectangleCommand : DrawingCommand
    {
        public RectangleData Rectangle { get; }

        public RectangleCommand(RectangleData rectangle)
        {
            Rectangle = rectangle;
        }

        public RectangleCommand(float x, float y, float height, float width, Color background, Color stroke, float strokeSize)
        {
            Rectangle = new RectangleData
            {
                X = x,
                Y = y,
                Height = height,
                Width = width,
                Background = background,
                Stroke = stroke,
                StrokeSize = strokeSize,
            };
        }

        public override void Execute(ICanvas canvas, RectF dirtyRect)
        {
            if (Rectangle.Background is not null)
            {
                canvas.FillColor = Rectangle.Background;
                canvas.FillRectangle(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            }

            if (Rectangle.Stroke is not null)
            {
                canvas.StrokeColor = Rectangle.Stroke;
                canvas.StrokeSize = Rectangle.StrokeSize;
                canvas.DrawRectangle(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            }
        }

        public override string GetCode()
        {
            var codeBuilder = new StringBuilder();

            if (Rectangle.Background is not null)
            {
                codeBuilder.AppendLine($"canvas.FillColor = {Rectangle.Background};");
                codeBuilder.AppendLine($"canvas.FillRectangle({Rectangle.X}, {Rectangle.Y}, {Rectangle.Width}, {Rectangle.Height});");
                codeBuilder.AppendLine();
            }

            if (Rectangle.Stroke is not null)
            {
                codeBuilder.AppendLine($"canvas.StrokeColor = {Rectangle.Stroke};");
                codeBuilder.AppendLine($"canvas.StrokeSize = {Rectangle.StrokeSize};");
                codeBuilder.AppendLine($"canvas.DrawRectangle({Rectangle.X}, {Rectangle.Y}, {Rectangle.Width}, {Rectangle.Height});");
                codeBuilder.AppendLine();
            }

            return codeBuilder.ToString();
        }
    }
}
