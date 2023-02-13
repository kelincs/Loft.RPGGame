using Loft.RPGGame.Domain.Entities;
using Loft.RPGGame.Domain.Enums;

namespace Loft.RPGGame.Domain.Interfaces
{
    public interface IOccupation
    {
        public OccupationTypeEnum OccupationType { get; }        
        public BattleModifiers BattleModifiers { get; }        
        public Attributes Attributes { get; }


    }
}

