using MauiGraphicsMcp.Models;
using System.Text;

namespace MauiGraphicsMcp.Tools
{
    public class TextCommand : DrawingCommand
    {
        public TextData Text { get; }

        public TextCommand(TextData text)
        {
            Text = text;
        }

        public TextCommand(float x, float y, string text, Color fontColor, float fontSize)
        {
            Text = new TextData
            {
                X = x,
                Y = y,
                Value = text,
                FontColor = fontColor,
                FontSize = fontSize,
            };
        }

        public override void Execute(ICanvas canvas, RectF dirtyRect)
        {
            canvas.FontSize = Text.FontSize;
            canvas.FontColor = Text.FontColor;

            canvas.DrawString(Text.Value, Text.X, Text.Y, HorizontalAlignment.Left);
        }

        public override string GetCode()
        {
            var codeBuilder = new StringBuilder();

            codeBuilder.AppendLine($"canvas.FontSize = {Text.FontSize};");
            codeBuilder.AppendLine($"canvas.FontColor = {Text.FontColor};");
            codeBuilder.AppendLine();
            codeBuilder.AppendLine($"canvas.DrawString(\"{Text.Value}\", {Text.X}, {Text.Y}, HorizontalAlignment.Left);");
            codeBuilder.AppendLine();

            return codeBuilder.ToString();
        }
    }
}
