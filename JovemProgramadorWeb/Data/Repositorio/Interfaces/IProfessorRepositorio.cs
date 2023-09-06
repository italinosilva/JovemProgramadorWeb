using JovemProgramadorWeb.Models;

namespace JovemProgramadorWeb.Data.Repositorio.Interfaces
{
    public interface IProfessorRepositorio
    {
        List<Professor> BuscarProfessores();
        void InserirProfessor(Professor professor);
        void RemoverProfessor(Professor professor);
        void EditarProfessor(Professor professor);
        Professor BuscarId(int id);

    }
}