using System.Text;

namespace MauiGraphicsMcp.Tools
{
    class ClearCommand : DrawingCommand
    {
        public override void Execute(ICanvas canvas, RectF dirtyRect)
        {
            canvas.FillColor = Colors.White;
            canvas.FillRectangle(dirtyRect.X, dirtyRect.Y, dirtyRect.Width, dirtyRect.Height);
        }

        public override string GetCode()
        {
            var codeBuilder = new StringBuilder();

            codeBuilder.AppendLine("canvas.FillColor = Colors.White;");
            codeBuilder.AppendLine();

            return codeBuilder.ToString();
        }
    }
}
