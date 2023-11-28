namespace CallApp.Application.Infrastructure.Services
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(bool status, string email);
    }
}
