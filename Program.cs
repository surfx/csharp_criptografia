using System.Security.Cryptography;
using System.Text;
using code;
using code.openssl;

class Class1
{

    static void Main()
    {
        testeCriptografarArquivos();
        //System.Console.WriteLine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName);
    }

    private static void testeCriptografarArquivos(string password = "")
    {
        //string path = @"D:\meus_documentos\workspace\c_sharp\cripto\csharp_criptografia\testesarquivos\";
        string aux = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        string path = $@"{aux}\testesarquivos\";
        string arquivoEntrada = $@"{path}arquivo-original.txt";
        if (!File.Exists(arquivoEntrada)) { return; }
        string arquivoSaida = $@"{path}saida_cript.txt";
        if (File.Exists(arquivoSaida)) { File.Delete(arquivoSaida); }
        string arquivoDecript = $@"{path}decriptado.txt";
        if (File.Exists(arquivoDecript)) { File.Delete(arquivoDecript); }

        CryptFiles cfiles = new("#$qsdf@@werty", "241fa86763b85341");

        cfiles.CriptFile(arquivoEntrada, arquivoSaida);
        cfiles.DeCriptFile(arquivoSaida, arquivoDecript);

        System.Console.WriteLine("-- análise linha a linha");

        string[] linhas1 = File.ReadAllLines(arquivoEntrada);
        string[] linhas2 = File.ReadAllLines(arquivoDecript);

        bool ok = true;
        if (linhas1.Length != linhas2.Length) { System.Console.WriteLine("indício de erro"); }
        int nlines = Math.Min(linhas1.Length, linhas2.Length);
        for (int i = 0; i < nlines; i++)
        {
            string l1 = linhas1[i];
            string l2 = linhas2[i];
            if (l1 != l2)
            {
                ok = false;
                System.Console.WriteLine("Divergência '{0}'", l1.Replace(l2, ""));
            }
        }
        System.Console.WriteLine(ok ? "all ok" : "erros encontrados");
    }

    #region cript file
    private static void criptFile(string texto, string arquivoSaida)
    {
        try
        {
            using (FileStream fileStream = new(arquivoSaida, FileMode.OpenOrCreate))
            {
                using (Aes aes = Aes.Create())
                {
                    byte[] key =
                    {
                        0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                        0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
                    };
                    aes.Key = key;

                    byte[] iv = aes.IV;
                    fileStream.Write(iv, 0, iv.Length);

                    using (CryptoStream cryptoStream = new(
                        fileStream,
                        aes.CreateEncryptor(),
                        CryptoStreamMode.Write))
                    {
                        // By default, the StreamWriter uses UTF-8 encoding.
                        // To change the text encoding, pass the desired encoding as the second parameter.
                        // For example, new StreamWriter(cryptoStream, Encoding.Unicode).
                        using (StreamWriter encryptWriter = new(cryptoStream))
                        {
                            encryptWriter.WriteLine(texto);
                        }
                    }
                }
            }

            Console.WriteLine("The file was encrypted.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"The encryption failed. {ex}");
        }
    }

    private static async Task deCriptFileAsync(string arquivoSaida)
    {
        try
        {
            using (FileStream fileStream = new(arquivoSaida, FileMode.Open))
            {
                using (Aes aes = Aes.Create())
                {
                    byte[] iv = new byte[aes.IV.Length];
                    int numBytesToRead = aes.IV.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        int n = fileStream.Read(iv, numBytesRead, numBytesToRead);
                        if (n == 0) break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }

                    byte[] key =
                    {
                        0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                        0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
                    };

                    using (CryptoStream cryptoStream = new(
                       fileStream,
                       aes.CreateDecryptor(key, iv),
                       CryptoStreamMode.Read))
                    {
                        // By default, the StreamReader uses UTF-8 encoding.
                        // To change the text encoding, pass the desired encoding as the second parameter.
                        // For example, new StreamReader(cryptoStream, Encoding.Unicode).
                        using (StreamReader decryptReader = new(cryptoStream))
                        {
                            string decryptedMessage = await decryptReader.ReadToEndAsync();
                            Console.WriteLine($"The decrypted original message: {decryptedMessage}");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"The decryption failed. {ex}");
        }
    }
    #endregion

    #region teste 1
    private static byte[]? cript(string texto)
    {
        try
        {
            MemoryStream ms = new();
            using Aes aes = Aes.Create();
            byte[] key =
            {
                0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
            };
            aes.Key = key;

            byte[] iv = aes.IV;
            ms.Write(iv, 0, iv.Length);

            CryptoStream cryptoStream = new(
                            ms,
                            aes.CreateEncryptor(),
                            CryptoStreamMode.Write);
            StreamWriter encryptWriter = new(cryptoStream, Encoding.ASCII);
            encryptWriter.WriteLine(texto);

            cryptoStream.Flush();
            encryptWriter.Flush();
            //ms.Flush();
            //ms.Position = 0;
            byte[] rt = ms.ToArray();

            encryptWriter.Close();
            cryptoStream.Close();
            ms.Close();

            return rt;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"The encryption failed. {ex}");
            return null;
        }
    }

    private static async Task<string> deCript(byte[] criptografado)
    {
        try
        {
            using (MemoryStream ms = new(criptografado))
            {
                using (Aes aes = Aes.Create())
                {
                    byte[] iv = new byte[aes.IV.Length];
                    int numBytesToRead = aes.IV.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        int n = ms.Read(iv, numBytesRead, numBytesToRead);
                        if (n == 0) break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }

                    byte[] key =
                    {
                        0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                        0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
                    };

                    using (CryptoStream cryptoStream = new(
                       ms,
                       aes.CreateDecryptor(key, iv),
                       CryptoStreamMode.Read))
                    {
                        using (StreamReader decryptReader = new(cryptoStream, Encoding.ASCII))
                        {
                            string decryptedMessage = await decryptReader.ReadToEndAsync();
                            Console.WriteLine($"The decrypted original message: '{decryptedMessage}'");
                            return decryptedMessage;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"The decryption failed. {ex}");
            return string.Empty;
        }
    }
    #endregion

    #region teste cript plano
    private static void teste3()
    {
        string texto = "Emerson sdfasdf #$qsdf@@werty";

        string passphrase = "#$qsdf@@werty";
        string salt = "241fa86763b85341";

        OpenSSL openssl = new(passphrase, salt);
        string txtCript = openssl.OpenSSLEncrypt(texto);
        string txtDecript = openssl.OpenSSLDecrypt(txtCript);

        System.Console.WriteLine("texto: '{0}'", texto);
        System.Console.WriteLine("txtCript: '{0}'", txtCript);
        System.Console.WriteLine("txtDecript: '{0}'", txtDecript);
        System.Console.WriteLine(txtDecript == texto);

    }

    #endregion

}