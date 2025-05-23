namespace Clase11.Services
{
    public interface IFirebaseAuthService
    {
        public Task<string?> SignUp(string email, string password);
        public Task<string?> Login(string email, string password);
        public void SignOut();
    }
}
