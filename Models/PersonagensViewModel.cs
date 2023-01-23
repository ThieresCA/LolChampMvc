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
        [JsonProperty("image")]
        public Image Image { get; set; }
        [JsonProperty("tags")]
        public Tag[] Tags { get; set; }
    }
    public class Image
    {
        [JsonProperty("full")]
        public string Full { get; set; }
        [JsonProperty("sprite")]
        public string Sprite { get; set; }
        [JsonProperty("group")]
        public string Group { get; set; }
        [JsonProperty("x")]
        public long X { get; set; }
        [JsonProperty("y")]
        public long Y { get; set; }
        [JsonProperty("w")]
        public long W { get; set; }
        [JsonProperty("h")]
        public long H { get; set; }
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