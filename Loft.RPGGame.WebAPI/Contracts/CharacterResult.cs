using Loft.RPGGame.Domain.Enums;
using Loft.RPGGame.Domain.Interfaces.Contracts;

namespace Loft.RPGGame.WebAPI.Contracts
{
    public class CharacterResult : ICharacterResult
    {
        public CharacterResult(Guid id, string name, string occupationName, StatusTypeEnum status)
        {
            Id = id;
            Name = name;
            OccupationName = occupationName;
            Status = status;
        }

        public CharacterResult()
        {           
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string OccupationName { get; private set; }

        public StatusTypeEnum Status { get; private set; }
    }
}
