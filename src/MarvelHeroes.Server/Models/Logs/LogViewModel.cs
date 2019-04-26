using System;

namespace MarvelHeroes.Server.Models.Logs
{
    public class LogViewModel
    {
        public LogViewModel(string conteudo)
        {
            Id = Guid.NewGuid();
            DataHora = DateTime.UtcNow;
            Conteudo = conteudo;
        }

        public Guid Id { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataHora { get; set; }
    }
}
