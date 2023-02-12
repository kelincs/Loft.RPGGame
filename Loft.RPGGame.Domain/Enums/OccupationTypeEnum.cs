using System.Text.Json.Serialization;

namespace Loft.RPGGame.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OccupationTypeEnum : short
    {        
        Warrior = 1,
        Thief = 2,
        Mage = 3
    }
}
