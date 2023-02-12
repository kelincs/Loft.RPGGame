using Loft.RPGGame.Domain.Enums;

namespace Loft.RPGGame.Domain.Interfaces.Contracts
{
    public interface ICharacterDetailResult
    {
        public Guid Id { get; }
        public string Name { get; }
        public string OccupationName { get; }
        public short HealthPoints { get; }
        public short Strenght { get; } 
        public short Dexterity { get; }
        public short Intelligence { get; }
        public Dictionary<AttributeTypeEnum, short> Strike { get; }
        public Dictionary<AttributeTypeEnum, short> Speed { get; }

        
    }
}
