using System.Text;
using System.Security.Cryptography;

namespace MarGate.Identity.Application.Extensions
{
    public static class StringExtensions
    {
        public static string Md5Encryption(this string text)
        {
            byte[] array = Encoding.UTF8.GetBytes(text);

            array = MD5.HashData(array);
            var stringBuilder = new StringBuilder();

            foreach (byte ba in array)
            {
                stringBuilder.Append(ba.ToString("x2").ToLower());
            }

            return stringBuilder.ToString();
        }
    }
}
