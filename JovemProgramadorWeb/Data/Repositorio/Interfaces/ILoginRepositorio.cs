using JovemProgramadorWeb.Models;

namespace JovemProgramadorWeb.Data.Repositorio.Interfaces
{
    public interface ILoginRepositorio
    {
        Login ValidarUsuario(Login login);
    }
}
