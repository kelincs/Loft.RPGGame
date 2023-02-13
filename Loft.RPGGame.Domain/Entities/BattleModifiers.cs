using Loft.RPGGame.Domain.Enums;

namespace Loft.RPGGame.Domain.Entities
{
    public class BattleModifiers
    {
        public short CalculatedBonusStrike { get; set; } = 0;
        public short CalculatedBonusSpeed { get; set; } = 0;
        public Dictionary<AttributeTypeEnum, short> BattleBonusStrike { get; set; }
        public Dictionary<AttributeTypeEnum, short> BattleBonusSpeed { get; set; }

        public BattleModifiers()
        {
            BattleBonusSpeed = new();
            BattleBonusStrike = new();
           
        }


    }
}