namespace RedGrimV2;

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
				fonts.AddFont("disco.ttf", "Disco");
                fonts.AddFont("Expletus.ttf", "Expletus");
                fonts.AddFont("Rexlia.otf", "Rexlia");
                fonts.AddFont("vdub.ttf", "vdub");
            });

		return builder.Build();
	}
}
