using Gtk;
using Gio;

namespace criptografia_csharp
{
    internal static class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            var application = Gtk.Application.New("io.github.emerson.criptografia", ApplicationFlags.FlagsNone);
            application.OnActivate += (sender, args) =>
            {
                var window = new MainWindow();
                window.SetApplication(application);
                window.Show();
            };

            return application.Run(args.Length, args);
        }
    }
}
