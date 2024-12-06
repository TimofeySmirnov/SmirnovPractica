using WpfLibraryFindWorker.Models;
namespace WpfLibraryFindWorker
{
    public class ClassAuthorization
    {
        private readonly FindWorkerContext _context;

        public ClassAuthorization(FindWorkerContext context)
        {
            _context = context;
        }

        public string Signin(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return "Введите логин и пароль!";
            }

            var users = _context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
 
            if (users != null)
            {
                return "Вход в систему";
            }
            
            else
            {
                return "Неверный логин или пароль!";
            }
        }
    }
}



