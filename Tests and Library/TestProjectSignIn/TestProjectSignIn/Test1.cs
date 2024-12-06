using WpfLibraryFindWorker.Models;
using WpfLibraryFindWorker;
using Microsoft.EntityFrameworkCore;
namespace TestProjectSignIn
{
    [TestClass]
    public sealed class Test1
    {
        private FindWorkerContext _context;
        private ClassAuthorization _authorization;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<FindWorkerContext>()
                .UseSqlServer("Server=PC;Database=EquipmentRent;TrustServerCertificate=True;Trusted_Connection=True;")
                .Options;

            _context = new FindWorkerContext(options);

            _context.Database.EnsureCreated();

            _authorization = new ClassAuthorization(_context);
        }

        [TestMethod]
        public void Login_ShouldReturnEnter_ForValidClientCredentials()
        {
            string login = "FirstUser"; // Логин существующего соискателя
            string password = "FU123"; // Пароль существующего соискателя

            string result = _authorization.Signin(login, password);

            Assert.AreEqual("Вход в систему", result);
        }
        [TestMethod]
        public void Login_ShouldReturnError_ForValidClientCredentials()
        {
            string login = "123"; // Логин несуществующего соискателя
            string password = "123"; // Пароль несуществующего соискателя

            string result = _authorization.Signin(login, password);

            Assert.AreEqual("Вход в систему", result);
        }
    }
}

    

