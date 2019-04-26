using MarvelHeroes.Server.Interfaces;
using MarvelHeroes.Server.Models.Logs;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MarvelHeroes.Server.Data
{
    public class LogRepository : ILogRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoClient _mongoClient;
        protected readonly IMongoCollection<LogViewModel> _mongoCollection;

        public LogRepository(IConfiguration configuration, IMongoClient mongoClient)
        {
            _configuration = configuration;
            _mongoClient = mongoClient;
            _mongoCollection = _mongoClient.GetDatabase(_configuration["mongo:nome"]).GetCollection<LogViewModel>("Logs");
        }

        public void Inserir(LogViewModel logViewModel)
        {
            _mongoCollection.InsertOne(logViewModel);
        }

        public LogViewModel ObterPorId(Guid id)
        {
            return _mongoCollection.Find(l => l.Id == id).FirstOrDefault();
        }

        public IEnumerable<LogViewModel> ObterTodos()
        {
            return _mongoCollection.Find(l => true).ToList();
        }
    }
}
