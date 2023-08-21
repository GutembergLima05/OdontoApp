using System.Text.Json.Serialization;

namespace OdontoAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ExameTypeEnum
    {
        Restauracao,
        Periodentia,
        Radiografia,
        Extracao,
        Bruxismo

    }
}
