using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HashHelper
    {
        public static string GenerarHash(string Password)
        {
            using (SHA256 encriptado = SHA256.Create())
            {
                byte[] ArrayBytes = encriptado.ComputeHash(Encoding.UTF8.GetBytes(Password));

                StringBuilder constructor = new StringBuilder();

                foreach (byte b in ArrayBytes)
                {
                    constructor.Append(b.ToString("x2"));
                }

                return constructor.ToString();
            }

        }




    }
}
