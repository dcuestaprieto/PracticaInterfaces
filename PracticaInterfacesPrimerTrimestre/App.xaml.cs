using PracticaInterfacesPrimerTrimestre.Repositorios;

namespace PracticaInterfacesPrimerTrimestre;

public partial class App : Application
{
	public static UsuarioRepositorio UsuarioRepositorio { get; set; }
	
	public App(UsuarioRepositorio usuarioRepositorio)
	{
		UsuarioRepositorio = usuarioRepositorio;
		InitializeComponent();

		MainPage = new AppShell();
	}
}
