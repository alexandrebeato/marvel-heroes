using MarvelHeroes.Server.Models.Logs;
using System;
using System.Collections.Generic;

namespace MarvelHeroes.Server.Interfaces
{
    public interface ILogRepository
    {
        void Inserir(LogViewModel logViewModel);
        LogViewModel ObterPorId(Guid id);
        IEnumerable<LogViewModel> ObterTodos();
    }
}
