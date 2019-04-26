using Newtonsoft.Json;

namespace MarvelHeroes.Server.Models.Personagens
{
    public class PersonagemViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Descricao { get; set; }

        [JsonProperty(PropertyName = "thumbnail")]
        public ImagemViewModel Imagem { get; set; }
    }
}
