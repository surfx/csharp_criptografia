using Gtk;
using Gdk;
using code.openssl;
using System.Text;

namespace criptografia_csharp
{
    public class MainWindow : Gtk.Window
    {
        private TextView txtPlainText;
        private TextView txtTextoCriptografado;
        private Entry txtPassphrase;
        private Entry txtSalt;

        public MainWindow()
        {
            SetTitle("Criptografia OpenSSL");
            SetupAppIcon();
            SetDefaultSize(1000, 800);

            var mainBox = Box.New(Orientation.Vertical, 10);
            mainBox.SetMarginTop(10);
            mainBox.SetMarginBottom(10);
            mainBox.SetMarginStart(10);
            mainBox.SetMarginEnd(10);
            SetChild(mainBox);

            // Plain Text
            mainBox.Append(Label.New("Plain Text"));
            
            txtPlainText = TextView.New();
            txtPlainText.SetVexpand(true);
            txtPlainText.SetWrapMode(WrapMode.Word);
            var scrollPlain = ScrolledWindow.New();
            scrollPlain.SetChild(txtPlainText);
            scrollPlain.SetMinContentHeight(250);
            mainBox.Append(scrollPlain);

            // Plain Controls
            var plainControls = Box.New(Orientation.Horizontal, 5);
            var btnCopiarPlain = Button.NewWithLabel("Copiar");
            btnCopiarPlain.OnClicked += (s, e) => CopiarParaClipboard(GetTextViewText(txtPlainText));
            
            var btnCriptografar = Button.NewWithLabel("Criptografar");
            btnCriptografar.OnClicked += btnCriptografiarOpenSSL_Click;
            
            plainControls.Append(Box.New(Orientation.Horizontal, 0)); // Spacer
            plainControls.Append(btnCopiarPlain);
            plainControls.Append(btnCriptografar);
            mainBox.Append(plainControls);

            // Criptografado
            mainBox.Append(Label.New("Criptografado"));
            
            txtTextoCriptografado = TextView.New();
            txtTextoCriptografado.SetVexpand(true);
            txtTextoCriptografado.SetWrapMode(WrapMode.Word);
            var scrollCripto = ScrolledWindow.New();
            scrollCripto.SetChild(txtTextoCriptografado);
            scrollCripto.SetMinContentHeight(250);
            mainBox.Append(scrollCripto);

            // Bottom Controls
            var bottomControls = Box.New(Orientation.Horizontal, 10);
            
            bottomControls.Append(Label.New("passphrase"));
            txtPassphrase = Entry.New();
            txtPassphrase.SetText("qwerty");
            bottomControls.Append(txtPassphrase);
            
            bottomControls.Append(Label.New("salt"));
            txtSalt = Entry.New();
            txtSalt.SetText("241fa86763b85341");
            bottomControls.Append(txtSalt);

            var btnCopiarCripto = Button.NewWithLabel("Copiar");
            btnCopiarCripto.OnClicked += (s, e) => CopiarParaClipboard(GetTextViewText(txtTextoCriptografado));
            bottomControls.Append(btnCopiarCripto);

            var btnDescriptografar = Button.NewWithLabel("DesCriptografar");
            btnDescriptografar.OnClicked += btnDescriptografar_Click;
            bottomControls.Append(btnDescriptografar);

            mainBox.Append(bottomControls);
        }

        private void SetupAppIcon()
        {
            try
            {
                const string iconName = "criptografia_csharp";
                const string appId = "io.github.emerson.criptografia";

                var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                var iconThemeDir = Path.Combine(home, ".local", "share", "icons", "hicolor");
                var appsDir = Path.Combine(home, ".local", "share", "applications");
                var assetsDir = Path.Combine(AppContext.BaseDirectory, "assets");

                var sizes = new[] { ("32", "cadeado_32.png"), ("48", "cadeado_48.png"), ("128", "cadeado_128.png") };
                foreach (var (size, file) in sizes)
                {
                    var src = Path.Combine(assetsDir, file);
                    var dstDir = Path.Combine(iconThemeDir, $"{size}x{size}", "apps");
                    Directory.CreateDirectory(dstDir);
                    var dst = Path.Combine(dstDir, $"{iconName}.png");
                    if (File.Exists(src))
                    {
                        File.Copy(src, dst, true);
                    }
                }

                Directory.CreateDirectory(appsDir);
                var desktopPath = Path.Combine(appsDir, $"{appId}.desktop");
                if (!File.Exists(desktopPath))
                {
                    File.WriteAllText(desktopPath,
                        "[Desktop Entry]\nName=Criptografia OpenSSL\nIcon=" + iconName + "\nType=Application\nCategories=Utility;\nNoDisplay=true\n");
                }

                SetIconName(iconName);
            }
            catch
            {
            }
        }

        private string GetTextViewText(TextView textView)
        {
            return textView.GetBuffer()?.Text ?? string.Empty;
        }

        private void SetTextViewText(TextView textView, string text)
        {
            textView.GetBuffer().Text = text;
        }

        private void CopiarParaClipboard(string text)
        {
            var display = GetDisplay();
            if (display != null)
            {
                var clipboard = display.GetClipboard();
                clipboard.SetText(text);
            }
        }

        private void btnCriptografiarOpenSSL_Click(object? sender, EventArgs e)
        {
            OpenSSL openssl = new OpenSSL(txtPassphrase.GetText(), txtSalt.GetText());
            try
            {
                string text = GetTextViewText(txtPlainText);
                SetTextViewText(txtTextoCriptografado, openssl.OpenSSLEncrypt(text));
            }
            catch (Exception ex)
            {
                SetTextViewText(txtTextoCriptografado, "Ocorreu um erro\n\n" + ex.ToString());
            }
        }

        private void btnDescriptografar_Click(object? sender, EventArgs e)
        {
            OpenSSL openssl = new OpenSSL(txtPassphrase.GetText(), txtSalt.GetText());
            try
            {
                string text = GetTextViewText(txtTextoCriptografado);
                SetTextViewText(txtPlainText, openssl.OpenSSLDecrypt(text));
            }
            catch (Exception ex)
            {
                SetTextViewText(txtTextoCriptografado, "Ocorreu um erro\n\n" + ex.ToString());
            }
        }
    }
}
