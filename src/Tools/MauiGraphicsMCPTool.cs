using CommunityToolkit.Mvvm.Messaging;
using MauiGraphicsMcp.Models;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace MauiGraphicsMcp.Tools
{
    [McpServerToolType]
    public static class MauiGraphicsMcpTool
    {
        /// <summary>
        /// Clears the content of the .NET MAUI GraphicsView canvas by removing all previously drawn graphics.
        /// </summary>
        /// <remarks>
        /// This method resets the GraphicsView to a blank state, allowing new graphics to be rendered.
        /// It should be invoked when you need to refresh or remove all existing drawings.
        /// </remarks>
        [McpServerTool(Name = "maui_graphics_clear")]
        [Description("Clears the .NET MAUI GraphicsView Canvas, removing all previously drawn graphics.")]
        public static void Clear()
        {
            WeakReferenceMessenger.Default.Send(new ClearMessage(string.Empty));
        }

        /// <summary>
        /// Draws and fills a circle on the .NET MAUI GraphicsView canvas at the specified position, with the given radius and color.
        /// </summary>
        /// <param name="x">The x-coordinate of the center of the circle.</param>
        /// <param name="y">The y-coordinate of the center of the circle.</param>
        /// <param name="radius">The radius of the circle. Must be a positive value.</param>
        /// <param name="color">
        /// The fill color of the circle in RGBA hexadecimal format (e.g., "#FF0000" for red). 
        /// Defaults to black if no value is provided.
        /// </param>
        /// <remarks>
        /// Use this method to add a filled circular shape to the GraphicsView canvas. 
        /// Ensure valid inputs for all parameters to achieve the desired visual effect.
        /// </remarks>
        [McpServerTool(Name = "maui_graphics_fill_circle")]
        [Description("Fills a circle on the .NET MAUI GraphicsView canvas at the specified position, with the given color.")]
        public static void FillCircle(
            [Description("The x-coordinate of the center of the circle.")] float x,
            [Description("The y-coordinate of the center of the circle.")] float y,
            [Description("The radius of the circle. Must be a positive value.")] float radius,
            [Description("The fill color of the circle in hexadecimal format (e.g., \"#00FF00\" for green). Defaults to black if no value is provided.")] string color)
        {
            var circleData = new CircleData
            {
                X = x,
                Y = y,
                Radius = radius,
                Background = Color.FromRgba(color),
                Stroke = null
            };

            WeakReferenceMessenger.Default.Send(new CircleMessage(circleData));
        }

        /// <summary>
        /// Draws a circle on the .NET MAUI GraphicsView canvas at the specified position, with the given radius, color, and stroke size.
        /// </summary>
        /// <param name="x">The x-coordinate of the center of the circle.</param>
        /// <param name="y">The y-coordinate of the center of the circle.</param>
        /// <param name="radius">The radius of the circle. Must be a positive value.</param>
        /// <param name="color">
        /// The stroke color of the circle in RGBA hexadecimal format (e.g., "#FF0000" for red). 
        /// Defaults to black if no value is provided.
        /// </param>
        /// <param name="strokeSize">The thickness of the circle's stroke. Must be a positive value.</param>
        /// <remarks>
        /// Use this method to draw a circular outline on the GraphicsView canvas with customizable position, size, color, and stroke thickness.
        /// Ensure valid inputs for all parameters to achieve the desired visual effect.
        /// </remarks>
        [McpServerTool(Name = "maui_graphics_draw_circle")]
        [Description("Draws a circle outline on the .NET MAUI GraphicsView canvas with a specified position, size, color, and stroke thickness.")]
        public static void DrawCircle(
            [Description("The x-coordinate of the center of the circle.")] float x,
            [Description("The y-coordinate of the center of the circle.")] float y,
            [Description("The radius of the circle. Must be a positive value.")] float radius,
            [Description("The stroke color of the circle in hexadecimal format (e.g., \"#FF0000\" for red).")] string color,
            [Description("The thickness of the circle's outline. Must be a positive value.")] float strokeSize)
        {
            var circleData = new CircleData
            {
                X = x,
                Y = y,
                Radius = radius,
                Background = null,
                Stroke = Color.FromRgba(color),
                StrokeSize = strokeSize
            };

            WeakReferenceMessenger.Default.Send(new CircleMessage(circleData));
        }

        /// <summary>
        /// Fills a rectangle on the .NET MAUI GraphicsView canvas at the specified position, with the given height, width, and color.
        /// </summary>
        /// <param name="x">The x-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="y">The y-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="height">The height of the rectangle. Must be a positive value.</param>
        /// <param name="width">The width of the rectangle. Must be a positive value.</param>
        /// <param name="color">
        /// The fill color of the rectangle in RGBA hexadecimal format (e.g., "#FF0000" for red). 
        /// Defaults to black if no value is provided.
        /// </param>
        /// <remarks>
        /// Use this method to draw and fill rectangular shapes on the GraphicsView canvas.
        /// Ensure valid inputs for all parameters to achieve the desired results.
        /// </remarks>
        [McpServerTool(Name = "maui_graphics_fill_rectangle")]
        [Description("Fills a rectangle on the .NET MAUI GraphicsView canvas at the specified position, with the given dimensions and color.")]
        public static void FillRectangle(
            [Description("The x-coordinate of the top-left corner of the rectangle.")] float x,
            [Description("The y-coordinate of the top-left corner of the rectangle.")] float y,
            [Description("The height of the rectangle. Must be a positive value.")] float height,
            [Description("The width of the rectangle. Must be a positive value.")] float width,
            [Description("The fill color of the rectangle in RGBA hexadecimal format (e.g., \"#0000FF\" for blue). Defaults to black if no value is provided.")] string color)
        {
            var rectangleData = new RectangleData
            {
                X = x,
                Y = y,
                Height = height,
                Width = width,
                Background = Color.FromRgba(color),
                Stroke = null
            };

            WeakReferenceMessenger.Default.Send(new RectangleMessage(rectangleData));
        }

        /// <summary>
        /// Draws a rectangle outline on the .NET MAUI GraphicsView canvas at the specified position, 
        /// with the given height, width, color, and stroke size.
        /// </summary>
        /// <param name="x">The x-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="y">The y-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="height">The height of the rectangle. Must be a positive value.</param>
        /// <param name="width">The width of the rectangle. Must be a positive value.</param>
        /// <param name="color">
        /// The stroke color of the rectangle in RGBA hexadecimal format (e.g., "#FF0000" for red). 
        /// Defaults to black if no value is provided.
        /// </param>
        /// <param name="strokeSize">The thickness of the rectangle's border. Must be a positive value.</param>
        /// <remarks>
        /// Use this method to draw a rectangular border on the GraphicsView canvas with customizable 
        /// position, dimensions, stroke color, and thickness.
        /// Ensure all parameters are provided and valid for successful rendering.
        /// </remarks>
        [McpServerTool(Name = "maui_graphics_draw_rectangle")]
        [Description("Draws a rectangle outline on the .NET MAUI GraphicsView canvas at the specified position, with customizable dimensions, stroke color, and thickness.")]
        public static void DrawRectangle(
            [Description("The x-coordinate of the top-left corner of the rectangle.")] float x,
            [Description("The y-coordinate of the top-left corner of the rectangle.")] float y,
            [Description("The height of the rectangle. Must be a positive value.")] float height,
            [Description("The width of the rectangle. Must be a positive value.")] float width,
            [Description("The stroke color of the rectangle in RGBA hexadecimal format (e.g., \"#FFA500\" for orange). Defaults to black if no value is provided.")] string color,
            [Description("The thickness of the rectangle's border. Must be a positive value.")] float strokeSize)
        {
            var rectangleData = new RectangleData
            {
                X = x,
                Y = y,
                Height = height,
                Width = width,
                Background = null,
                Stroke = Color.FromRgba(color),
                StrokeSize = strokeSize
            };

            WeakReferenceMessenger.Default.Send(new RectangleMessage(rectangleData));
        }

        /// <summary>
        /// Draws a rounded rectangle on the canvas with the specified dimensions, color, and corner radius.
        /// </summary>
        /// <param name="x">The X-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="y">The Y-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="color">The fill color of the rectangle, in RGBA hexadecimal format (e.g., "#FF0000" for red).</param>
        /// <param name="cornerRadius">The radius of the corners for the rounded rectangle.</param>
        [McpServerTool(Name = "maui_graphics_fill_rounded_rectangle")]
        [Description("Fills a rounded rectangle on the canvas with the specified parameters.")]
        public static void FillRoundedRectangle(
            [Description("The X-coordinate of the top-left corner of the rectangle.")] float x,
            [Description("The Y-coordinate of the top-left corner of the rectangle.")] float y,
            [Description("The height of the rectangle.")] float height,
            [Description("The width of the rectangle.")] float width,
            [Description("The color to fill the rectangle with, in RGBA Hex format.")] string color,
            [Description("The radius of the corners for the rounded rectangle.")] float cornerRadius)
        {
            var roundedRectangleData = new RoundedRectangleData
            {
                X = x,
                Y = y,
                Height = height,
                Width = width,
                Background = Color.FromRgba(color),
                Stroke = null,
                CornerRadius = cornerRadius
            };

            WeakReferenceMessenger.Default.Send(new RoundedRectangleMessage(roundedRectangleData));
        }

        /// <summary>
        /// Draws the outline of a rounded rectangle on the canvas with the specified dimensions, border stroke size, and color.
        /// </summary>
        /// <param name="x">The X-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="y">The Y-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="color">The color of the rectangle's border, in RGBA hexadecimal format (e.g., "#FF0000" for red).</param>
        /// <param name="strokeSize">The width of the border stroke around the rectangle. Defaults to 1 if no value is provided.</param>
        /// <param name="cornerRadius">The radius of the corners for the rounded rectangle.</param>
        [McpServerTool(Name = "maui_graphics_draw_rounded_rectangle")]
        [Description("Draws the outline of a rounded rectangle on the canvas with the specified dimensions, stroke size, and color.")]
        public static void DrawRoundedRectangle(
            [Description("The X-coordinate of the top-left corner of the rectangle.")] float x,
            [Description("The Y-coordinate of the top-left corner of the rectangle.")] float y,
            [Description("The height of the rectangle.")] float height,
            [Description("The width of the rectangle.")] float width,
            [Description("The color of the rectangle's border, in RGBA hexadecimal format (e.g., \"#FF0000\" for red).")] string color,
            [Description("The width of the rectangle's border stroke. Defaults to 1 if no value is provided.")] float strokeSize,
            [Description("The radius of the corners for the rounded rectangle.")] float cornerRadius)
        {
            var roundedRectangleData = new RoundedRectangleData
            {
                X = x,
                Y = y,
                Height = height,
                Width = width,
                Background = null,
                Stroke = Color.FromRgba(color),
                StrokeSize = strokeSize,
                CornerRadius = cornerRadius
            };

            WeakReferenceMessenger.Default.Send(new RoundedRectangleMessage(roundedRectangleData));
        }

        /// <summary>
        /// Draws a straight line on the canvas between two specified points, with customizable color and stroke size.
        /// </summary>
        /// <param name="x1">The X-coordinate of the starting point of the line.</param>
        /// <param name="y1">The Y-coordinate of the starting point of the line.</param>
        /// <param name="x2">The X-coordinate of the ending point of the line.</param>
        /// <param name="y2">The Y-coordinate of the ending point of the line.</param>
        /// <param name="color">The color of the line, specified in RGBA hexadecimal format (e.g., "#FF0000" for red).</param>
        /// <param name="strokeSize">The width of the line's stroke. Defaults to 1 if no value is provided.</param>
        [McpServerTool(Name = "maui_graphics_draw_line")]
        [Description("Draws a straight line on the canvas between two points with the specified color and stroke size.")]
        public static void DrawLine(
            [Description("The X-coordinate of the starting point of the line.")] float x1,
            [Description("The Y-coordinate of the starting point of the line.")] float y1,
            [Description("The X-coordinate of the ending point of the line.")] float x2,
            [Description("The Y-coordinate of the ending point of the line.")] float y2,
            [Description("The color of the line, in RGBA hexadecimal format (e.g., \"#FF0000\" for red).")] string color,
            [Description("The width of the line. Defaults to 1 if no value is provided.")] float strokeSize)
        {
            var lineData = new LineData
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                Stroke = Color.FromRgba(color),
                StrokeSize = strokeSize,
            };

            WeakReferenceMessenger.Default.Send(new LineMessage(lineData));
        }

        /// <summary>
        /// Fills a custom path on the canvas based on the specified path data. The path is rendered with the given fill color.
        /// </summary>
        /// <param name="x">The X-coordinate of the starting point where the path will be filled.</param>
        /// <param name="y">The Y-coordinate of the starting point where the path will be filled.</param>
        /// <param name="data">A string representing the path data, using commands to define points, lines, and curves (e.g., 'M 50 50 L 150 50 Z').</param>
        /// <param name="color">The fill color of the path, specified in RGBA format.</param>
        [McpServerTool(Name = "maui_graphics_fill_path")]
        [Description("Fills a custom path on the canvas based on the provided path data, using the specified color.")]
        public static void FillPath(
            [Description("The X-coordinate of the starting point where the path will be filled.")] float x,
            [Description("The Y-coordinate of the starting point where the path will be filled.")] float y,
            [Description("A string representing the path data, using commands to define points, lines, and curves (e.g., 'M 50 50 L 150 50 Z').")] string data,
            [Description("The fill color of the path, specified in RGBA format.")] string color)
        {
            var pathData = new PathData
            {
                X = x,
                Y = y,
                Data = data,
                Background = Color.FromRgba(color),
                Stroke = null,
            };

            WeakReferenceMessenger.Default.Send(new PathMessage(pathData));
        }

        /// <summary>
        /// Draws a custom path on the canvas based on the specified path data. The path can be styled with a customizable stroke color and width, and it supports rounded corners.
        /// </summary>
        /// <param name="x">The X-coordinate of the starting point where the path will be drawn.</param>
        /// <param name="y">The Y-coordinate of the starting point where the path will be drawn.</param>
        /// <param name="data">A string representing the path data, using commands to define points, lines, and curves (e.g., 'M 50 50 L 150 50 Z').</param>
        /// <param name="color">The color of the path's stroke, specified in RGBA format.</param>
        /// <param name="strokeSize">The width of the stroke around the path.</param>
        [McpServerTool(Name = "maui_graphics_draw_path")]
        [Description("Draws a custom path on the canvas based on the provided path data, with customizable color, stroke size, and rounded corners.")]
        public static void DrawPath(
            [Description("The X-coordinate of the starting point where the path will be drawn.")] float x,
            [Description("The Y-coordinate of the starting point where the path will be drawn.")] float y,
            [Description("A string representing the path data, using commands to define points, lines, and curves (e.g., 'M 50 50 L 150 50 Z').")] string data,
            [Description("The color of the path's stroke, specified in RGBA format.")] string color,
            [Description("The width of the stroke around the path.")] float strokeSize)
        {
            var pathData = new PathData
            {
                X = x,
                Y = y,
                Data = data,
                Background = null,
                Stroke = Color.FromRgba(color),
                StrokeSize = strokeSize,
            };

            WeakReferenceMessenger.Default.Send(new PathMessage(pathData));
        }

        /// <summary>
        /// Draws a string of text on the .NET MAUI GraphicsView canvas at the specified position, 
        /// with the given font size and color.
        /// </summary>
        /// <param name="x">The x-coordinate of the starting point for the text.</param>
        /// <param name="y">The y-coordinate of the starting point for the text.</param>
        /// <param name="text">The string content to be drawn on the canvas.</param>
        /// <param name="fontSize">The size of the font used for rendering the text. Must be a positive value.</param>
        /// <param name="fontColor">
        /// The color of the text in RGBA hexadecimal format (e.g., "#000000" for black). 
        /// Defaults to black if no value is provided.
        /// </param>
        /// <remarks>
        /// Use this method to render text elements on the GraphicsView canvas. 
        /// Ensure valid inputs for all parameters to achieve the desired visual output.
        /// </remarks>
        [McpServerTool(Name = "maui_graphics_draw_string")]
        [Description("Draws a string of text on the .NET MAUI GraphicsView canvas at the specified position, with customizable font size and color.")]
        public static void DrawString(
            [Description("The x-coordinate of the starting position for the text.")] float x,
            [Description("The y-coordinate of the starting position for the text.")] float y,
            [Description("The text content to be drawn on the canvas.")] string text,
            [Description("The size of the font used to render the text. Must be a positive value.")] float fontSize,
            [Description("The color of the text in RGBA hexadecimal format (e.g., \"#000000\" for black). Defaults to black if no value is provided.")] string fontColor)
        { 
            var textData = new TextData
            {
                X = x,
                Y = y,
                Value = text,
                FontSize = fontSize,
                FontColor = Color.FromRgba(fontColor),
            };

            WeakReferenceMessenger.Default.Send(new TextMessage(textData));
        }
    }
}