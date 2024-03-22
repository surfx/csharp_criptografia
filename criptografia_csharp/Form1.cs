using code.openssl;

namespace criptografia_csharp
{
    public partial class frmCriptografiaOpenSSL : Form
    {
        public frmCriptografiaOpenSSL()
        {
            InitializeComponent();
        }



        private void frmCriptografiaOpenSSL_Load(object sender, EventArgs e)
        {
            txtPlainText.Focus();
        }

        private void btnCriptografiarOpenSSL_Click(object sender, EventArgs e)
        {
            OpenSSL? openssl = getOpenSSL();
            if (openssl == null) { return; }
            try
            {
                txtTextoCriptografado.Text = openssl.OpenSSLEncrypt(txtPlainText.Text);
                txtTextoCriptografado.Focus();
            }
            catch (Exception ex)
            {
                txtTextoCriptografado.Text = "Ocorreu um erro" + Environment.NewLine + Environment.NewLine + ex.ToString();
            }
            openssl = null;
        }

        private void btnDescriptografar_Click(object sender, EventArgs e)
        {
            OpenSSL? openssl = getOpenSSL();
            if (openssl == null) { return; }
            try
            {
                txtPlainText.Text = openssl.OpenSSLDecrypt(txtTextoCriptografado.Text);
                txtPlainText.Focus();
            }
            catch (Exception ex)
            {
                txtTextoCriptografado.Text = "Ocorreu um erro" + Environment.NewLine + Environment.NewLine + ex.ToString();
            }
            openssl = null;
        }

        private void btnCopiarPlain_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(txtPlainText.Text);
        }

        private void btnCopiarCripto_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(txtTextoCriptografado.Text);
        }

        private OpenSSL? getOpenSSL()
        {
            return new OpenSSL(txtPassphrase.Text, txtSalt.Text);
        }


    }
}