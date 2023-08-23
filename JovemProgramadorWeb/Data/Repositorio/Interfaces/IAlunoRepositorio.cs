using JovemProgramadorWeb.Models;

namespace JovemProgramadorWeb.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        List<Aluno> BuscarAlunos();
        void InserirAluno(Aluno aluno);
    }
}
