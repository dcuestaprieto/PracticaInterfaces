using PracticaInterfacesPrimerTrimestre.Repositorios;
namespace PracticaInterfacesPrimerTrimestre;
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

        string ruta = GetRoute.ReturnRoute("usuarios.db");
        builder.Services.AddSingleton<UsuarioRepositorio>(
            s => ActivatorUtilities.CreateInstance<UsuarioRepositorio>(s, ruta)
        );

        return builder.Build();
	}
}
