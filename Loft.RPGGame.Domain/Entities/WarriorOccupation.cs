using Loft.RPGGame.Domain.Enums;
using Loft.RPGGame.Domain.Interfaces;

namespace Loft.RPGGame.Domain.Entities
{
    public class WarriorOccupation : IOccupation
    {
        private readonly OccupationTypeEnum _occupationType;
        private readonly Attributes _attributes;
        private readonly BattleModifiers _battleModifiers;

        #region Constants
        const short HEALTHPOINTS = 20;
        const short STRENGHT = 10;
        const short DEXTERITY = 5;
        const short INTELLIGENCE = 5;
        #endregion


        public WarriorOccupation()
        {
            _occupationType = OccupationTypeEnum.Warrior;
            _attributes = new Attributes();
            _attributes.AttributesDic[AttributeTypeEnum.HealthPoints] = HEALTHPOINTS;
            _attributes.AttributesDic[AttributeTypeEnum.Strenght] = STRENGHT;
            _attributes.AttributesDic[AttributeTypeEnum.Dexterity] = DEXTERITY;
            _attributes.AttributesDic[AttributeTypeEnum.Intelligence] = INTELLIGENCE;
            
            _battleModifiers = new BattleModifiers
            {
                CalculatedBonusStrike = ((short)((STRENGHT * 0.8) + (DEXTERITY * 0.2))),
                CalculatedBonusSpeed = ((short)((DEXTERITY * 0.6) + (INTELLIGENCE * 0.2)))
            };
            _battleModifiers.BattleBonusStrike.Add(AttributeTypeEnum.Strenght, 80);
            _battleModifiers.BattleBonusStrike.Add(AttributeTypeEnum.Dexterity, 20);

            _battleModifiers.BattleBonusSpeed.Add(AttributeTypeEnum.Dexterity, 60);
            _battleModifiers.BattleBonusSpeed.Add(AttributeTypeEnum.Intelligence, 20);   
        }

        public OccupationTypeEnum OccupationType => _occupationType;        
        public Attributes Attributes => _attributes;
        public BattleModifiers BattleModifiers => _battleModifiers;

    }
}
