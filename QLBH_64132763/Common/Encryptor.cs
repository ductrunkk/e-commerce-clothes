using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace QLBH_64132763.Common
{
    public class Encryptor
    {
        // Băm mật khẩu với SHA-256
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        //// Kiểm tra mật khẩu đã băm
        //public static bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        //{
        //    string enteredHashedPassword = HashPassword(enteredPassword);
        //    return enteredHashedPassword == storedHashedPassword;
        //}
    }
}