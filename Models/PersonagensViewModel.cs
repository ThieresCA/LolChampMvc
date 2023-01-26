using Newtonsoft.Json;

namespace LolChampMvc.Models
{
    public class Personagem
    {
        [JsonProperty("data")]
        //fazendo um dicionario de Datum
        public Dictionary<string, Datum> Data { get; set; }
    }
    public class Datum
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("key")]
        public long Key { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("blurb")]
        public string Blurb { get; set; }
        [JsonProperty("info")]
        public Info Info { get; set; }
        [JsonProperty("tags")]
        public Tag[] Tags { get; set; }
    }

    public class Info
    {
        [JsonProperty("attack")]
        public long Attack { get; set; }
        [JsonProperty("defense")]
        public long Defense { get; set; }
        [JsonProperty("magic")]
        public long Magic { get; set; }
        [JsonProperty("difficulty")]
        public long Difficulty { get; set; }
    }

    public enum Tag
    {
        Assassin,
        Fighter,
        Mage,
        Marksman,
        Melee,
        Support,
        Tank
    };
}