using JovemProgramadorWeb.Models;

namespace JovemProgramadorWeb.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        List<Aluno> BuscarAlunos();
        void InserirAluno(Aluno aluno);
        void RemoverAluno(Aluno aluno);
        void EditarAluno(Aluno aluno);
        Aluno BuscarId(int id);

    }
}
