using Loft.RPGGame.Domain.Enums;
using Loft.RPGGame.Domain.Interfaces.Contracts;

namespace Loft.RPGGame.WebAPI.Contracts
{
    public class CharacterDetailResult : ICharacterDetailResult
    {

        public CharacterDetailResult(Guid id, string name, string occupationName, short healthPoints, short strenght, short dexterity, short intelligence, Dictionary<AttributeTypeEnum, short> strike, Dictionary<AttributeTypeEnum, short> speed)
        {
            Id = id;
            Name = name;
            OccupationName = occupationName;
            HealthPoints = healthPoints;
            Strenght = strenght;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Strike = strike;
            Speed = speed;
        }

        public CharacterDetailResult()
        {

        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string OccupationName { get; private set; }

        public short HealthPoints { get; private set; }

        public short Strenght { get; private set; }

        public short Dexterity { get; private set; }

        public short Intelligence { get; private set; }

        public Dictionary<AttributeTypeEnum, short> Strike { get; private set; }

        public Dictionary<AttributeTypeEnum, short> Speed { get; private set; }
    }
}
