using JovemProgramadorWeb.Models;

namespace JovemProgramadorWeb.Data.Repositorio.Interfaces
{
    public interface ILoginRepositorio
    {
        Usuario ValidarUsuario(Usuario usuario);
    }
}
