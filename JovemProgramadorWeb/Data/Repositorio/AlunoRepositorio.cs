using JovemProgramadorWeb.Data.Repositorio.Interfaces;
using JovemProgramadorWeb.Models;

namespace JovemProgramadorWeb.Data.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {

        private readonly BancoContexto _bancoContexto;

        public AlunoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }
        public List<Aluno> BuscarAlunos()
        {
            return _bancoContexto.Aluno.ToList();
        }

        public void InserirAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Add(aluno);
            _bancoContexto.SaveChanges();
        }
        public Aluno BuscarId(int id)
        {
            return _bancoContexto.Aluno.FirstOrDefault(x => x.id == id);
        }
        
        public void RemoverAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Remove(aluno);
            _bancoContexto.SaveChanges();
        }
    }
}
