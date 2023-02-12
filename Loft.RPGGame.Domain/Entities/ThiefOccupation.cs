using Loft.RPGGame.Domain.Enums;
using Loft.RPGGame.Domain.Interfaces;

namespace Loft.RPGGame.Domain.Entities
{
    public class ThiefOccupation : IOccupation
    {
        private readonly OccupationTypeEnum _occupationType;
        private readonly Attributes _attributes;
        private readonly BeattleModifiers _beattleModifiers;

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

            _beattleModifiers = new BeattleModifiers
            {
                CalculatedBonusStrike = (short)((STRENGHT * 0.25) + (DEXTERITY * 1.0) + (INTELLIGENCE * 0.25)),
                CalculatedBonusSpeed = (short)(DEXTERITY * 0.8)
            };
            _beattleModifiers.BeattleBonusStrike.Add(AttributeTypeEnum.Strenght, 25);
            _beattleModifiers.BeattleBonusStrike.Add(AttributeTypeEnum.Dexterity, 100);
            _beattleModifiers.BeattleBonusStrike.Add(AttributeTypeEnum.Intelligence, 25);

            _beattleModifiers.BeattleBonusSpeed.Add(AttributeTypeEnum.Dexterity, 80);            
        }

        public OccupationTypeEnum OccupationType => _occupationType;
        public Attributes Attributes => _attributes;
        public BeattleModifiers BeattleModifiers => _beattleModifiers;
    }
}
