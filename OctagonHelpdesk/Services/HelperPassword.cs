using System;
using System.Security.Cryptography;
using System.Text;

namespace OctagonHelpdesk.Services
{
    public static class HelperPassword
    {
        private const int SaltSize = 16; // Tamaño de la sal en bytes
        private const int HashSize = 32; // Tamaño del hash en bytes
        private const int Iterations = 10000; // Número de iteraciones para PBKDF2
        private const int PasswordLength = 12; // Longitud de la contraseña generada automáticamente

        public static string HashPassword(string password)
        {
            // Generar una sal criptográficamente segura
            byte[] salt;
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt = new byte[SaltSize]);
            }

            // Generar el hash usando PBKDF2
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // Combinar la sal y el hash en una sola cadena
            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            // Convertir a cadena base64 para almacenamiento
            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            // Convertir la cadena base64 a bytes
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // Extraer la sal
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Generar el hash para la contraseña ingresada usando la misma sal
            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // Comparar los hashes
            for (int i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool Checkifhashed(string password)
        {
            // Verificar si la cadena es una cadena base64 válida
            try
            {
                byte[] hashBytes = Convert.FromBase64String(password);
                return hashBytes.Length == (SaltSize + HashSize);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static string GeneratePassword(int length = PasswordLength)
        {
            string[] words = { "apple", "orange", "banana", "grape", "peach", "cherry", "berry", "melon", "kiwi", "plum" };
            const string specialChars = "123456789";
            Random random = new Random();

            StringBuilder password = new StringBuilder();

            // Agregar dos palabras aleatorias
            for (int i = 0; i < 2; i++)
            {
                password.Append(words[random.Next(words.Length)]);
            }

            // Agregar un número aleatorio
            password.Append(random.Next(10, 99));

            // Agregar un carácter especial aleatorio
            password.Append(specialChars[random.Next(specialChars.Length)]);

            return password.ToString();
        }
    }
}
