using Microsoft.Extensions.Logging;
using VargasMExamenFinal.Services;
using VargasMExamenFinal.Views;
using VargasMExamenFinal.ViewsModels;

namespace VargasMExamenFinal
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

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "productos.db3");
            var database = new ProductosService(dbPath);

            builder.Services.AddSingleton(database);
            builder.Services.AddSingleton<ProductosViewModel>();

            builder.Services.AddSingleton<FormPage>();
            builder.Services.AddSingleton<ListPage>();
            builder.Services.AddSingleton<LogPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
