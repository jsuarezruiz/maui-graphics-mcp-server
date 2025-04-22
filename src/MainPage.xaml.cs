#nullable disable
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.Messaging;
using MauiGraphicsMcp.Models;
using MauiGraphicsMcp.Tools;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DrawingCommand = MauiGraphicsMcp.Tools.DrawingCommand;

namespace MauiGraphicsMcp
{
    public partial class MainPage : ContentPage
    {
        readonly MauiGraphicsMcpDrawable _drawable;

        public MainPage()
        {
            InitializeComponent();

            GraphicsView.Drawable = _drawable = new MauiGraphicsMcpDrawable
            {
                Invalidate = GraphicsView.Invalidate
            };

            RunMcpServer().RunAndForget();
        }

        async Task RunMcpServer()
        {
            try
            {
                var builder = Host.CreateApplicationBuilder(settings: null);

                builder.Logging.AddConsole(consoleLogOptions =>
                {
                    // Configure all logs to go to stderr
                    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
                });

                builder.Services
                    .AddMcpServer()
                    .WithStdioServerTransport()
                    .WithToolsFromAssembly();

                var app = builder.Build();

                await app.RunAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Host terminated unexpectedly: {ex.Message}");
            }
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (_drawable is null)
            {
                return;
            }

            var code = _drawable.Code;

            if (string.IsNullOrEmpty(code))
            {
                await DisplayAlert("Information", "There is no code to export.", "Ok");
                return;
            }

            try
            {
                var result = await FolderPicker.Default.PickAsync();

                if (result is null || !result.IsSuccessful || string.IsNullOrEmpty(result.Folder?.Path))
                    return;
                
                var folderPath = result.Folder.Path;

                if (string.IsNullOrEmpty(folderPath))
                    return;

                string fileName = "generated_code.txt";
                string filePath = Path.Combine(folderPath, fileName);

                await File.WriteAllTextAsync(filePath, code);

                await DisplayAlert("Success", $"File saved successfully at:\n{filePath}", "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to write file:\n{ex.Message}", "Ok");
            }
        }
    }
}

public class MauiGraphicsMcpDrawable : IDrawable
{
    string _code;
    readonly List<DrawingCommand> _commands = [];

    public string Code => _code;

    public Action Invalidate { get; set; }

    public MauiGraphicsMcpDrawable()
    {
        WeakReferenceMessenger.Default.Register<ClearMessage>(this, (r, m) =>
        {
            DrawClear();
        });

        WeakReferenceMessenger.Default.Register<CircleMessage>(this, (r, m) =>
        {
            DrawCircle(m.Value.X,  m.Value.Y,  m.Value.Radius, m.Value.Background, m.Value.Stroke, m.Value.StrokeSize);
        }); 
        
        WeakReferenceMessenger.Default.Register<RectangleMessage>(this, (r, m) =>
        {
            DrawRectangle(m.Value.X, m.Value.Y, m.Value.Height, m.Value.Width, m.Value.Background, m.Value.Stroke, m.Value.StrokeSize);
        }); 
        
        WeakReferenceMessenger.Default.Register<RoundedRectangleMessage>(this, (r, m) =>
        {
            DrawRoundedRectangle(m.Value.X, m.Value.Y, m.Value.Height, m.Value.Width, m.Value.Background, m.Value.Stroke, m.Value.StrokeSize, m.Value.CornerRadius);
        });

        WeakReferenceMessenger.Default.Register<LineMessage>(this, (r, m) =>
        {
            DrawLine(m.Value.X1, m.Value.Y1, m.Value.X2, m.Value.Y2, m.Value.Stroke, m.Value.StrokeSize);
        }); 
        
        WeakReferenceMessenger.Default.Register<PathMessage>(this, (r, m) =>
        {
            DrawPath(m.Value.X, m.Value.Y, m.Value.Data, m.Value.Background, m.Value.Stroke, m.Value.StrokeSize);
        });

        WeakReferenceMessenger.Default.Register<TextMessage>(this, (r, m) =>
        {
            DrawString(m.Value.X, m.Value.Y, m.Value.Value, m.Value.FontColor, m.Value.FontSize);
        });
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        foreach (var command in _commands)
        {
            command.Execute(canvas, dirtyRect);
            _code += command.GetCode();
        }
    }

    public void DrawClear()
    {
        _commands.Add(new ClearCommand());
        Invalidate?.Invoke();

        _commands.Clear();
        _code = string.Empty;
    }

    public void DrawCircle(float x, float y, float radius, Color background, Color stroke, float strokeSize)
    {
        _commands.Add(new CircleCommand(x, y, radius, background, stroke, strokeSize));
        Invalidate?.Invoke();
    }

    public void DrawRectangle(float x, float y, float height, float width, Color background, Color stroke, float strokeSize)
    {
        _commands.Add(new RectangleCommand(x, y, height, width, background, stroke, strokeSize));
        Invalidate?.Invoke();
    }

    public void DrawRoundedRectangle(float x, float y, float height, float width, Color background, Color stroke, float strokeSize, float cornerRadius)
    {
        _commands.Add(new RoundedRectangleCommand(x, y, height, width, background, stroke, strokeSize, cornerRadius));
        Invalidate?.Invoke();
    }

    public void DrawLine(float x1, float y1, float x2, float y2, Color stroke, float strokeSize)
    {
        _commands.Add(new LineCommand(x1, y2, x2, y2, stroke, strokeSize));
        Invalidate?.Invoke();
    }

    public void DrawPath(float x, float y, string data, Color background, Color stroke, float strokeSize)
    {
        _commands.Add(new PathCommand(x, y, data, background, stroke, strokeSize));
        Invalidate?.Invoke();
    }

    public void DrawString(float x, float y, string text, Color color, float fontSize)
    {
        _commands.Add(new TextCommand(x, y, text, color, fontSize));
        Invalidate?.Invoke();
    }
}