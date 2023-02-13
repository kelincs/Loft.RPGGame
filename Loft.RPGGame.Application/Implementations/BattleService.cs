using Loft.RPGGame.Application.Contracts.Response;
using Loft.RPGGame.Domain.Entities;
using Loft.RPGGame.Domain.Interfaces;
using Loft.RPGGame.Domain.Interfaces.Contracts;

namespace Loft.RPGGame.Application.Implementations
{
    public class BattleService : IBattleService
    {
        private readonly IOccupationFactory _occupationFactory;
        private readonly ICharacterService _characterService;
        private Character _createdPlayerOne;
        private Character _createdPlayerTwo;
        private readonly List<string> _logs= new();

        public BattleService(IOccupationFactory occupationFactory, ICharacterService characterService)
        {   
            _occupationFactory = occupationFactory;
            _characterService = characterService;

        }
        public IBattleResult ExecuteBattle(Guid playerOneId, Guid playerTwoId)
        {
            _createdPlayerOne = _characterService.GetCharacterById(playerOneId);
            _createdPlayerTwo = _characterService.GetCharacterById(playerTwoId);

            if (_createdPlayerOne is null)
            {
                throw new ArgumentException($"O personagem de id {playerOneId} não existe e não será possível a batalha.");
            }
            if (_createdPlayerTwo is null)
            {
                throw new ArgumentException($"O personagem de id {playerTwoId} não existe e não será possível a batalha.");
            }

            SetWhoStarts();

            bool isSomeoneDead = false;            

            var attacker = _createdPlayerOne.Starts ? _createdPlayerOne : _createdPlayerTwo;
            var offender = _createdPlayerOne.Starts ? _createdPlayerTwo : _createdPlayerOne;            

            while (!isSomeoneDead)
            {
                var calculatedStrike = GetRandomStrike(attacker);
                var realHealthPointsLeftOver = offender.Occupation.Attributes.AttributesDic[Domain.Enums.AttributeTypeEnum.HealthPoints] - calculatedStrike;
                var healthPointsLeftOver = realHealthPointsLeftOver < 0 ? 0 : realHealthPointsLeftOver;

                offender.Occupation.Attributes.AttributesDic[Domain.Enums.AttributeTypeEnum.HealthPoints] = (short)healthPointsLeftOver;

                _logs.Add($"{attacker.Name} atacou {offender.Name} com {calculatedStrike} de dano, {offender.Name} com {healthPointsLeftOver} pontos de vida restantes");
                
                if (healthPointsLeftOver == 0)
                {
                    offender.IsAlived = false;
                    attacker.IsWinner = true;                    
                    isSomeoneDead = true;
                    _logs.Add($"{attacker.Name} venceu a batalha! {attacker.Name} ainda tem {attacker.Occupation.Attributes.AttributesDic[Domain.Enums.AttributeTypeEnum.HealthPoints]} pontos de vida restantes!");
                }
                else
                {
                    var exAttacker = attacker;
                    attacker = offender;
                    offender = exAttacker;
                }
            }

            _characterService.UpdateCharacter(attacker);
            _characterService.UpdateCharacter(offender);

            return new BattleResult(_logs, attacker.Id, offender.Id);
            
        }

        private void SetWhoStarts()
        {
            bool start = false;

            while (!start)
            {
                var randomSpeedPlayerOne = new Random().Next(0, _createdPlayerOne.Occupation.BattleModifiers.CalculatedBonusSpeed);
                var randomSpeedPlayerTwo = new Random().Next(0, _createdPlayerTwo.Occupation.BattleModifiers.CalculatedBonusSpeed);
                
                if (randomSpeedPlayerOne > randomSpeedPlayerTwo)
                {
                    _createdPlayerOne.Starts = true;                    
                    start = true;
                    _logs.Add($"{_createdPlayerOne.Name} ({randomSpeedPlayerOne}) foi mais veloz que o {_createdPlayerTwo.Name} ({randomSpeedPlayerTwo}), e irá começar!");

                }                
                else if (randomSpeedPlayerTwo > randomSpeedPlayerOne)
                {
                    _createdPlayerTwo.Starts = true;
                    start = true;
                    _logs.Add($"{_createdPlayerTwo.Name} ({randomSpeedPlayerTwo}) foi mais veloz que o {_createdPlayerOne.Name} ({randomSpeedPlayerOne}), e irá começar!");
                }
            }
        }

        private short GetRandomStrike(Character character)
        {
            return (short)new Random().Next(0, character.Occupation.BattleModifiers.CalculatedBonusStrike);            
        }
    }
}
