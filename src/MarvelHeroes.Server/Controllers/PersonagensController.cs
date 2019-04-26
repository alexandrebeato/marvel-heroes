using MarvelHeroes.Server.Interfaces;
using MarvelHeroes.Server.Models.Logs;
using MarvelHeroes.Server.Models.Personagens;
using Microsoft.AspNetCore.Mvc;

namespace MarvelHeroes.Server.Controllers
{
    [Route("")]
    public class PersonagensController : Controller
    {
        private readonly IPersonagemRepository _personagemRepository;
        private readonly ILogRepository _logRepository;

        public PersonagensController(IPersonagemRepository personagemRepository, ILogRepository logRepository)
        {
            _personagemRepository = personagemRepository;
            _logRepository = logRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("perfil/{id}")]
        public IActionResult Perfil([FromRoute] long id)
        {
            var personagem = _personagemRepository.ObterPorId(id);

            if (personagem == null)
                return View("NaoEncontrado");

            ViewData["Title"] = $"Perfil {personagem.Nome}";
            return View(personagem);
        }

        [HttpPost]
        public IActionResult Pesquisar([FromForm] PesquisaViewModel pesquisaViewModel)
        {
            _logRepository.Inserir(new LogViewModel($"Pesquisado por {pesquisaViewModel.Nome}."));
            var personagem = _personagemRepository.ObterPorNome(pesquisaViewModel.Nome);

            if (personagem == null)
                return View("NaoEncontrado");

            _logRepository.Inserir(new LogViewModel($"Encontrado {personagem.Nome} com o ID {personagem.Id}."));
            ViewData["Title"] = $"Perfil {personagem.Nome}";
            return View("Perfil", personagem);
        }
    }
}
