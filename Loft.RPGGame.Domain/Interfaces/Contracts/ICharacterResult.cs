using Loft.RPGGame.Domain.Enums;

namespace Loft.RPGGame.Domain.Interfaces.Contracts
{
    public interface ICharacterResult
    {
        public Guid Id { get; }
        public string Name { get; }
        public string OccupationName { get; }
        public StatusTypeEnum Status { get; }
        
    }
}
