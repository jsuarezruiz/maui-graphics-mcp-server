using MauiGraphicsMcp.Models;
using System.Text;

namespace MauiGraphicsMcp.Tools
{
    class LineCommand : DrawingCommand
    {
        public LineData Line { get; }

        public LineCommand(LineData line)
        {
            Line = line;
        }

        public LineCommand(float x1, float y1, float x2, float y2, Color stroke, float strokeSize)
        {
            Line = new LineData
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                Stroke = stroke,
                StrokeSize = strokeSize,
            };
        }

        public override void Execute(ICanvas canvas, RectF dirtyRect)
        {
            if (Line.Stroke is not null)
            {
                canvas.StrokeColor = Line.Stroke;
                canvas.StrokeSize = Line.StrokeSize;

                canvas.DrawLine(Line.X1, Line.Y1, Line.X2, Line.Y2);
            }
        }

        public override string GetCode()
        {
            if (Line.Stroke is not null)
            {
                var codeBuilder = new StringBuilder();

                codeBuilder.AppendLine($"canvas.StrokeColor = {Line.Stroke};");
                codeBuilder.AppendLine($"canvas.StrokeSize = {Line.StrokeSize};");
                codeBuilder.AppendLine();
                codeBuilder.AppendLine($"canvas.DrawLine({Line.X1}, {Line.Y1}, {Line.X2}, {Line.Y2});");
                codeBuilder.AppendLine();

                return codeBuilder.ToString();
            }

            return string.Empty;
        }
    }
}
