using MauiGraphicsMcp.Models;
using System.Text;

namespace MauiGraphicsMcp.Tools
{
    class CircleCommand : DrawingCommand
    {
        public CircleData Circle { get; }

        public CircleCommand(CircleData circle)
        {
            Circle = circle;
        }

        public CircleCommand(float x, float y, float radius, Color background, Color stroke, float strokeSize)
        {
            Circle = new CircleData
            {
                X = x,
                Y = y,
                Radius = radius,
                Background = background,
                Stroke = stroke,
                StrokeSize = strokeSize,
            };
        }

        public override void Execute(ICanvas canvas, RectF dirtyRect)
        {
            if (Circle.Background is not null)
            {
                canvas.FillColor = Circle.Background;
                canvas.FillCircle(Circle.X, Circle.Y, Circle.Radius);
            }

            if (Circle.Stroke is not null)
            {
                canvas.StrokeColor = Circle.Stroke;
                canvas.StrokeSize = Circle.StrokeSize;
                canvas.DrawCircle(Circle.X, Circle.Y, Circle.Radius);
            }
        }

        public override string GetCode()
        {
            var codeBuilder = new StringBuilder();

            if (Circle.Background is not null)
            {
                codeBuilder.AppendLine($"canvas.FillColor = {Circle.Background};");
                codeBuilder.AppendLine($"canvas.FillCircle({Circle.X}, {Circle.Y}, {Circle.Radius});");
                codeBuilder.AppendLine();
            }

            if (Circle.Stroke is not null)
            {
                codeBuilder.AppendLine($"canvas.StrokeColor = {Circle.Stroke};");
                codeBuilder.AppendLine($"canvas.StrokeSize = {Circle.StrokeSize};");
                codeBuilder.AppendLine($"canvas.DrawCircle({Circle.X}, {Circle.Y}, {Circle.Radius});");
                codeBuilder.AppendLine();
            }

            return codeBuilder.ToString();
        }
    }
}