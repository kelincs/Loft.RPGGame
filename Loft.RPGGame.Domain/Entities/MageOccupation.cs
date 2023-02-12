using Loft.RPGGame.Domain.Enums;
using Loft.RPGGame.Domain.Interfaces;

namespace Loft.RPGGame.Domain.Entities
{
    public class MageOccupation : IOccupation
    {
        private readonly OccupationTypeEnum _occupationType;
        private readonly Attributes _attributes;
        private readonly BeattleModifiers _beattleModifiers;

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

            _beattleModifiers = new BeattleModifiers
            {
                CalculatedBonusStrike = (short)((STRENGHT * 0.2) + (DEXTERITY * 0.5) + (INTELLIGENCE * 1.5)),
                CalculatedBonusSpeed = (short)((STRENGHT * 0.2) + (DEXTERITY * 0.5))
            };
            _beattleModifiers.BeattleBonusStrike.Add(AttributeTypeEnum.Strenght, 20);
            _beattleModifiers.BeattleBonusStrike.Add(AttributeTypeEnum.Dexterity, 50);
            _beattleModifiers.BeattleBonusStrike.Add(AttributeTypeEnum.Intelligence, 150);

            _beattleModifiers.BeattleBonusSpeed.Add(AttributeTypeEnum.Strenght, 20);
            _beattleModifiers.BeattleBonusSpeed.Add(AttributeTypeEnum.Dexterity, 50);
        }

        public OccupationTypeEnum OccupationType => _occupationType;
        public Attributes Attributes => _attributes;
        public BeattleModifiers BeattleModifiers => _beattleModifiers;
    }
}
