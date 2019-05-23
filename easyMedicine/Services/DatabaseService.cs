using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using easyMedicine.Models;

namespace easyMedicine.Services
{
    public class DatabaseService
    {
        string apiBaseUrl = "https://easypedapi.azurewebsites.net/api/v1";

        public DatabaseService()
        {
        }

        public async Task<int> GetLastestDBVersion()
        {
            return await ApiClient.Instance.Get<int>(apiBaseUrl + "/appdb/latest?appversion=" + Configurations.APP_VERSION.ToString());
        }

        public async Task<int> GetDB(int version)
        {

            return await ApiClient.Instance.Get<int>(apiBaseUrl + "/appdb/version?token=" + Encrypt(version));
        }

        public static string Encrypt(int idVersion)
        {

            /*


            byte[] keyMaterial = Encoding.UTF8.GetBytes("743677397A244326452948404D635166");
            //var data = Encoding.UTF8.GetBytes("{ id: " + idVersion.ToString() + ", app: 'easyPed', date: " + DateTime.UtcNow.ToString("YYYYMMddHHmmss") + " }");

            var str = "aaaaaa";

            var data = Encoding.UTF8.GetBytes(str);

            var provider = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7);
            var key = provider.CreateSymmetricKey(keyMaterial);

            // The IV may be null, but supplying a random IV increases security.
            // The IV is not a secret like the key is.
            // You can transmit the IV (w/o encryption) alongside the ciphertext.
            //var iv = WinRTCrypto.CryptographicBuffer.GenerateRandom(provider.BlockLength);

            byte[] cipherText = WinRTCrypto.CryptographicEngine.Encrypt(key, data);

            var ret = Convert.ToBase64String(cipherText);


            Debug.WriteLine(ret);
            return ret;

            // When decrypting, use the same IV that was passed to encrypt.
            // byte[] plainText = WinRTCrypto.CryptographicEngine.Decrypt(key, cipherText, iv);
            */
            return String.Empty;
        }
    }
}
