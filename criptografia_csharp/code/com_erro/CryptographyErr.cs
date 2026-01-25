using System.Security.Cryptography;
using System.Text;

namespace code.com_erro
{
    /// <summary>
    /// Possui erro na decriptografia
    /// </summary>
    public static class CryptographyErr
    {
        #region Settings

        private static readonly int _iterations = 2;
        private static readonly int _keySize = 256;

        private static readonly string _hash = "SHA1";
        private static readonly string _salt = "aselrias38490a32"; // Random
        private static readonly string _vector = "8947az34awl34kjq"; // Random

        #endregion

        public static string Encrypt(string value, string password)
        {
            using (Aes cipher = Aes.Create())
            {
                return EncryptAlgo(cipher, value, password);
            }
        }

        public static string Encrypt<T>(string value, string password)
                where T : SymmetricAlgorithm, new()
        {
            using (T cipher = new())
            {
                return EncryptAlgo(cipher, value, password);
            }
        }

        private static string EncryptAlgo(SymmetricAlgorithm cipher, string value, string password)
        {
            byte[] vectorBytes = ASCIIEncoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = ASCIIEncoding.ASCII.GetBytes(_salt);
            byte[] valueBytes = ASCIIEncoding.UTF8.GetBytes(value);

            byte[] encrypted;

            PasswordDeriveBytes _passwordBytes =
                new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
            byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

            cipher.Mode = CipherMode.CBC;

            using (ICryptoTransform encryptor = cipher.CreateEncryptor(keyBytes, vectorBytes))
            {
                using (MemoryStream to = new MemoryStream())
                {
                    using (CryptoStream writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write))
                    {
                        writer.Write(valueBytes, 0, valueBytes.Length);
                        writer.FlushFinalBlock();
                        encrypted = to.ToArray();
                    }
                }
            }
            cipher.Clear();

            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string value, string password)
        {
            using (Aes cipher = Aes.Create())
            {
                return DecryptAlgo(cipher, value, password);
            }
        }

        public static string Decrypt<T>(string value, string password) where T : SymmetricAlgorithm, new()
        {
            using (T cipher = new())
            {
                return DecryptAlgo(cipher, value, password);
            }
        }

        private static string DecryptAlgo(SymmetricAlgorithm cipher, string value, string password)
        {
            byte[] vectorBytes = ASCIIEncoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = ASCIIEncoding.ASCII.GetBytes(_salt);
            byte[] valueBytes = Convert.FromBase64String(value);

            byte[] decrypted;
            int decryptedByteCount = 0;

            PasswordDeriveBytes _passwordBytes = new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
            byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

            cipher.Mode = CipherMode.CBC;

            try
            {
                using (ICryptoTransform decryptor = cipher.CreateDecryptor(keyBytes, vectorBytes))
                {
                    using (MemoryStream from = new MemoryStream(valueBytes))
                    {
                        using (CryptoStream reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
                        {
                            decrypted = new byte[valueBytes.Length];
                            decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return String.Empty;
            }

            cipher.Clear();

            return Encoding.UTF8.GetString(decrypted, 0, decryptedByteCount);
        }

    }
}