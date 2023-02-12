using Loft.RPGGame.Domain.Enums;

namespace Loft.RPGGame.Application.Contracts.Request
{
    public class CharacterRequest
    {
        public string Name { get; set; }
        public OccupationTypeEnum OccupationType { get; set; }
    }
}
