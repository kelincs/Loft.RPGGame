using Loft.RPGGame.Domain.Enums;
using Loft.RPGGame.Domain.Interfaces;

namespace Loft.RPGGame.Domain.Entities
{
    public class MageOccupation : IOccupation
    {
        private readonly OccupationTypeEnum _occupationType;
        private readonly Attributes _attributes;
        private readonly BattleModifiers _battleModifiers;

        #region Constants
        const short HEALTHPOINTS = 12;
        const short STRENGHT = 5;
        const short DEXTERITY = 6;
        const short INTELLIGENCE = 10;
        #endregion

        public MageOccupation()
        {
            _occupationType = OccupationTypeEnum.Mage;
            _attributes = new Attributes();
            _attributes.AttributesDic[AttributeTypeEnum.HealthPoints] = HEALTHPOINTS;
            _attributes.AttributesDic[AttributeTypeEnum.Strenght] = STRENGHT;
            _attributes.AttributesDic[AttributeTypeEnum.Dexterity] = DEXTERITY;
            _attributes.AttributesDic[AttributeTypeEnum.Intelligence] = INTELLIGENCE;

            _battleModifiers = new BattleModifiers
            {
                CalculatedBonusStrike = (short)((STRENGHT * 0.2) + (DEXTERITY * 0.5) + (INTELLIGENCE * 1.5)),
                CalculatedBonusSpeed = (short)((STRENGHT * 0.2) + (DEXTERITY * 0.5))
            };
            _battleModifiers.BattleBonusStrike.Add(AttributeTypeEnum.Strenght, 20);
            _battleModifiers.BattleBonusStrike.Add(AttributeTypeEnum.Dexterity, 50);
            _battleModifiers.BattleBonusStrike.Add(AttributeTypeEnum.Intelligence, 150);

            _battleModifiers.BattleBonusSpeed.Add(AttributeTypeEnum.Strenght, 20);
            _battleModifiers.BattleBonusSpeed.Add(AttributeTypeEnum.Dexterity, 50);
        }

        public OccupationTypeEnum OccupationType => _occupationType;
        public Attributes Attributes => _attributes;
        public BattleModifiers BattleModifiers => _battleModifiers;
    }
}
