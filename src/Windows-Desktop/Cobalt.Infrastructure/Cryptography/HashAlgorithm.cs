using System;
using System.Security.Cryptography;

namespace Cobalt.Infrastructure.Cryptography
{
    public static class HashAlgorithm
    {
        /// <summary>
        /// Generates a new hash and salt key. Returns as an array, [0] Hash, [1] Salt.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string[] GenerateNewHash(string password)
        {
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, 32)
            {
                IterationCount = 10000
            };

            var hash = rfc2898DeriveBytes.GetBytes(20);
            var salt = rfc2898DeriveBytes.Salt;

            return new[]
            {
                Convert.ToBase64String(hash),
                Convert.ToBase64String(salt)
            };
        }

        /// <summary>
        /// Returns an existing hash if provided with an existing salt key.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string GenerateExistingHash(string password, byte[] salt)
        {
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt)
            {
                IterationCount = 10000
            };

            var hash = rfc2898DeriveBytes.GetBytes(20);

            return Convert.ToBase64String(hash);
        }
    }
}
