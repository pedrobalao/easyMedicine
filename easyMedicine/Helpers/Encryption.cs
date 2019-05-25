using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace easyMedicine.Helpers
{

    public class EncryptedData
    {
        public string IV
        {
            get;
            set;
        }
        public string Cypher
        {
            get;
            set;
        }
    }
    public static class Encryption
    {

        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        private static byte[] GenerateRandomIV()
        {
            var rnd = new RNGCryptoServiceProvider();
            var b = new byte[16];
            rnd.GetNonZeroBytes(b);
            return b;
        }

        public static EncryptedData Encrypt(string data)
        {

            var key = StringToByteArray("41B48893F1E276023480F26D92524F65A5C39F4A2BBC69D5737659FB8292C957");

            var iv = GenerateRandomIV();

            byte[] clearData = Encoding.UTF8.GetBytes(data);

            using (Rijndael alg = Rijndael.Create())
            {
                alg.Key = key;
                alg.IV = iv;

                using (var ms = new MemoryStream())
                {
                    CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
                    cs.Write(clearData, 0, clearData.Length);
                    cs.Close();
                    byte[] encryptedData = ms.ToArray();
                    var cypher = BitConverter.ToString(encryptedData).Replace("-", "").ToLowerInvariant();
                    return new EncryptedData { IV = ByteArrayToString(iv), Cypher = cypher };
                }
            }

        }
    }
}
