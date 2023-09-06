using JovemProgramadorWeb.Data.Repositorio.Interfaces;
using JovemProgramadorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace JovemProgramadorWeb.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IProfessorRepositorio _professorRepositorio;
        public ProfessorController(IConfiguration configuration, IProfessorRepositorio professorRepositorio)
        {
            _configuration = configuration;
            _professorRepositorio = professorRepositorio;
        }
        public IActionResult Index()
        {
            var professor = _professorRepositorio.BuscarProfessores();
            return View(professor);
        }
        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            Endereco endereco = new Endereco();
            try
            {
                cep = cep.Replace("-", "");
                using var client = new HttpClient();
                var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");

                if (result.IsSuccessStatusCode)
                {
                    endereco = JsonSerializer.Deserialize<Endereco>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });
                    ViewData["MsgCerto"] = "Busca realizada com sucesso!";
                }
                else
                {
                    ViewData["MsgErro"] = "Erro na busca do endreço!";
                }
            }
            catch (Exception)
            {
                throw;
            }

            return View("Endereco", endereco);
        }

        public IActionResult Adicionar(Professor professor)
        {
            return View();
        }
        public IActionResult EditarProfessor(int id)
        {
            Professor professor = _professorRepositorio.BuscarId(id);

            if (professor == null)
            {
                TempData["MsgErro"] = "Erro ao buscar professor";

            }

            return View(professor);
        }

        public IActionResult RemoverProfessor(Professor professor)
        {
            try
            {
                var id = _professorRepositorio.BuscarId(professor.id);
                _professorRepositorio.RemoverProfessor(id);
            }

            catch
            {
                TempData["MsgErro"] = "Erro ao inserir professor";

            }

            //var pessoa = _alunoRepositorio.BuscarId(aluno.id);

            // if (pessoa == null)
            // {
            //     TempData["MsgErroRemover"] = "Erro ao buscar o código do aluno";
            //     return RedirectToAction("Index");
            // }

            // _alunoRepositorio.RemoverAluno(pessoa);

            TempData["MsgSucesso"] = "Professor(a) removido(a) com sucesso!";


            return RedirectToAction("Index");

        }

        public IActionResult ProfessorEditado(Professor professor)
        {
            try
            {
                //var id = _alunoRepositorio.BuscarId(aluno.id);
                _professorRepositorio.EditarProfessor(professor);
            }

            catch (Exception)
            {
                TempData["MsgErro"] = "Erro ao editar professor(a)!";
            }
            TempData["MsgSucesso"] = "Professor(a) inserido(a) com sucesso!";

            return RedirectToAction("Index");
        }

        public IActionResult InserirProfessor(Professor professor)
        {
            try
            {
                _professorRepositorio.InserirProfessor(professor);
            }
            catch (Exception)
            {
                TempData["MsgErro"] = "Erro ao inserir professor(a)";
            }
            TempData["MsgSucesso"] = "Professor(a) inserido(a) com sucesso!";

            return RedirectToAction("Index");
        }
    }
}
