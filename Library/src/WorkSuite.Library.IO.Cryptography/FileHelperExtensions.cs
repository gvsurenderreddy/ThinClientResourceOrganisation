using System.Security.Cryptography;
using System.Text;

namespace WTS.WorkSuite.Library.IO.Cryptography
{
    public static class FileHelperExtensions
    {
        public static string GetMD5Value(this FileHelper fileHelper, byte[] inputBytes)
        {
            byte[] computedHash = new MD5CryptoServiceProvider().ComputeHash(inputBytes);

            var sBuilder = new StringBuilder();

            foreach (byte b in computedHash)
            {
                sBuilder.Append(b.ToString("x2").ToLower());
            }

            return sBuilder.ToString();
        }
    }
}
