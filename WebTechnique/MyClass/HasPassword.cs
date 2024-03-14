using System.Security.Cryptography;
using System.Text;

namespace WebTechnique.MyClass
{
    public class HasPassword
    {
        private const string Salt = "G&29$dPz8NqS#m5^YfTc"; // Фиксированная соль

        private string _passwordHash;

        public string PasswordHash
        {
            get { return _passwordHash; }
            set
            {
                // Хэшируем пароль с использованием фиксированной соли
                _passwordHash = HashPassword(value);
            }
        }

        // Метод для хэширования пароля с использованием фиксированной соли
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Объединяем пароль и соль
                byte[] combinedBytes = Encoding.UTF8.GetBytes(password + Salt);

                // Хэшируем пароль с солью
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);

                // Преобразуем хэш в строку для хранения в базе данных
                return Convert.ToBase64String(hashBytes);
            }
        }
 
    }
}
