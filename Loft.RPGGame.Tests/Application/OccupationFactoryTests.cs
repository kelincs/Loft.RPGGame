using Loft.RPGGame.Application.Implementations;
using Loft.RPGGame.Domain.Entities;
using Loft.RPGGame.Domain.Enums;
using Loft.RPGGame.Domain.Interfaces;
using Moq;

namespace Loft.RPGGame.Tests
{
    public class OccupationFactoryTests
    {
         

        public OccupationFactoryTests()
        {   
           
        }

        
        [Fact]
        public void SeEnviarOTipoMage_DeveRetornarUmObjetoMageComOsValoresDefaultCorretos()
        {
            var attributes = new Attributes();
            attributes.AttributesDic[AttributeTypeEnum.HealthPoints] = 12;
            attributes.AttributesDic[AttributeTypeEnum.Strenght] = 5;
            attributes.AttributesDic[AttributeTypeEnum.Dexterity] = 6;
            attributes.AttributesDic[AttributeTypeEnum.Intelligence] = 10;

            var battleModifiers = new BattleModifiers
            {
                //1+3+15
                CalculatedBonusStrike = 19,
                //1+3
                CalculatedBonusSpeed = 4
            };

            battleModifiers.BattleBonusStrike.Add(AttributeTypeEnum.Strenght, 20);
            battleModifiers.BattleBonusStrike.Add(AttributeTypeEnum.Dexterity, 50);
            battleModifiers.BattleBonusStrike.Add(AttributeTypeEnum.Intelligence, 150);

            battleModifiers.BattleBonusSpeed.Add(AttributeTypeEnum.Strenght, 20);
            battleModifiers.BattleBonusSpeed.Add(AttributeTypeEnum.Dexterity, 50);
                        
            var result = new OccupationFactory().CreateOccupation(OccupationTypeEnum.Mage);

            Assert.IsType<MageOccupation>(result);
            Assert.True(result.OccupationType == OccupationTypeEnum.Mage);
            
            Assert.True(result.Attributes.AttributesDic[AttributeTypeEnum.Strenght] == attributes.AttributesDic[AttributeTypeEnum.Strenght]);
            Assert.True(result.Attributes.AttributesDic[AttributeTypeEnum.Intelligence] == attributes.AttributesDic[AttributeTypeEnum.Intelligence]);
            Assert.True(result.Attributes.AttributesDic[AttributeTypeEnum.Dexterity] == attributes.AttributesDic[AttributeTypeEnum.Dexterity]);
            Assert.True(result.Attributes.AttributesDic[AttributeTypeEnum.HealthPoints] == attributes.AttributesDic[AttributeTypeEnum.HealthPoints]);

            Assert.True(result.BattleModifiers.BattleBonusStrike[AttributeTypeEnum.Strenght] == battleModifiers.BattleBonusStrike[AttributeTypeEnum.Strenght]);
            Assert.True(result.BattleModifiers.BattleBonusStrike[AttributeTypeEnum.Dexterity] == battleModifiers.BattleBonusStrike[AttributeTypeEnum.Dexterity]);
            Assert.True(result.BattleModifiers.BattleBonusStrike[AttributeTypeEnum.Intelligence] == battleModifiers.BattleBonusStrike[AttributeTypeEnum.Intelligence]);
            Assert.True(result.BattleModifiers.BattleBonusStrike.Count == battleModifiers.BattleBonusStrike.Count);

            Assert.True(result.BattleModifiers.BattleBonusSpeed[AttributeTypeEnum.Strenght] == battleModifiers.BattleBonusSpeed[AttributeTypeEnum.Strenght]);
            Assert.True(result.BattleModifiers.BattleBonusSpeed[AttributeTypeEnum.Dexterity] == battleModifiers.BattleBonusSpeed[AttributeTypeEnum.Dexterity]);
            Assert.True(result.BattleModifiers.BattleBonusSpeed.Count == battleModifiers.BattleBonusSpeed.Count);

            Assert.True(result.BattleModifiers.CalculatedBonusStrike == battleModifiers.CalculatedBonusStrike);
            Assert.True(result.BattleModifiers.CalculatedBonusSpeed == battleModifiers.CalculatedBonusSpeed);
        }

        [Fact]
        public void SeEnviarOTipoThief_DeveRetornarUmObjetoThiefComOsValoresDefaultCorretos()
        {
            var attributes = new Attributes();
            attributes.AttributesDic[AttributeTypeEnum.HealthPoints] = 15;
            attributes.AttributesDic[AttributeTypeEnum.Strenght] = 4;
            attributes.AttributesDic[AttributeTypeEnum.Dexterity] = 10;
            attributes.AttributesDic[AttributeTypeEnum.Intelligence] = 4;

            var battleModifiers = new BattleModifiers
            {
                //1+10+1
                CalculatedBonusStrike = 12,
                //8
                CalculatedBonusSpeed = 8
            };

            battleModifiers.BattleBonusStrike.Add(AttributeTypeEnum.Strenght, 25);
            battleModifiers.BattleBonusStrike.Add(AttributeTypeEnum.Dexterity, 100);
            battleModifiers.BattleBonusStrike.Add(AttributeTypeEnum.Intelligence, 25);

            battleModifiers.BattleBonusSpeed.Add(AttributeTypeEnum.Dexterity, 80);

            var result = new OccupationFactory().CreateOccupation(OccupationTypeEnum.Thief);

            Assert.IsType<ThiefOccupation>(result);
            Assert.True(result.OccupationType == OccupationTypeEnum.Thief);

            Assert.True(result.Attributes.AttributesDic[AttributeTypeEnum.Strenght] == attributes.AttributesDic[AttributeTypeEnum.Strenght]);
            Assert.True(result.Attributes.AttributesDic[AttributeTypeEnum.Intelligence] == attributes.AttributesDic[AttributeTypeEnum.Intelligence]);
            Assert.True(result.Attributes.AttributesDic[AttributeTypeEnum.Dexterity] == attributes.AttributesDic[AttributeTypeEnum.Dexterity]);
            Assert.True(result.Attributes.AttributesDic[AttributeTypeEnum.HealthPoints] == attributes.AttributesDic[AttributeTypeEnum.HealthPoints]);

            Assert.True(result.BattleModifiers.BattleBonusStrike[AttributeTypeEnum.Strenght] == battleModifiers.BattleBonusStrike[AttributeTypeEnum.Strenght]);
            Assert.True(result.BattleModifiers.BattleBonusStrike[AttributeTypeEnum.Dexterity] == battleModifiers.BattleBonusStrike[AttributeTypeEnum.Dexterity]);
            Assert.True(result.BattleModifiers.BattleBonusStrike[AttributeTypeEnum.Intelligence] == battleModifiers.BattleBonusStrike[AttributeTypeEnum.Intelligence]);
            Assert.True(result.BattleModifiers.BattleBonusStrike.Count == battleModifiers.BattleBonusStrike.Count);
                        
            Assert.True(result.BattleModifiers.BattleBonusSpeed[AttributeTypeEnum.Dexterity] == battleModifiers.BattleBonusSpeed[AttributeTypeEnum.Dexterity]);
            Assert.True(result.BattleModifiers.BattleBonusSpeed.Count == battleModifiers.BattleBonusSpeed.Count);

            Assert.True(result.BattleModifiers.CalculatedBonusStrike == battleModifiers.CalculatedBonusStrike);
            Assert.True(result.BattleModifiers.CalculatedBonusSpeed == battleModifiers.CalculatedBonusSpeed);
        }

        [Fact]
        public void SeEnviarOTipoWarrior_DeveRetornarUmObjetoWarriorComOsValoresDefaultCorretos()
        {
            var attributes = new Attributes();
            attributes.AttributesDic[AttributeTypeEnum.HealthPoints] = 20;
            attributes.AttributesDic[AttributeTypeEnum.Strenght] = 10;
            attributes.AttributesDic[AttributeTypeEnum.Dexterity] = 5;
            attributes.AttributesDic[AttributeTypeEnum.Intelligence] = 5;

            var battleModifiers = new BattleModifiers
            {
                //8+1
                CalculatedBonusStrike = 9,
                //3+1
                CalculatedBonusSpeed = 4
            };

            battleModifiers.BattleBonusStrike.Add(AttributeTypeEnum.Strenght, 80);
            battleModifiers.BattleBonusStrike.Add(AttributeTypeEnum.Dexterity, 20);            

            battleModifiers.BattleBonusSpeed.Add(AttributeTypeEnum.Dexterity, 60);
            battleModifiers.BattleBonusSpeed.Add(AttributeTypeEnum.Intelligence, 20);
            
            var result = new OccupationFactory().CreateOccupation(OccupationTypeEnum.Warrior);

            Assert.IsType<WarriorOccupation>(result);
            Assert.True(result.OccupationType == OccupationTypeEnum.Warrior);

            Assert.True(result.Attributes.AttributesDic[AttributeTypeEnum.Strenght] == attributes.AttributesDic[AttributeTypeEnum.Strenght]);
            Assert.True(result.Attributes.AttributesDic[AttributeTypeEnum.Intelligence] == attributes.AttributesDic[AttributeTypeEnum.Intelligence]);
            Assert.True(result.Attributes.AttributesDic[AttributeTypeEnum.Dexterity] == attributes.AttributesDic[AttributeTypeEnum.Dexterity]);
            Assert.True(result.Attributes.AttributesDic[AttributeTypeEnum.HealthPoints] == attributes.AttributesDic[AttributeTypeEnum.HealthPoints]);

            Assert.True(result.BattleModifiers.BattleBonusStrike[AttributeTypeEnum.Strenght] == battleModifiers.BattleBonusStrike[AttributeTypeEnum.Strenght]);
            Assert.True(result.BattleModifiers.BattleBonusStrike[AttributeTypeEnum.Dexterity] == battleModifiers.BattleBonusStrike[AttributeTypeEnum.Dexterity]);            
            Assert.True(result.BattleModifiers.BattleBonusStrike.Count == battleModifiers.BattleBonusStrike.Count);

            Assert.True(result.BattleModifiers.BattleBonusSpeed[AttributeTypeEnum.Dexterity] == battleModifiers.BattleBonusSpeed[AttributeTypeEnum.Dexterity]);
            Assert.True(result.BattleModifiers.BattleBonusSpeed[AttributeTypeEnum.Intelligence] == battleModifiers.BattleBonusSpeed[AttributeTypeEnum.Intelligence]);
            Assert.True(result.BattleModifiers.BattleBonusSpeed.Count == battleModifiers.BattleBonusSpeed.Count);

            Assert.True(result.BattleModifiers.CalculatedBonusStrike == battleModifiers.CalculatedBonusStrike);
            Assert.True(result.BattleModifiers.CalculatedBonusSpeed == battleModifiers.CalculatedBonusSpeed);

        }
    }
}