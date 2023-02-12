using Loft.RPGGame.Domain.Entities;
using Loft.RPGGame.Domain.Interfaces;

using Loft.RPGGame.Infrastructure.Singleton;

namespace Loft.RPGGame.Infrastructure.Services
{
    public class CharacterService : ICharacterService
    {
       
        public List<Character> GetAllCharacters()
        {
            return CharactersSingleton.GetCharacters();    
        }

        public Character GetCharacterById(Guid id)
        {
            return CharactersSingleton.GetCharacters().FirstOrDefault(f => f.Id == id);
        }

        public void AddCharacter(Character character)
        {
            CharactersSingleton.AddCharacter(character);
        }

        public void UpdateCharacter(Character character)
        {
            CharactersSingleton.UpdateCharacter(character);
        }
    }
}
