using MauiGraphicsMcp.Models;
using System.Text;

namespace MauiGraphicsMcp.Tools
{
    class PathCommand : DrawingCommand
    {
        public PathData Path { get; }

        public PathCommand(PathData path)
        {
            Path = path;
        }

        public PathCommand(float x, float y, string data, Color background, Color stroke, float strokeSize)
        {
            Path = new PathData
            {
                X = x,
                Y = y,
                Data = data,
                Background = background,
                Stroke = stroke,
                StrokeSize = strokeSize,
            };
        }

        public override void Execute(ICanvas canvas, RectF dirtyRect)
        {
            if(string.IsNullOrEmpty(Path.Data))
            {
                return;
            }

            var pathBuilder = new PathBuilder();
            var pathF = pathBuilder.BuildPath(Path.Data);

            if (Path.Background is not null)
            {
                canvas.FillColor = Path.Background;
                canvas.FillPath(pathF);
            }

            if (Path.Stroke is not null)
            {
                canvas.StrokeColor = Path.Stroke;
                canvas.StrokeSize = Path.StrokeSize;
                canvas.DrawPath(pathF);
            }
		}

		public override string GetCode()
		{
			if (string.IsNullOrEmpty(Path.Data))
			{
                return string.Empty;
			}

			var pathBuilder = new PathBuilder();
			var pathF = pathBuilder.BuildPath(Path.Data);

			var codeBuilder = new StringBuilder();
            
            if (Path.Background is not null)
            {
                codeBuilder.AppendLine($"canvas.FillColor = {Path.Background};");
                codeBuilder.AppendLine($"canvas.FillPath({pathF});");
                codeBuilder.AppendLine();
            }

            if (Path.Stroke is not null)
            {
                codeBuilder.AppendLine($"canvas.StrokeColor = {Path.Stroke};");
                codeBuilder.AppendLine($"canvas.StrokeSize = {Path.StrokeSize};");
                codeBuilder.AppendLine($"canvas.DrawPath({pathF});");
				codeBuilder.AppendLine();
			}

			return codeBuilder.ToString();
		}
	}
}
