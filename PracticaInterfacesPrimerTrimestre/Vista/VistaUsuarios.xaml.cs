namespace PracticaInterfacesPrimerTrimestre.Vista;

public partial class VistaUsuarios : ContentPage
{
	public VistaUsuarios()
	{
		InitializeComponent();
		lista.ItemsSource = App.UsuarioRepositorio.showUsuarios();

    }
}