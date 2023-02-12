using Loft.RPGGame.Domain.Enums;

namespace Loft.RPGGame.Domain.Entities
{
    public class BeattleModifiers
    {
        public short CalculatedBonusStrike { get; set; } = 0;
        public short CalculatedBonusSpeed { get; set; } = 0;
        public Dictionary<AttributeTypeEnum, short> BeattleBonusStrike { get; set; }
        public Dictionary<AttributeTypeEnum, short> BeattleBonusSpeed { get; set; }

        public BeattleModifiers()
        {
            BeattleBonusSpeed = new();
            BeattleBonusStrike = new();
           
        }


    }
}