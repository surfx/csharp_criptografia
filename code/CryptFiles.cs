using System.Text;
using code.openssl;

namespace code
{
    public class CryptFiles
    {

        private OpenSSL openssl;

        public CryptFiles(string passphrase = "qwerty", string salt = "241fa86763b85341")
        {
            openssl = new(passphrase, salt);
        }

        //where T : SymmetricAlgorithm, new()

        public bool CriptFile(string arquivoEntrada, string arquivoSaida)
        {
            if (openssl == null) { return false; }
            if (string.IsNullOrEmpty(arquivoEntrada) || string.IsNullOrEmpty(arquivoSaida)) { return false; }
            if (!File.Exists(arquivoEntrada)) { return false; }
            if (File.Exists(arquivoSaida)) { File.Delete(arquivoSaida); }

            using FileStream fsRead = File.OpenRead(arquivoEntrada);
            using StreamReader sr = new(fsRead, Encoding.UTF8, true, 128);
            if (sr == null) { return false; }

            using FileStream fsWrite = File.OpenWrite(arquivoSaida);
            using StreamWriter sw = new(fsWrite);

            string? line = null;
            while ((line = sr.ReadLine()) != null)
            {
                if (line == null) { continue; }
                sw.WriteLine(openssl.OpenSSLEncrypt(line));
            }

            sw.Close();
            fsWrite.Close();
            sr.Close();
            fsRead.Close();
            return true;
        }


        //where T : SymmetricAlgorithm, new()
        public bool DeCriptFile(string arquivoEntrada, string arquivoSaida)
        {
            if (openssl == null) { return false; }
            if (string.IsNullOrEmpty(arquivoEntrada) || string.IsNullOrEmpty(arquivoSaida)) { return false; }
            if (!File.Exists(arquivoEntrada)) { return false; }
            if (File.Exists(arquivoSaida)) { File.Delete(arquivoSaida); }

            using FileStream fsRead = File.OpenRead(arquivoEntrada);
            using StreamReader sr = new(fsRead, Encoding.UTF8, true, 128);

            using FileStream fsWrite = File.OpenWrite(arquivoSaida);
            using StreamWriter sw = new(fsWrite);

            string? line = null;
            while ((line = sr.ReadLine()) != null)
            {
                if (line == null) { continue; }
                sw.WriteLine(openssl.OpenSSLDecrypt(line));
            }

            sw.Close();
            fsWrite.Close();
            sr.Close();
            fsRead.Close();
            return true;
        }

    }
}