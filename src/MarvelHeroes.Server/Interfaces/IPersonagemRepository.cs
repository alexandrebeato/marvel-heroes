using MarvelHeroes.Server.Models.Personagens;

namespace MarvelHeroes.Server.Interfaces
{
    public interface IPersonagemRepository
    {
        PersonagemViewModel ObterPorId(long id);
        PersonagemViewModel ObterPorNome(string nome);
    }
}
