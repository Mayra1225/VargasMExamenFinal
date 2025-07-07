using Microsoft.Extensions.Logging;

namespace VargasMExamenFinal.Views;

public partial class LogPage : ContentPage
{
	public LogPage()
	{
		InitializeComponent();
		LoadLogs();
	}
    private void LoadLogs()
    {
        var path = Path.Combine(FileSystem.AppDataDirectory, "Logs_Vargas.txt");
        if (File.Exists(path))
            logLabel.Text = File.ReadAllText(path);
    }
}