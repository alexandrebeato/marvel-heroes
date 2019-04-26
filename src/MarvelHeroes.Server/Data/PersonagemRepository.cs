using MarvelHeroes.Server.Interfaces;
using MarvelHeroes.Server.Models.Personagens;
using MarvelHeroes.Server.Utils;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace MarvelHeroes.Server.Data
{
    public class PersonagemRepository : IPersonagemRepository
    {
        private readonly IRestClient _restClient;
        private readonly IDistributedCache _distributedCache;
        private readonly string _publicKey;
        private readonly string _privateKey;

        public PersonagemRepository(IConfiguration configuration, IDistributedCache distributedCache)
        {
            _restClient = new RestClient(configuration["marvelApi:endpoint"]).UseSerializer(() => new JsonNetSerializer());
            _distributedCache = distributedCache;
            _publicKey = configuration["marvelApi:publicKey"];
            _privateKey = configuration["marvelApi:privateKey"];
        }

        private string GerarHash(string timeStamp, string publicKey, string privateKey)
        {
            var bytes = Encoding.UTF8.GetBytes(timeStamp + privateKey + publicKey);
            var gerador = MD5.Create();
            var bytesHash = gerador.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash).ToLower().Replace("-", string.Empty);
        }

        public PersonagemViewModel ObterPorId(long id)
        {
            var personagemCacheado = _distributedCache.GetString(id.ToString());

            if (!string.IsNullOrEmpty(personagemCacheado))
                return JsonConvert.DeserializeObject<PersonagemViewModel>(personagemCacheado);

            var request = new RestRequest("characters/{id}", Method.GET);
            var timeStamp = DateTime.UtcNow.Ticks.ToString();
            request.AddUrlSegment("id", id);
            request.AddParameter("ts", timeStamp);
            request.AddParameter("apikey", _publicKey);
            request.AddParameter("hash", GerarHash(timeStamp, _publicKey, _privateKey));
            var response = _restClient.Get(request);

            if (!response.IsSuccessful)
                return null;

            dynamic resultado = JsonConvert.DeserializeObject<dynamic>(response.Content);
            PersonagemViewModel personagem = JsonConvert.DeserializeObject<PersonagemViewModel>(JsonConvert.SerializeObject(resultado.data.results[0]));
            _distributedCache.SetString(personagem.Id.ToString(), JsonConvert.SerializeObject(personagem));
            return personagem;
        }

        public PersonagemViewModel ObterPorNome(string nome)
        {
            var personagemCacheado = _distributedCache.GetString(nome.ToBase64());

            if (!string.IsNullOrEmpty(personagemCacheado))
                return JsonConvert.DeserializeObject<PersonagemViewModel>(personagemCacheado);

            var request = new RestRequest("characters", Method.GET);
            var timeStamp = DateTime.UtcNow.Ticks.ToString();
            request.AddParameter("name", nome);
            request.AddParameter("ts", timeStamp);
            request.AddParameter("apikey", _publicKey);
            request.AddParameter("hash", GerarHash(timeStamp, _publicKey, _privateKey));
            var response = _restClient.Get(request);

            if (!response.IsSuccessful)
                return null;

            dynamic resultado = JsonConvert.DeserializeObject(response.Content);

            if ((resultado.data.results as IList).Count == 0)
                return null;

            PersonagemViewModel personagem = JsonConvert.DeserializeObject<PersonagemViewModel>(JsonConvert.SerializeObject(resultado.data.results[0]));
            _distributedCache.SetString(nome.ToBase64(), JsonConvert.SerializeObject(personagem));
            return personagem;
        }
    }
}
