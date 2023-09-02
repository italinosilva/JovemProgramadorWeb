using JovemProgramadorWeb.Data.Repositorio.Interfaces;
using JovemProgramadorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace JovemProgramadorWeb.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAlunoRepositorio _alunoRepositorio;
        public AlunoController(IConfiguration configuration, IAlunoRepositorio alunoRepositorio)
        {
            _configuration = configuration;
            _alunoRepositorio = alunoRepositorio;
        }
        public IActionResult Index()
        {
            var aluno = _alunoRepositorio.BuscarAlunos();
            return View(aluno);
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

        public IActionResult Adicionar(Aluno aluno)
        {
            return View();
        }
        public IActionResult EditarAluno(Aluno aluno)
        {
            return View();
        }

        public IActionResult RemoverAluno(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.RemoverAluno(aluno);
            }

            catch
            {
                TempData["MsgErro"] = "Erro ao inserir aluno";

            }

            //var pessoa = _alunoRepositorio.BuscarId(aluno.id);

            // if (pessoa == null)
            // {
            //     TempData["MsgErroRemover"] = "Erro ao buscar o código do aluno";
            //     return RedirectToAction("Index");
            // }

            // _alunoRepositorio.RemoverAluno(pessoa);

            TempData["MsgSucesso"] = "Aluno(a) removido(a) com sucesso!";


            return RedirectToAction("Index");
            
        }

        public IActionResult Remover(int id)
        {
            return View();
        }

        public IActionResult InserirAluno(Aluno aluno)
        {
           try
            {
                _alunoRepositorio.InserirAluno(aluno);
            }
            catch (Exception)
            {
                TempData["MsgErro"] = "Erro ao inserir aluno";
            }
            TempData["MsgSucesso"] = "Aluno(a) inserido(a) com sucesso!";

            return RedirectToAction("Index");
        }
    }
}
