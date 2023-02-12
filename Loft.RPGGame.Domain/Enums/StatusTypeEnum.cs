using System.Text.Json.Serialization;

namespace Loft.RPGGame.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusTypeEnum
    {
        Alive = 1,
        Dead = 2
    }
}
