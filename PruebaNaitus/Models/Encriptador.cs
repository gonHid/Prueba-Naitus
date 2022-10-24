using System.Security.Cryptography;
using System.Text;

namespace PruebaNaitus.Models
{
    public class Encriptador
    {

        public static string ObtenerSha256(string pass)
        {
            SHA256 sha = SHA256.Create();
            ASCIIEncoding asciE = new ASCIIEncoding();
            byte[] bytes = sha.ComputeHash(asciE.GetBytes(pass));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
                sb.AppendFormat("{0:x2}", bytes[i]);

            return sb.ToString();
        }
    }
}
