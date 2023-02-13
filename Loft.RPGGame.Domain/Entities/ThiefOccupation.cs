using Loft.RPGGame.Domain.Enums;
using Loft.RPGGame.Domain.Interfaces;

namespace Loft.RPGGame.Domain.Entities
{
    public class ThiefOccupation : IOccupation
    {
        private readonly OccupationTypeEnum _occupationType;
        private readonly Attributes _attributes;
        private readonly BattleModifiers _battleModifiers;

        #region Constants
        const short HEALTHPOINTS = 15;
        const short STRENGHT = 4;
        const short DEXTERITY = 10;
        const short INTELLIGENCE = 4;
        #endregion

        public ThiefOccupation()
        {
            _occupationType = OccupationTypeEnum.Thief;
            _attributes = new Attributes();
            _attributes.AttributesDic[AttributeTypeEnum.HealthPoints] = HEALTHPOINTS;
            _attributes.AttributesDic[AttributeTypeEnum.Strenght] = STRENGHT;
            _attributes.AttributesDic[AttributeTypeEnum.Dexterity] = DEXTERITY;
            _attributes.AttributesDic[AttributeTypeEnum.Intelligence] = INTELLIGENCE;

            _battleModifiers = new BattleModifiers
            {
                CalculatedBonusStrike = (short)((STRENGHT * 0.25) + (DEXTERITY * 1.0) + (INTELLIGENCE * 0.25)),
                CalculatedBonusSpeed = (short)(DEXTERITY * 0.8)
            };
            _battleModifiers.BattleBonusStrike.Add(AttributeTypeEnum.Strenght, 25);
            _battleModifiers.BattleBonusStrike.Add(AttributeTypeEnum.Dexterity, 100);
            _battleModifiers.BattleBonusStrike.Add(AttributeTypeEnum.Intelligence, 25);

            _battleModifiers.BattleBonusSpeed.Add(AttributeTypeEnum.Dexterity, 80);            
        }

        public OccupationTypeEnum OccupationType => _occupationType;
        public Attributes Attributes => _attributes;
        public BattleModifiers BattleModifiers => _battleModifiers;
    }
}
