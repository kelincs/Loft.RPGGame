using Loft.RPGGame.Domain.Entities;

namespace Loft.RPGGame.Domain.Interfaces
{
    public interface ICharacterService
    {
        public List<Character> GetAllCharacters();

        public Character GetCharacterById(Guid id);

        public void AddCharacter(Character character);  
        
        public void UpdateCharacter(Character character);
    }
}
