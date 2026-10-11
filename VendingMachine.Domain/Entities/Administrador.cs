using VendingMachine.Domain.ValueObjects;
namespace VendingMachine.Domain.Entities
{
    public class Administrador
    {
        public Guid Id { get; private set; }
        public Login Login { get; private set; } = null!;
        private Administrador() { }

        public Administrador(string login)
        {
            Login = new Login(login);
        }
    }
}
