namespace MauiGraphicsMcp.Tools
{
    public abstract class DrawingCommand
    {
        public abstract void Execute(ICanvas canvas, RectF dirtyRect); 
        public abstract string GetCode();
    }
}
