using JovemProgramadorWeb.Data.Repositorio.Interfaces;
using JovemProgramadorWeb.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult AdicionarAluno()
        {
            return View();
        }
        public IActionResult ConfirmacaoCadastro()
        {
            ViewData["MsgCsdt"] = "Aluno(a) cadastrado(a) com sucesso!";

            return View("AdicionarAluno");
       }

    }
}
