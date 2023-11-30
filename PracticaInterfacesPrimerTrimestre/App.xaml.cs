using PracticaInterfacesPrimerTrimestre.Repositorios;

namespace PracticaInterfacesPrimerTrimestre;

public partial class App : Application
{
	public static UsuarioRepositorio UsuarioRepositorio { get; set; }

    const int WindowWidth = 600;
    const int WindowHeight = 600;

    public App(UsuarioRepositorio usuarioRepositorio)
	{
		UsuarioRepositorio = usuarioRepositorio;
		InitializeComponent();



        MainPage = new AppShell();
	}

}
