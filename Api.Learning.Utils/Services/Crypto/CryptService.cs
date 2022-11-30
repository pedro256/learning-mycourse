using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Utils.Services.Crypto
{
    public class CryptService
    {

        public static string EncryptToPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool ComparePasswordHash(string password,string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
