using JovemProgramadorWeb.Data.Repositorio.Interfaces;
using JovemProgramadorWeb.Models;

namespace JovemProgramadorWeb.Data.Repositorio
{
    public class LoginRepositorio : ILoginRepositorio
    {

        private readonly BancoContexto _bancoContexto;

        public LoginRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }
        public Usuario ValidarUsuario(Usuario usuario)
        {
            return _bancoContexto.Usuario.FirstOrDefault(x => x.usuario == usuario.usuario && x.senha == usuario.senha);
        }
    }

}