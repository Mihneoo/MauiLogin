using MauiApp1.MVVM.Services;
using MauiApp1.MVVM.ViewModels;
using MauiApp1.MVVM.Views;
using Microsoft.Extensions.Logging;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("papart3.ttf", "montserrat");
                    fonts.AddFont("Montserrat.ttf", "Montserrat");
                    fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                    fonts.AddFont("Montserrat-Semibold.ttf", "MontserratSemiBold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<LoginPage>(); 

            builder.Services.AddTransient<Authenthication>();
            builder.Services.AddSingleton<UserService>(); 

            return builder.Build();
        }
    }
}
