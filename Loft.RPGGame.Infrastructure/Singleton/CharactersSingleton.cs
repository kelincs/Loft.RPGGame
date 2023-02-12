using Loft.RPGGame.Domain.Entities;

namespace Loft.RPGGame.Infrastructure.Singleton
{
    public sealed class CharactersSingleton
    {
        private static CharactersSingleton _instance;
        private static List<Character> _characters;    
        private static readonly object _padlock = new();

        private CharactersSingleton()
        {
            _characters = new List<Character>
            {
                new Character() { Name = "Zahir", Occupation = new MageOccupation() },
                new Character() { Name = "Shandra", Occupation = new ThiefOccupation() },
                new Character() { Name = "Adric", Occupation = new WarriorOccupation() }
            };
        }

        public static CharactersSingleton GetInstance()
        {
            if (_instance == null)
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new();
                    }
                }
            }
            return _instance;
        }           

        public static List<Character> GetCharacters() => _characters;
        public static void AddCharacter(Character character) { _characters.Add(character); }

        public static void UpdateCharacter(Character character) 
        {
            _characters.RemoveAll(f => f.Id == character.Id);
            _characters.Add(character);        
        }

       


    }
}

