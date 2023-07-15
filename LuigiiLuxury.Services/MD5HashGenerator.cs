using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using LuigiiLuxury.Domain.Interfaces.Services;

namespace LuigiiLuxury.Services
{
    public static class MD5HashGenerator
    {
        // method change normal password into 32 hexadecimal digits.
        public static string GenerateMD5Hash(string normalPassword)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(normalPassword)); // Compute hash from the bytes of normal password

            byte[] result = md5.Hash; // Get hash result after compute it.
            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2")); // change it into 2 hexadecimal digits for each byte
            }

            return strBuilder.ToString();
        }
    }
}
