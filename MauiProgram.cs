namespace ShoppingListMobileApp1;

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
                fonts.AddFont("Epilogue-Medium.ttf", "Epilogue");
                fonts.AddFont("fontello.ttf", "Icons");
                fonts.AddFont("Rubik-Regular.ttf", "RubikRegular");
                fonts.AddFont("Rubik-Light.ttf", "RubikLight");
            });

		return builder.Build();
	}
}
