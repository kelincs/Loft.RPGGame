using Loft.RPGGame.Domain.Entities;
using Loft.RPGGame.Domain.Enums;
using Loft.RPGGame.Domain.Interfaces;

namespace Loft.RPGGame.Application.Implementations
{
    public class OccupationFactory : IOccupationFactory
    {
        public IOccupation CreateOccupation(OccupationTypeEnum type)
        {
            return type switch
            {
                OccupationTypeEnum.Warrior => new WarriorOccupation(),
                OccupationTypeEnum.Mage => new MageOccupation(),
                OccupationTypeEnum.Thief => new ThiefOccupation(),
                _ => throw new ApplicationException($"Occupation type: '{type}' cannot be created"),
            };
        }


    }
}
