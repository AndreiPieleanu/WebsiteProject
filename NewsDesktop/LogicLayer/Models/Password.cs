using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class Password
    {
        public string? EncryptedPassword { get; }
        public string? Salt { get; }

        public Password()
        {
            Salt = GenerateSalt(16);
            EncryptedPassword = String.Empty;
            EncryptedPassword = GenerateEncryption(Salt, EncryptedPassword);
        }
        public Password(string password)
        {
            Salt = GenerateSalt(16);
            EncryptedPassword = GenerateEncryption(Salt, password);
        }

        public Password(string encrypted, string salt)
        {
            Salt = salt;
            EncryptedPassword = encrypted;
        }

        public string GenerateEncryption(string salt, string password)
        {
            SHA256 sha256 = SHA256.Create();
            // Get a byte array representing the password and salt
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(password + salt);
            // Encrypt the password and salt
            byte[] encryptedValue = sha256.ComputeHash(dataToEncrypt);
            // Convert to string so we can easily store in the data layer
            string encryptedPassword = Convert.ToBase64String(encryptedValue);
            // Return the result containing the salt and the encrypted password
            return encryptedPassword;
        }
        private string GenerateSalt(int saltLength)
        {
            RandomNumberGenerator? randomNumberGenerator = RandomNumberGenerator.Create();
            if (randomNumberGenerator is null)
            {
                throw new NullReferenceException(nameof(randomNumberGenerator));
            }
            // Create an empty salt array
            byte[] salt = new byte[saltLength];
            // Build the random bytes
            randomNumberGenerator.GetNonZeroBytes(salt);
            // Return the string encoded salt
            return Convert.ToBase64String(salt);
        }
    }
}
