using MauiLessons.Services;
using MauiLessons.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiLessons
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
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            //DependencyService.Resolve will get a new instance of PrimePageViewModel
            DependencyService.Register<PrimePageViewModel>();

            //DependencyService.Resolve<IPrimeNumberService> will get the singleton instance of PrimeNumberService
            DependencyService.RegisterSingleton<IPrimeNumberService>(new PrimeNumberService());

            return builder.Build();
        }
    }
}
