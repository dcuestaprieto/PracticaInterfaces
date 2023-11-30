using PracticaInterfacesPrimerTrimestre.Repositorios;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
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

        UsuarioRepositorio = usuarioRepositorio;
        InitializeComponent();
        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
            var mauiWindow = handler.VirtualView;
            var nativeWindow = handler.PlatformView;
            nativeWindow.Activate();
            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
            WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
            AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new SizeInt32(WindowWidth, WindowHeight));
            var presenter = appWindow.Presenter as OverlappedPresenter;
            presenter.IsResizable = false;
        });

        MainPage = new AppShell();
	}


}
