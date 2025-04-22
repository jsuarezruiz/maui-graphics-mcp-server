using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace MauiGraphicsMcp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();

            return app;
        }
    }
}