using System;
using System.Security.Cryptography;
using System.Text;
using Crane.Domain;

namespace Crane.Infrastructure
{
    public class SHA256PasswordHandler : IPasswordHandler
    {
        private const int SaltLength = 32;
        
        private byte[] _salt;
        private byte[] _hash;

        private static byte[] GetSalt(int length)
        {
            using RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            byte[] salt = new byte[length];
            random.GetNonZeroBytes(salt);
            return salt;
        }

        private static byte[] JoinBytes(byte[] left, byte[] right)
        {
            byte[] joined = new byte[left.Length + right.Length];
            Buffer.BlockCopy(left, 0, joined, 0, left.Length);
            Buffer.BlockCopy(right, 0, joined, left.Length, right.Length);
            return joined;
        }

        private static byte[] GetSHA256Hash(byte[] left, byte[] right)
        {
            using SHA256 sha256 = SHA256.Create();
            return sha256.ComputeHash(JoinBytes(left, right));
        }

        public SHA256PasswordHandler(string password)
        {
            SetPassword(password);
        }

        public string GetToken(object o)
        {
            if (o == null) throw new ArgumentNullException(nameof(o));
            
            byte[] obj = Encoding.UTF8.GetBytes(o.ToString() ?? "");

            return Encoding.UTF8.GetString(GetSHA256Hash(obj, _hash));
        }

        public void SetPassword(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            
            byte[] pass = Encoding.UTF8.GetBytes(password);
            byte[] salt = GetSalt(SaltLength);
            byte[] hash = GetSHA256Hash(salt, pass);

            _salt = salt;
            _hash = hash;
        }

        public bool VerifyPassword(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            
            if (_salt == null || _hash == null) return false;
            byte[] pass = Encoding.UTF8.GetBytes(password);

            return _hash == GetSHA256Hash(_salt, pass);
        }
    }
}
