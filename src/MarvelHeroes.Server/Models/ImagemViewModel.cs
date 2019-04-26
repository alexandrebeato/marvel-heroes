using Newtonsoft.Json;

namespace MarvelHeroes.Server.Models
{
    public class ImagemViewModel
    {
        [JsonProperty(PropertyName = "path")]
        public string Caminho { get; set; }

        [JsonProperty(PropertyName = "extension")]
        public string Extensao { get; set; }

        [JsonIgnore]
        public string CaminhoCompleto
        {
            get
            {
                return $"{Caminho}.{Extensao}";
            }
        }
    }
}
