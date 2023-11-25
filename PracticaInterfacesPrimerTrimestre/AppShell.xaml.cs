namespace PracticaInterfacesPrimerTrimestre;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Vista.VistaInicio), typeof(Vista.VistaInicio));
        Routing.RegisterRoute(nameof(Vista.VistaRegistro), typeof(Vista.VistaRegistro));
		Routing.RegisterRoute(nameof(Vista.VistaUsuarios), typeof(Vista.VistaUsuarios));
    }
}
